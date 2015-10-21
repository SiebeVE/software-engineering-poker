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
      _view = new cardView(this);
      flipCard();
    }

    public cardView getView()
    {
      return _view;
    }
    public cardModel getModel()
    {
      return _model;
    }

    public void flipCard()
    {
      _model.ShowCard = !_model.ShowCard;
      _view.updateView();
    }
  }
}