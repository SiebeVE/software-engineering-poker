using System;
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
      //Laten weten aan model
      _model.IndexCurrentPlayer = newCurrent;
      //laten weten aan player model dat dit huidige is
      _model.getCurrentPlayer().getModelPlayer().Current = true;
      //van stijl veranderen -> maken = true
      changeStyleCurrent(true);
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
      //veranderen van check naar call op button
      _model.View_button.toggleCheck();
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
      }
      if (_model.View_button.getTextButton() != "Check\r\n")
      {
        _model.View_button.toggleCheck();
      }
      _model.View_button.updateCurrentPlayer();
      _model.BiggestBet = 0;
      _model.Round++;
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
      if (_model.IndexCurrentPlayer == _model.IndexStopPlayer && !_model.FirstGame)
      {
        endRound();
      }
      else
      {
        makeCurrent(newIndexCurrent);
        //tekst huidige speler laten veranderen
        _model.View_button.updateCurrentPlayer();
      }
      /*if (_model.IndexCurrentPlayer == _model.IndexStopPlayer && !_model.FirstGame && !firstRound)
      {
        firstRound = true;
      }*/
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
          _model.View_button.toggleCheck();
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
        _model.IndexStopPlayer = _model.IndexCurrentPlayer;
      }
    }
  }
}