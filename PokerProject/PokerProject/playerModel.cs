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

<<<<<<< HEAD
    private int numberOfCards;
    private bool folded = true;
    private int momentelInzet = 0;

    public playerModel(int nrOfCards)
    {
      numberOfCards = nrOfCards;
    }

    public int NumberOfCards
=======
        private playerController currentPlayer;
        private buttonsView view_button;

    private int numberOfCards;
    private bool folded = true;

    private int momenteleInzet = 0;
    private int inzetPot;
    private int startKapitaal  = 500;
    private int kapitaal;

        private int smallBlind;
        private int BigBlind;

        public playerModel(int nrOfCards) {
             numberOfCards = nrOfCards;
        }


        // Call method
        public void Call() {

            if (momenteleInzet < inzetPot) {                     //momentele inzet is kleiner als de inzet de pot

                momenteleInzet = inzetPot;                       // momentele inzet is gelijk aan de inzet in de pot
                kapitaal = startKapitaal - momenteleInzet;       // berekening huidig kapitaal

            }
            else {

                view_button.updateUIButton();                    // Veranderd de UI van call naar check (hoop ik)

            }

        }

        // Fold method
        public void Fold() {

            kapitaal = startKapitaal - momenteleInzet;

            // hand weggooien

        }

        // Raise method
        public void Raise() {

            if (momenteleInzet <= inzetPot){                     //momentele inzet is kleiner of gelijk aan als de inzet de pot

                momenteleInzet = inzetPot + BigBlind;            // momentele inzet is gelijk aan de inzet in de pot + big blind
                kapitaal = startKapitaal - momenteleInzet;       // berekening huidig kapitaal

            }
            else if (kapitaal >= inzetPot) {                     // All-in knop: want eigen kapitaal is kleiner als inzet pot

                view_button.updateUIAllin();

            }

        }

        public int NumberOfCards
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69
    {
      get
      {
        return numberOfCards;
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

<<<<<<< HEAD
    public int MomentelInzet
    {
      get
      {
        return momentelInzet;
      }
      set
      {
        momentelInzet = value;
      }
    }

  }
=======
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

    }
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69
}
