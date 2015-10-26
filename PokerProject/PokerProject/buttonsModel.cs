using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  class buttonsModel
  {

    private int gegevenChips;
    private int teBetalenChips;
    private int chipsPersoon;
    // geen all-in button, gaat ook adhv deze variabele (denk ik)

    private bool isButtonClicked;

    public buttonsModel()
    {

      chipsPersoon = 500;
      gegevenChips = 0;

      isButtonClicked = false;

      /*
          Code voor de teBetalenChips telkens te verhogen bij elke ronde + extra te verhogen bij Raise()
      */

    }

    public void Call()
    {

      gegevenChips = teBetalenChips;

    }

    public void Fold()
    {

      gegevenChips = 0;
      teBetalenChips = 0;


    }

    public void Raise()
    {

      gegevenChips = teBetalenChips * 2;

    }

    public void ButtonIsClicked()
    {

      isButtonClicked = !isButtonClicked;

    }

    /* * * * * * * * * * * * * * * * * * * * * * * * * * *

    *                G  E  T  T  E  R  S                 *

    * * * * * * * * * * * * * * * * * * * * * * * * * *  */
    public int ChipsPersoon
    {

      get
      {
        return chipsPersoon;
      }

    }

    public int TeBetalenChips
    {

      get
      {
        return teBetalenChips;
      }

    }

    public int GegevenChips
    {

      get
      {
        return gegevenChips;
      }

    }

    public bool ButtonClicked
    {

      get
      {
        return isButtonClicked;
      }

    }


  }
}
