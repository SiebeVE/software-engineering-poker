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

    private int numberOfCards;
    private bool folded = true;
    private int momentelInzet = 0;

    public playerModel(int nrOfCards)
    {
      numberOfCards = nrOfCards;
    }

    public int NumberOfCards
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
}
