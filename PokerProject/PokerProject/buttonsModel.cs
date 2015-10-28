using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
<<<<<<< HEAD
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
=======
{ 

  class buttonsModel
  {
  
        private playerModel currentPlayer;
        private playerModel bigPot;
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69

        momenteleInzet = inzetPot;                       // momentele inzet is gelijk aan de inzet in de pot
        kapitaal = startKapitaal - momenteleInzet;       // berekening huidig kapitaal

<<<<<<< HEAD
      }
      else
      {

        // call button --> check button
=======
            
            
        }
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69

      }

<<<<<<< HEAD
    }

    public void Fold()
    {

      kapitaal = startKapitaal - momenteleInzet;

      // hand weggooien
=======
     
        }
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69

    }

<<<<<<< HEAD
    public void Raise()
    {

      if (momenteleInzet <= inzetPot)
      {    //momentele inzet is kleiner of gelijk aan als de inzet de pot

        momenteleInzet = inzetPot + BigBlind;            // momentele inzet is gelijk aan de inzet in de pot + big blind
        kapitaal = startKapitaal - momenteleInzet;       // berekening huidig kapitaal

      }
=======
      
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69

    }

<<<<<<< HEAD


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


=======
    /* * * * * * * * * * * * * * * * * * * * * * * * * * *
    *                G  E  T  T  E  R  S                 *
    * * * * * * * * * * * * * * * * * * * * * * * * * *  */
    
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69
  }
}