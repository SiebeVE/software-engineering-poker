using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class cardModel
  {
    private string cardsPath = "../cardsImages/";
    private string cardsExtension = ".png";
    private string cardName = "spades8";
    private bool showCard = false;

    public string CardName
    {
      get
      {
        return cardName;
      }
      set
      {
        cardName = value;
      }
    }
    public string CardsExtension
    {
      get
      {
        return cardsExtension;
      }
      set
      {
        cardsExtension = value;
      }
    }
    public string CardsPath
    {
      get
      {
        return cardsPath;
      }
      set
      {
        cardsPath = value;
      }
    }
    public bool ShowCard
    {
      get
      {
        return showCard;
      }
      set
      {
        showCard = value;
      }
    }
  }
}
