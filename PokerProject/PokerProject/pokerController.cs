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
      makeDeck();
      createViewsPlayers(1);
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
        switch(kindCount)
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
        int randomIndex = random.Next(0, (tempValue.Count-1)); //random tussen 1 en en aantal elementen in temp lijst
        _model.addCardKind(tempKind[randomIndex]); //random item soort toevoegen aan lijst
        _model.addCardValue(tempValue[randomIndex]); //random value soort toevoegen aan lijst
        tempKind.RemoveAt(randomIndex); //verwijderen uit temp lijsten
        tempValue.RemoveAt(randomIndex); //verwijderen uit temp lijsten
      }
    }
    public void createViewsPlayers(int numberOfPlayers)
    {
      playerController player = new playerController(this); //Enkele player aanmaken met injectie van hoofdcontroller
      playerView playerView = player.getViewPlayer(); //Nieuwe view player
      _model.addPlayer(player); //toevoegen speler aan lijst
    }
  }
}