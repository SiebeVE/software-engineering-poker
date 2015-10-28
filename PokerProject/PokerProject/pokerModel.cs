using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
  public class pokerModel
  {

    private List<string> cardsStackKind = new List<string>();
    private List<int> cardsStackValue = new List<int>();

    private List<playerController> players = new List<playerController>();
    private playerController flopController;

    private int numberOfPLayers = 3;
    private int maxPlayers = 6;

    public int NumberOfPlayers
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

    public playerController FlopController
    {
      get
      {
        return flopController;
      }
      set
      {
        flopController = value;
      }
    }

    public void addCardKind(string cardKind)
    {
      cardsStackKind.Add(cardKind);
    }
    public void addCardValue(int cardValue)
    {
      cardsStackValue.Add(cardValue);
    }
    public void addPlayer(playerController player)
    {
      players.Add(player);
    }

    public void removeCardKind(int index)
    {
      cardsStackKind.RemoveAt(index);
    }
    public void removeCardValue(int index)
    {
      cardsStackValue.RemoveAt(index);
    }

    public List<string> CardsStackKind
    {
      get
      {
        return cardsStackKind;
      }
    }
    public List<int> CardsStackValue
    {
      get
      {
        return cardsStackValue;
      }
    }
    public List<playerController> Players
    {
      get
      {
        return players;
      }
    }
  }
}