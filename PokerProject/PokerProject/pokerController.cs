using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class pokerController
  {
    private pokerView _view;
    private pokerModel _model;
    private List<string> cardsStackKind = new List<string>();
    private List<int> cardsStackValue = new List<int>();

    static int seeder = 0; //nodig omdat anders random getal altijd hetzelfde is
    Random random = new Random(++seeder); //random getal genereren

    public pokerController() //constructor
    {
      _view = new pokerView(this);
      _model = new pokerModel();
    }

    public pokerModel getModel()
    {
      return _model;
    }
    public pokerView getView()
    {
      return _view;
    }

    public void initialize()
    {
      makeDeck();
      makeCardViews(5);      
    }

    public List<cardView> getCardsView()
    {
      // Maak een lijst die de views zal opvangen
      List<cardView> cardsView = new List<cardView>();

      // Loop over het huidig aantal teerlingen uit het model
      foreach (cardController card in getModel().Cards)
      {
        // Haal de view op voor iedere teerling
        cardView cardView = card.getView();

        // Voeg de teerling toe aan de lijst die de views opvangt
        cardsView.Add(cardView);
      }

      // Return de lijst met teerlingViews
      return cardsView;
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
        for (int valueCount = 0; valueCount < 13; valueCount++)
        {
          //toevoegen aan lijsten
          tempKind.Add(currentKind);
          tempValue.Add(valueCount);
        }
      }
      int currentCardIndex = 0;
      while (currentCardIndex < tempValue.Count)
      {
        int randomIndex = random.Next(0, tempValue.Count); //random tussen 1 en en aantal elementen in temp lijst
        cardsStackKind.Add(tempKind[randomIndex]); //random item soort toevoegen aan lijst
        cardsStackValue.Add(tempValue[randomIndex]); //random value soort toevoegen aan lijst
        tempKind.RemoveAt(randomIndex); //verwijderen uit temp lijsten
        tempValue.RemoveAt(randomIndex); //verwijderen uit temp lijsten
      }
    }
    public void makeCardViews(int numberOfCards)
    {
      for (int cardNumber = 0; cardNumber < numberOfCards; cardNumber++)
      {
        cardController card = new cardController(); //Enkele kaart aanmaken
        cardView cardView = card.getView(); //Nieuwe view kaart
        _model.addCard(card); //kaart toevoegen aan lijst

        card.getModel().CardKind = cardsStackKind[0]; //bovenste kaart soort ophalen van random lijst
        card.getModel().CardValue = cardsStackValue[0]; //bovenste kaart waarde ophalen van random lijst

        cardsStackValue.RemoveAt(0); //verwijder kaart van stack
        cardsStackKind.RemoveAt(0);  //verwijder kaart van stack

        card.getView().updateView(); //view update van de kaart
      }
    }
  }
}