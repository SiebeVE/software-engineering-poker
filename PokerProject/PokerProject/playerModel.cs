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

    private int numberOfCards = 2;

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

  }
}
