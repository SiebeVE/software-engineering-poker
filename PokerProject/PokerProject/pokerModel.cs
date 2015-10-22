using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class pokerModel
  {
    private List<cardController> cards = new List<cardController>();
    private int numberOfPLayers = 1;

    public int NumberOfPLayers
    {
      get
      {
        return numberOfPLayers;
      }
      set
      {
        numberOfPLayers = value;
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
