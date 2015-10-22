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
    private string cardKind = "spades";
    private int cardValue = 13;
    private bool showCard = false;

    public string CardKind
    {
      get
      {
        return cardKind;
      }
      set
      {
        cardKind = value;
      }
    }
    public int CardValue
    {
      get
      {
        return cardValue;
      }
      set
      {
        cardValue = value;
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
