using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class playerModel
  {
    private List<cardController> cards = new List<cardController>();

    private string name = "test";

    private bool current = false;

    private int numberOfCards;
    private bool folded = false;

    private int momenteleInzet = 0;
    private int inzetPot;
    private int startKapitaal = 500;
    private int kapitaal;

    private string special;

    private playerController _controllerPlayer;

    public playerModel(int nrOfCards, playerController controller)
    {
      _controllerPlayer = controller;
      numberOfCards = nrOfCards;
      kapitaal = startKapitaal;
    }


    // Call method
    public void Call()
    {

      if (momenteleInzet < inzetPot)
      {                     //momentele inzet is kleiner als de inzet de pot

        momenteleInzet = inzetPot;                       // momentele inzet is gelijk aan de inzet in de pot
        kapitaal = startKapitaal - momenteleInzet;       // berekening huidig kapitaal

      }
      else
      {

        _controllerPlayer.getControllerPoker().getModelPoker().View_button.updateUIButton();                    // Veranderd de UI van call naar check (hoop ik)

      }

    }

    // Fold method
    public void Fold()
    {

      kapitaal = startKapitaal - momenteleInzet;

      // hand weggooien

    }

    // Raise method
    public void Raise()
    {

      if (momenteleInzet <= inzetPot)
      {                     //momentele inzet is kleiner of gelijk aan als de inzet de pot

        momenteleInzet = inzetPot + _controllerPlayer.getControllerPoker().getModelPoker().BigBlind;            // momentele inzet is gelijk aan de inzet in de pot + big blind
        kapitaal = startKapitaal - momenteleInzet;       // berekening huidig kapitaal

      }
      else if (kapitaal >= inzetPot)
      {                     // All-in knop: want eigen kapitaal is kleiner als inzet pot

        _controllerPlayer.getControllerPoker().getModelPoker().View_button.updateUIAllin();

      }

    }
    public void addCard(cardController card)
    {
      cards.Add(card);
    }

    public List<cardController> Cards
    {
      get
      {
        return cards;
      }
    }
    public bool Folded
    {
      get
      {
        return folded;
      }
      set
      {
        folded = value;
      }
    }
    public int NumberOfCards
    {
      get
      {
        return numberOfCards;
      }
    }
    public int MomenteleInzet
    {
      get
      {
        return momenteleInzet;
      }
      set
      {
        momenteleInzet = value;
      }
    }
    public int ChipsPersoon
    {

      get
      {
        return startKapitaal;
      }
      set
      {
        startKapitaal = value;
      }

    }
    public int StartKapitaal
    {

      get
      {
        return startKapitaal;
      }
      set
      {
        startKapitaal = value;
      }

    }
    public int Kapitaal
    {

      get
      {
        return kapitaal;
      }
      set
      {
        kapitaal = value;
      }

    }
    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        name = value;
      }
    }
    public string Special
    {
      get
      {
        return special;
      }
      set
      {
        special = value;
      }
    }
    public bool Current
    {
      get
      {
        return current;
      }
      set
      {
        current = value;
      }
    }
  }
}
