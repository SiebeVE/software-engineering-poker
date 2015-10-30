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
    private playerController _controllerPlayer;

    public cardController(playerController controller) //constructor
    {
      _controllerPlayer = controller;
      _model = new cardModel();
      _view = new cardView(this); //controller injecteren in view voor 2 richtingsverkeer
    }

    public cardView getViewCard()
    {
      return _view; //view toegankelijk maken voor pokerView
    }
    public cardModel getModelCard()
    {
      return _model; //model toegankelijk maken voor view
    }

    public playerController getControllerPlayer()
    {
      return _controllerPlayer; //controller toegankelijk maken voor view
    }

    public void flipCard()
    {
      _model.ShowCard = true; // omdraaien van kaard
      _view.updateView(); // updaten van view
    }

    public void foldCard()
    {
      _model.ShowCard = !_model.ShowCard; // omdraaien van kaart
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