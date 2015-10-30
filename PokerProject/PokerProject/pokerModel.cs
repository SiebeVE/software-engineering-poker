﻿using System;
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
    private int indexCurrentPlayer;
    private playerController flopController;

    private int numberOfPLayers = 6;

    private int smallBlind = 5;
    private int bigBlind;

    private int biggestBet;
    private int indexStopPlayer;
    private bool firstGame;
    private bool firstRoundOfHand;
    private int round = 1;
    private bool newHighest = false;

    private buttonsView view_button;

    public pokerModel()
    {
      bigBlind = smallBlind * 2;
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
    public playerController getCurrentPlayer()
    {
      return players[indexCurrentPlayer];
    }

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
      set
      {
        players = value;
      }
    }
    public buttonsView View_button
    {
      get
      {
        return view_button;
      }
      set
      {
        view_button = value;
      }
    }

    public int BigBlind
    {
      get
      {
        return bigBlind;
      }
      set
      {
        bigBlind = value;
      }
    }
    public int SmallBlind
    {
      get
      {
        return smallBlind;
      }
      set
      {
        smallBlind = value;
      }
    }
    public int IndexCurrentPlayer
    {
      get
      {
        return indexCurrentPlayer;
      }
      set
      {
        indexCurrentPlayer = value;
      }
    }
    public int BiggestBet
    {
      get
      {
        return biggestBet;
      }
      set
      {
        biggestBet = value;
      }
    }
    public int IndexStopPlayer
    {
      get
      {
        return indexStopPlayer;
      }
      set
      {
        indexStopPlayer = value;
      }
    }
    public bool FirstRoundOfHand
    {
      get
      {
        return firstRoundOfHand;
      }
      set
      {
        firstRoundOfHand = value;
      }
    }
    public bool FirstGame
    {
      get
      {
        return firstGame;
      }
      set
      {
        firstGame = value;
      }
    }
    public int Round
    {
      get
      {
        return round;
      }
      set
      {
        round = value;
      }
    }
    public bool NewHighest
    {
      get
      {
        return newHighest;
      }
      set
      {
        newHighest = value;
      }
    }
  }
}