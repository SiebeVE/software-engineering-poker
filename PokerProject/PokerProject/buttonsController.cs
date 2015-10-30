using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class buttonsController
  {
    // Voor le communicatie 
    private buttonsView view_buttons;
    private buttonsModel model_buttons;

    private pokerController _controllerPoker;

    // Constructor maken van buttonsController
    public buttonsController(pokerController controllerPoker)
    {
      _controllerPoker = controllerPoker;
      view_buttons = new buttonsView(this);
      model_buttons = new buttonsModel();

    }
    // Return de view van de buttons voor le communicatie
    public buttonsView getViewButtons()
    {
      return view_buttons;
    }

    /*
        Mee gaan en de gevraagde inzet betalen, evenveel chips in de pot doen als vereist.
    */
    public void Call()
    {
      _controllerPoker.getModelPoker().getCurrentPlayer().zetIn(_controllerPoker.getModelPoker().BiggestBet);
      //volgende speler
      _controllerPoker.nextPlayer();
      //Update de view met de nieuwe waarde
      //view_buttons.updateUIButton();

    }

    public pokerController getControllerPoker()
    {
      return _controllerPoker;
    }

    /*
        Passen, je hand weggooien. Men verliest hierbij de kans om de pot te winnen.
    */
    public void Fold()
    {
      _controllerPoker.getModelPoker().getCurrentPlayer().fold();
      _controllerPoker.nextPlayer();
    }

    /*
        Inzet verhogen.
    */
    public void Raise()
    {

      //model_buttons.Raise();

      //Update de view met de nieuwe waarde
      view_buttons.updateUIAllin();

    }

    /* * * * * * * * * * * * * * * * * * * * * * * * * * *

    *                G  E  T  T  E  R  S                 *

    * * * * * * * * * * * * * * * * * * * * * * * * * *  *

    *   *   *   *   *  Returns de waarde  *   *   *   *  */

  }

}
