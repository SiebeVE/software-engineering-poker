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
      _view = new cardView(this);
      _model = new cardModel();
    }

    public cardView getView()
    {
      return _view;
    }
  }
}
