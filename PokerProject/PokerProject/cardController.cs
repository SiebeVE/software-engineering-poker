using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class cardController
  {
    private cardView _view;
    private cardModel _model;

    public cardController() //constructor
    {
      _model = new cardModel();
      _view = new cardView(this); //controller injecteren in view voor 2 richtingsverkeer
      flipCard();
    }

    public cardView getView()
    {
      return _view; //view toegankelijk maken voor pokerView
    }
    public cardModel getModel()
    {
      return _model; //model toegankelijk maken voor view
    }

    public void flipCard()
    {
      _model.ShowCard = !_model.ShowCard; // omdraaien van kaard
      _view.updateView(); // updaten van view
    }

    public void changeCard(string kind, int number)
    {
      _model.CardKind = kind; //nieuwe soort kaart toewijzen
      _model.CardValue = number; //nieuwe waarde aan kaart toewijzen
      _view.updateView(); //updaten van view
    }
  }
}