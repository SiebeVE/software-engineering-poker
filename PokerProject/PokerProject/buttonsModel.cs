using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  class buttonsModel
  {

    //private int alGegevenChips;
    //private int teBetalenChips;
    private int startKapitaal;
    private int kapitaal;

    private int smallBlind;
    private int BigBlind;

    private int momenteleInzet;
    private int inzetPot;


    // geen all-in button, gaat ook adhv deze variabele (denk ik)

    public buttonsModel()
    {

      startKapitaal = 500;




      /*
          Code voor de teBetalenChips telkens te verhogen bij elke ronde + extra te verhogen bij Raise()
      */

    }

    public void Call()
    {

      if (momenteleInzet < inzetPot)
      {    //momentele inzet is kleiner als de inzet de pot

        momenteleInzet = inzetPot;                       // momentele inzet is gelijk aan de inzet in de pot
        kapitaal = startKapitaal - momenteleInzet;       // berekening huidig kapitaal

      }
      else
      {

        // call button --> check button

      }

    }

    public void Fold()
    {

      kapitaal = startKapitaal - momenteleInzet;

      // hand weggooien

    }

    public void Raise()
    {

      if (momenteleInzet <= inzetPot)
      {    //momentele inzet is kleiner of gelijk aan als de inzet de pot

        momenteleInzet = inzetPot + BigBlind;            // momentele inzet is gelijk aan de inzet in de pot + big blind
        kapitaal = startKapitaal - momenteleInzet;       // berekening huidig kapitaal

      }

    }



    /* * * * * * * * * * * * * * * * * * * * * * * * * * *

    *                G  E  T  T  E  R  S                 *

    * * * * * * * * * * * * * * * * * * * * * * * * * *  */
    public int ChipsPersoon
    {

      get
      {
        return startKapitaal;
      }

    }

    public int TeBetalenChips
    {

      get
      {
        return 1;
      }

    }

    public int GegevenChips
    {

      get
      {
        return 1;
      }

    }

    public bool ButtonClicked
    {

      get
      {
        return true;
      }

    }


  }
}