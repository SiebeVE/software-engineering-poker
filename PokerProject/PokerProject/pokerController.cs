﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class pokerController
  {
    private pokerView _view;
    private pokerModel _model;

    static int seeder = new Random().Next(); //nodig omdat anders random getal altijd hetzelfde is
    Random random = new Random(++seeder); //random getal genereren

    private bool gameEnded = false;

    public pokerController() //constructor
    {
      _model = new pokerModel();
      _view = new pokerView(this);
    }

    public pokerModel getModelPoker()
    {
      return _model;
    }
    public pokerView getViewPoker()
    {
      return _view;
    }

    public void initialize()
    {
      //maak random deck van kaarten
      makeDeck();
      //voor players aparte view aanmaken
      createViewsPlayers(_model.NumberOfPlayers);
      //Samenstellen van alle views in pokerView
      _view.initializeViewPoker();
      //Start big blind instellen
      _model.Players[1].getModelPlayer().MomenteleInzet = _model.BigBlind;
      _model.Players[1].getModelPlayer().Kapitaal -= _model.BigBlind;
      //Verander grootste bet in big blind
      changeBet(_model.BigBlind);
      //Start small blind instellen
      _model.Players[0].getModelPlayer().MomenteleInzet = _model.SmallBlind;
      _model.Players[0].getModelPlayer().Kapitaal -= _model.SmallBlind;
      //update van ui inzet
      _model.Players[0].getViewPlayer().updateCurInzet();
      _model.Players[1].getViewPlayer().updateCurInzet();
      //nieuw totale pot van flop + update view
      _model.FlopController.getModelPlayer().Kapitaal = _model.BigBlind + _model.SmallBlind;
      _model.FlopController.getViewPlayer().updateKapitaal();
      //volgende speler
      nextPlayer();
    }

    public List<playerView> getViewsPlayers()
    {
      List<playerView> playersView = new List<playerView>(); // Maak een lijst die de views zal opvangen
      foreach (playerController player in getModelPoker().Players) // Loop over het huidig aantal kaarten uit het model
      {
        playerView playerView = player.getViewPlayer(); // Haal de view op voor iedere kaart
        playersView.Add(playerView); // Voeg de kaart toe aan de lijst die de views opvangt
      }
      return playersView; // Return de lijst met views van de kaarten
    }

    public void makeDeck()
    {
      //eerst lijst maken van alle kaarten
      List<string> tempKind = new List<string>(); //temp lijst van soort kaarten
      List<int> tempValue = new List<int>(); //temp lijst van soort kaarten

      for (int kindCount = 0; kindCount < 4; kindCount++)
      {
        //beginnen for loop met soort kiezen
        string currentKind;
        switch (kindCount)
        {
          case 0:
            currentKind = "hearts";
            break;
          case 1:
            currentKind = "clubs";
            break;
          case 2:
            currentKind = "spades";
            break;
          case 3:
            currentKind = "diamonds";
            break;
          default:
            currentKind = "none";
            break;
        }
        for (int valueCount = 2; valueCount <= 14; valueCount++) //van 2 tot 14 zodat aas, 14 is en andere waarden wel kloppen
        {
          //toevoegen aan lijsten
          tempKind.Add(currentKind);
          tempValue.Add(valueCount);
        }
      }
      int currentCardIndex = 0;
      while (currentCardIndex < tempValue.Count)
      {
        int randomIndex = random.Next(0, (tempValue.Count - 1)); //random tussen 1 en en aantal elementen in temp lijst
        _model.addCardKind(tempKind[randomIndex]); //random item soort toevoegen aan lijst
        _model.addCardValue(tempValue[randomIndex]); //random value soort toevoegen aan lijst
        tempKind.RemoveAt(randomIndex); //verwijderen uit temp lijsten
        tempValue.RemoveAt(randomIndex); //verwijderen uit temp lijsten
      }
    }
    public void createViewsPlayers(int numberOfPlayers)
    {
      for (int playerNr = 0; playerNr < numberOfPlayers; playerNr++)
      {
        playerController player = new playerController(this, 2); //Enkele player aanmaken met injectie van hoofdcontroller
        playerView playerView = player.getViewPlayer(); //Nieuwe view player
        _model.addPlayer(player); //toevoegen speler aan lijst
      }
    }

    public void cardsFlipCurrent()
    {
      //draait de kaart van de huidige speler om
      //lijst maken van alle kaarten van huidige speler
      List<cardController> cardsOfPlayer = _model.getCurrentPlayer().getModelPlayer().Cards;
      foreach (cardController card in cardsOfPlayer)
      {
        //kaart per kaart omdraaien
        card.flipCard();
      }
    }

    public void makeCurrent(int newCurrent)
    {
      //aanpassen van huidige speler
      while (_model.Players[newCurrent].getModelPlayer().Folded)
      {
        if (newCurrent == _model.IndexStopPlayer)
        {
          endRound();
        }
        newCurrent = nextIndexNumberOf(newCurrent);
      }
      if (!gameEnded)
      {
        //Laten weten aan model
        _model.IndexCurrentPlayer = newCurrent;
        //laten weten aan player model dat dit huidige is
        _model.getCurrentPlayer().getModelPlayer().Current = true;
        //van stijl veranderen -> maken = true
        changeStyleCurrent(true);
      }
    }
    public void changeStyleCurrent(bool newCurrent)
    {
      //achtergrond kleur veranderen van huidge speler
      Color colorBack;
      if (!newCurrent)
      {
        //als niet actief
        colorBack = Color.Gray;
      }
      else
      {
        //als actief
        colorBack = Color.Green;
      }
      //oproepen methode voor veranderen kleur
      _model.getCurrentPlayer().getViewPlayer().updateBack(colorBack);
    }

    public void endRound()
    {
      //ronde is ten einde
      //veranderen van raise naar bet
      _model.View_button.toggleRaise();
      //inzet van speler leegmaken
      int indexOfSmall = 0;
      foreach (playerController player in _model.Players)
      {
        player.getModelPlayer().MomenteleInzet = 0;
        player.getViewPlayer().updateCurInzet();
        //beurt aan correcte speler geven
        //zoeken wie dealer button heeft (zoeken persoon voor small blind)
        if (player.getModelPlayer().Special == "small")
        {
          int buttonIndex = prevIndexNumberOf(indexOfSmall);
          makeCurrent(indexOfSmall);
          _model.IndexStopPlayer = buttonIndex;
        }
        else
        {
          indexOfSmall++;
        }
      }
      //volgende kaart(en) van flop tonen
      List<cardView> kaartenFlop = _model.FlopController.getCardsView();
      switch (_model.Round)
      {
        case 1:
          kaartenFlop[0].getControllerCard().flipCard();
          kaartenFlop[1].getControllerCard().flipCard();
          kaartenFlop[2].getControllerCard().flipCard();
          break;
        case 2:
          kaartenFlop[3].getControllerCard().flipCard();
          break;
        case 3:
          kaartenFlop[4].getControllerCard().flipCard();
          break;
        case 4:
          endGame();
          break;
      }
      if (_model.View_button.getTextButton() != "Check\r\n")
      {
        _model.View_button.toggleCheck();
      }
      if (!gameEnded)
      {
        _model.View_button.updateCurrentPlayer();
        _model.BiggestBet = _model.BigBlind;
        _model.Round++;
      }
    }

    public void endGame()
    {
      gameEnded = true;
      //toon alle kaarten
      foreach (playerController player in _model.Players)
      {
        foreach (cardView card in player.getCardsView())
        {
          card.getControllerCard().flipCard();
        }
      }
      playerController winner = giveControllerWinner();
      winner.getViewPlayer().updateBack(Color.Pink);
      _model.View_button.updateToon();
    }

    public void newGame()
    {
      _model.deleteDeck();
      makeDeck();
      foreach (playerController player in _model.Players)
      {
        foreach (cardView card in player.getCardsView())
        {
          card.getControllerCard().flipCard();
        }
      }
      foreach (cardView card in _model.FlopController.getCardsView())
      {
        card.getControllerCard().flipCard();
      }

    }

    public playerController giveControllerWinner()
    {
      //rondgaan per speler wat hij/zij heeft
      int[] scoresHand = new int[_model.NumberOfPlayers];
      playerController[] arrPlayers = new playerController[_model.NumberOfPlayers];
      int indexCur = 0;
      foreach (playerController player in _model.Players)
      {
        arrPlayers[indexCur] = player;
        scoresHand[indexCur] = checkHand(player);
        indexCur++;
      }

      //sorteer op hoogste scores
      Array.Sort(scoresHand, arrPlayers);
      Array.Reverse(arrPlayers);
      Array.Reverse(scoresHand);
      //enkel lijst van spelers overhouden met hoogste scores
      int hoogsteScore = scoresHand[0];
      int tellerIndex = 0;
      List<playerController> bestPlayers = new List<playerController>();
      foreach (int score in scoresHand)
      {
        if (score == hoogsteScore)
        {
          bestPlayers.Add(arrPlayers[tellerIndex]);
        }
        tellerIndex++;
      }
      playerController winner = bestPlayers[0];
      if (bestPlayers.Count == 1)
      {
        winner = bestPlayers[0];
      }
      else
      {
        List<int> arrHighestCard = new List<int>();
        foreach (playerController player in bestPlayers)
        {
          int highestCard2 = 0;
          foreach (cardView curCardView in player.getCardsView())
          {
            int cardValue = curCardView.getControllerCard().getModelCard().CardValue;
            if (cardValue > highestCard2)
            {
              highestCard2 = cardValue;
            }

          }
          arrHighestCard.Add(highestCard2);
        }
        int test = arrHighestCard.Distinct().Count();
        IEnumerable<int> newVal = arrHighestCard.Distinct();
        if (arrHighestCard.Distinct().Count() != arrHighestCard.Count)
        {
          //splitPot();
          //return null;
        }
        int indexOfHighest = 0;
        int highestCard = 0;
        int indexCurPlay = 0;
        foreach (int highestCardPlayer in arrHighestCard)
        {
          if (highestCardPlayer > highestCard)
          {
            highestCard = highestCardPlayer;
            indexOfHighest = indexCurPlay;
          }
          indexCurPlay++;
        }
        winner = bestPlayers[indexOfHighest];
      }
      winner.getModelPlayer().Kapitaal += _model.FlopController.getModelPlayer().Kapitaal;
      return winner;
    }

    public int checkHand(playerController curPlayer)
    {
      //ophalen kaarten flop
      List<cardView> cardsFlop = _model.FlopController.getCardsView();
      //maken lijst met kind en lijst met value
      List<int> valueAllCards = new List<int>();
      List<string> kindAllCards = new List<string>();
      //eerst eigen kaarten toevoegen
      foreach (cardView card in curPlayer.getCardsView())
      {
        string cardKind = card.getControllerCard().getModelCard().CardKind;
        int cardValue = card.getControllerCard().getModelCard().CardValue;
        valueAllCards.Add(cardValue);
        kindAllCards.Add(cardKind);
      }
      //dan van flop
      foreach (cardView card in cardsFlop)
      {
        string cardKind = card.getControllerCard().getModelCard().CardKind;
        int cardValue = card.getControllerCard().getModelCard().CardValue;
        valueAllCards.Add(cardValue);
        kindAllCards.Add(cardKind);
      }
      return checkAllPossible(valueAllCards, kindAllCards);
    }

    public int checkAllPossible(List<int> values, List<string> kinds)
    {
      int value;
      int royalFlush = checkRoyalFlush(values, kinds);
      int straightFlush = checkStraightFlush(values, kinds);
      int fourOfAKind = checkFourOfAKind(values);
      int fullHouse = checkFullHouse(values);
      int flush = checkFlush(kinds);
      int straight = checkStraight(values);
      int threeOfAKind = checkThreeOfAKind(values);
      int twoPair = checkTwoPair(values);
      int pair = checkPair(values);

      if (royalFlush == 1)
      {
        value = 10;
      }
      else if (straightFlush == 1)
      {
        value = 9;
      }
      else if (fourOfAKind == 1)
      {
        value = 8;
      }
      else if (fullHouse == 1)
      {
        value = 7;
      }
      else if (flush == 1)
      {
        value = 6;
      }
      else if (straight == 1)
      {
        value = 5;
      }
      else if (threeOfAKind == 1)
      {
        value = 4;
      }
      else if (twoPair == 1)
      {
        value = 3;
      }
      else if (pair == 1)
      {
        value = 2;
      }
      else
      {
        //high card
        value = 1;
      }
      return value;
    }

    public int checkPair(List<int> values)
    {
      IEnumerable<int> newVal = values.Distinct();
      if (values.Count - newVal.Count() == 1)
      {
        //exact 1 paar
        return 1;
      }
      return 0;
    }
    public int checkTwoPair(List<int> values)
    {
      /*if (values.Count - values.Distinct().Count() == 2)
      {
        //exact 2 paar
        if (checkThreeOfAKind(values) == 1)
        {
          //Is 3 of a kind, dus negeer
          return 0;
        }
        else
        {
          return 1;
        }
      }*/
      //ff checken of er toch geen drie paar zijn
      values.Sort();
      int prevVal = 0;
      int numberOfPairs = 0;
      int numberOfSame = 1;
      foreach (int value in values)
      {
        if (prevVal != value)
        {
          numberOfSame = 1;
          prevVal = value;
        }
        else
        {
          numberOfSame++;
          if (numberOfSame == 2)
          {
            numberOfSame = 1;
            numberOfPairs++;
          }
        }
      }
      if (numberOfPairs >= 2)
      {
        return 1;
      }
      return 0;
    }
    public int checkThreeOfAKind(List<int> values)
    {
      values.Sort();
      int numberOfSameVal = 1;
      int prevVal = 0;
      foreach (int value in values)
      {
        if (prevVal != value)
        {
          numberOfSameVal = 1;
          prevVal = value;
        }
        else
        {
          numberOfSameVal++;
          if (numberOfSameVal == 3)
          {
            return 1;
          }
        }
      }
      return 0;
    }
    public int checkStraight(List<int> values)
    {
      values.Sort();
      int numberOfSameVal = 1;
      int prevVal = 0;
      foreach (int value in values)
      {
        if (prevVal != value)
        {
          if ((prevVal + 1) != value || prevVal == 0)
          {
            numberOfSameVal = 1;
          }
          else
          {
            numberOfSameVal++;
            if (numberOfSameVal == 5)
            {
              return 1;
            }
          }
          prevVal = value;
        }
      }
      return 0;
    }
    public int checkFlush(List<string> kinds)
    {
      kinds.Sort();
      int numberOfSameKind = 1;
      string prevKind = "";
      foreach (string kind in kinds)
      {
        if (prevKind != kind)
        {
          numberOfSameKind = 1;
          prevKind = kind;
        }
        else
        {
          numberOfSameKind++;
          if (numberOfSameKind == 5)
          {
            return 1;
          }
        }
      }
      return 0;
    }
    public int checkFullHouse(List<int> values)
    {
      values.Sort();
      int numberOfSameVal = 1;
      int prevVal = 0;
      foreach (int value in values)
      {
        if (prevVal != value)
        {
          numberOfSameVal = 1;
          prevVal = value;
        }
        else
        {
          numberOfSameVal++;
          if (numberOfSameVal == 3)
          {
            //verwijder value van lijst
            List<int> newValues = new List<int>();
            //newValues.RemoveAll(v => v.Equals(prevVal));
            foreach (int value2 in values)
            {
              if (value2 != prevVal)
              {
                newValues.Add(value2);
              }
            }
            if (checkPair(newValues) == 1 || checkThreeOfAKind(newValues) == 1)
            {
              return 1;
            }
          }
        }
      }
      return 0;
    }
    public int checkFourOfAKind(List<int> values)
    {
      values.Sort();
      int numberOfSameVal = 1;
      int prevVal = 0;
      foreach (int value in values)
      {
        if (prevVal != value)
        {
          numberOfSameVal = 1;
          prevVal = value;
        }
        else
        {
          numberOfSameVal++;
          if (numberOfSameVal == 4)
          {
            return 1;
          }
        }
      }
      return 0;
    }
    public int checkStraightFlush(List<int> values, List<string> kinds)
    {
      //nieuwe lijsten aanmaken zodat apart lijst gesorteerd kan worden en link tss lijsten behouden blijft
      List<int> sortedValues = new List<int>();
      List<string> sortedKinds = new List<string>();
      int teller = 0;
      foreach (int value in values)
      {
        sortedValues.Add(value);
        sortedKinds.Add(kinds[teller]);
        teller++;
      }
      //checken of straat aanwezig is
      if (checkStraight(sortedValues) == 1)
      {
        //nu checken of er geen valse kind tussen zit 
        //zelfde sortering doen van value en kind zodat index per kaart zelfde blijft
        int[] arrSortedValues = new int[7];
        string[] arrSortedKinds = new string[7];
        int index = 0;
        foreach (int value in values)
        {
          arrSortedValues[index] = value;
          arrSortedKinds[index] = kinds[index];
          index++;
        }
        Array.Sort(arrSortedValues, arrSortedKinds);
        int numberOfSameKind = 1;
        string prevKind = "";
        foreach (string kind in arrSortedKinds)
        {
          if (prevKind != kind)
          {
            numberOfSameKind = 1;
            prevKind = kind;
          }
          else
          {
            numberOfSameKind++;
            if (numberOfSameKind == 5)
            {
              return 1;
            }
          }
        }
      }
      return 0;
    }
    public int checkRoyalFlush(List<int> values, List<string> kinds)
    {
      List<int> sortedValues = new List<int>();
      List<string> sortedKinds = new List<string>();
      int teller = 0;
      foreach (int value in values)
      {
        sortedValues.Add(value);
        sortedKinds.Add(kinds[teller]);
        teller++;
      }
      //checken of straat aanwezig is
      if (checkStraight(sortedValues) == 1)
      {
        //nu checken of er geen valse kind tussen zit 
        //zelfde sortering doen van value en kind zodat index per kaart zelfde blijft
        int[] arrSortedValues = new int[7];
        string[] arrSortedKinds = new string[7];
        int index = 0;
        foreach (int value in values)
        {
          arrSortedValues[index] = value;
          arrSortedKinds[index] = kinds[index];
          index++;
        }
        Array.Sort(arrSortedValues, arrSortedKinds);
        int numberOfSameKind = 1;
        string prevKind = "";
        foreach (string kind in arrSortedKinds)
        {
          if (prevKind != kind)
          {
            numberOfSameKind = 1;
            prevKind = kind;
          }
          else
          {
            numberOfSameKind++;
            if (numberOfSameKind == 5)
            {
              int indexOf14 = Array.IndexOf(arrSortedValues, 14);
              int indexOf10 = Array.IndexOf(arrSortedValues, 10);
              if (indexOf10 > -1 && indexOf14 > -1)
              {
                //zowel 10 als 14 in array
                if (arrSortedKinds[indexOf10] == prevKind && arrSortedKinds[indexOf14] == prevKind)
                {
                  return 1;
                }
              }
            }
          }
        }
      }
      return 0;
    }

    public void nextPlayer()
    {
      //Volgende speler oproepen
      //veranderen van huidige speler achtergrond kleur -> veranderen = false
      changeStyleCurrent(false);
      //Nieuwe index van speler toekenen
      int newIndexCurrent = nextIndexNumberOf(_model.IndexCurrentPlayer);

      string textButton = _model.View_button.getTextButton();

      //nieuwe speler klaarmaken
      if (_model.IndexCurrentPlayer == _model.IndexStopPlayer && !_model.FirstGame && !_model.NewHighest)
      {
        endRound();
      }
      else
      {
        makeCurrent(newIndexCurrent);
        //tekst huidige speler laten veranderen
        _model.View_button.updateCurrentPlayer();
        //checken welke nummers mag in raise
        playerModel currentPlayerModel = _model.getCurrentPlayer().getModelPlayer();
        int curInzet = currentPlayerModel.MomenteleInzet;
        int newMin = 0;
        int newMax = currentPlayerModel.Kapitaal;
        //bepalen minimum
        if (_model.BiggestBet > curInzet)
        {
          newMin = _model.BiggestBet - curInzet + 1;
        }
        _model.View_button.changeBoundriesRaise(newMin, newMax);

      }
      /*if (_model.IndexCurrentPlayer == _model.IndexStopPlayer && !_model.FirstGame && !firstRound)
      {
        firstRound = true;
      }*/
      if (!gameEnded)
      {
        //checken voor allereerste volgende speler
        if (_model.FirstGame)
        {
          _model.FirstRoundOfHand = true;
          _model.FirstGame = false;
        }
        //checken of eerste ronde is en persoon nog mag checken
        if (newIndexCurrent == _model.IndexStopPlayer && _model.FirstRoundOfHand)
        {
          //tonen van check knop
          if (_model.View_button.getTextButton() != "Check\r\n")
          {
            //_model.View_button.toggleCheck();
          }
        }
        if (_model.NewHighest)
        {
          _model.NewHighest = false;
        }
      }
    }

    public int nextIndexNumberOf(int checkNumber)
    {
      int newIndexCurrent = checkNumber + 1;
      if (newIndexCurrent >= _model.NumberOfPlayers)
      {
        //einde van de lijst --> terug naar speler 0
        newIndexCurrent = 0;
      }
      return newIndexCurrent;
    }

    public int prevIndexNumberOf(int checkNumber)
    {
      int newIndexCurrent = checkNumber - 1;
      if (checkNumber == 0)
      {
        //begin van de lijst --> terug naar laatste
        newIndexCurrent = _model.NumberOfPlayers - 1;
      }
      return newIndexCurrent;
    }

    public void changeBet(int newBet)
    {
      //checken of nieuwe bet de grootste is en dan toewijzen aan model en zeggen dat die de 'stop' speler is
      if (newBet > _model.BiggestBet)
      {
        _model.BiggestBet = newBet;
        _model.NewHighest = true;
        //_model.IndexStopPlayer=prevIndexNumberOf( _model.IndexCurrentPlayer);
        _model.IndexStopPlayer = _model.IndexCurrentPlayer;
        //_model.FirstGame = false;
      }
    }
  }
}