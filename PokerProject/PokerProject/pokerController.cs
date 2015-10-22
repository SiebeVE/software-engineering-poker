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

    public void makeCardViews(int numberOfCards)
    {
      for (int cardNumber = 0; cardNumber < numberOfCards; cardNumber++)
      {
        cardController card = new cardController();
        cardView cardView = card.getView();
        _model.addCard(card);
        card.getView().updateView();
      }
    }
  }
}