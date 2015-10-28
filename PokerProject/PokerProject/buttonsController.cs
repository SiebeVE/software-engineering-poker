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

    // Constructor maken van buttonsController
    public buttonsController()
    {

      view_buttons = new buttonsView(this);
      model_buttons = new buttonsModel();

    }
    // Return de view van de buttons voor le communicatie
    public buttonsView getViewButtons()
    {
      return view_buttons;
    }
<<<<<<< HEAD

    /*
        Mee gaan en de gevraagde inzet betalen, evenveel chips in de pot doen als vereist.
    */
    public void Call()
    {

      model_buttons.Call();

      //Update de view met de nieuwe waarde
      view_buttons.updateUI();

    }
=======

    /*
        Mee gaan en de gevraagde inzet betalen, evenveel chips in de pot doen als vereist.
    */
    public void Call()
    {

      model_buttons.Call();

            //Update de view met de nieuwe waarde
            view_buttons.updateUIButton();
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69

    /*
        Passen, je hand weggooien. Men verliest hierbij de kans om de pot te winnen.
    */
    public void Fold()
    {

<<<<<<< HEAD
      model_buttons.Fold();

      //Update de view met de nieuwe waarde
      view_buttons.updateUI();

    }

    /*
        Inzet verhogen.
    */
    public void Raise()
    {

      model_buttons.Raise();

      //Update de view met de nieuwe waarde
      view_buttons.updateUI();

    }

    /* * * * * * * * * * * * * * * * * * * * * * * * * * *

    *                G  E  T  T  E  R  S                 *

    * * * * * * * * * * * * * * * * * * * * * * * * * *  *

    *   *   *   *   *  Returns de waarde  *   *   *   *  */

    public int ChipsPersoon
    {

      get
      {
        return model_buttons.ChipsPersoon;
      }

    }

    public int TeBetalenChips
    {

      get
      {
        return model_buttons.TeBetalenChips;
      }

    }

    public int GegevenChips
    {

      get
      {
        return model_buttons.GegevenChips;
      }

    }

    public bool ButtonClicked
    {

      get
      {
        return model_buttons.ButtonClicked;
      }
=======
    /*
        Passen, je hand weggooien. Men verliest hierbij de kans om de pot te winnen.
    */
    public void Fold()
    {

      model_buttons.Fold();

            //Update de view met de nieuwe waarde
            

    }

    /*
        Inzet verhogen.
    */
    public void Raise()
    {

      model_buttons.Raise();

      //Update de view met de nieuwe waarde
      view_buttons.updateUIAllin();

    }

    /* * * * * * * * * * * * * * * * * * * * * * * * * * *

    *                G  E  T  T  E  R  S                 *

    * * * * * * * * * * * * * * * * * * * * * * * * * *  *

    *   *   *   *   *  Returns de waarde  *   *   *   *  */

    

    /* public int Kapitaal
        {

      get
      {
        return model_buttons.Kapitaal;
      }

    }

    public int GegevenChips
    {

      get
      {
        return model_buttons.GegevenChips;
      }

    }

    */
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69

  }

<<<<<<< HEAD
  }

=======
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69
}
