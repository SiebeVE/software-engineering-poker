using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerProject
{
  public partial class pokerView : UserControl
  {
    private pokerController _controller;

    public pokerView(pokerController controller)
    {
      _controller = controller;
      InitializeComponent();
    }

    public void initializeViewPoker()
    {
      //toevoegen knoppen speler
      buttonsController button = new buttonsController(_controller);
      buttonsView buttonView = button.getViewButtons();
      _controller.getModelPoker().View_button = buttonView;
      buttonView.Location = new Point(320, 600);
      button.getViewButtons().updateCurrentPlayer();
      buttonView.toggleDisable();
      Controls.Add(buttonView);

      //toevoegen views van spelers
      List<playerView> players = _controller.getViewsPlayers();
      List<playerController> players_rightOrder = new List<playerController>();
      List<int> xPos = new List<int>(new int[] { 20, 780, 160, 640, 300, 500 });
      List<int> yPos = new List<int>(new int[] { 20, 20, 210, 210, 400, 400, });
      int curPlayerIndex = 0;
      int curIndexAtPlace = 0;
      foreach (playerView player in players)
      {
        playerView currentPlayer = player;
        currentPlayer.Location = new Point(xPos[curPlayerIndex], yPos[curPlayerIndex]);
        Controls.Add(currentPlayer);
        curPlayerIndex++;
        if (curPlayerIndex % 2 == 0)
        {
          curIndexAtPlace++;
        }
        players_rightOrder.Insert(curIndexAtPlace, player.getControllerPlayer());
      }
      int curPlayerIndex2 = 0;
      foreach (playerController player in players_rightOrder)
      {
        curPlayerIndex2++;
        player.getModelPlayer().Name = "Speler: "+ curPlayerIndex2;
        player.getViewPlayer().updateName();
      }
      players_rightOrder[0].getModelPlayer().Special = "small";
      players_rightOrder[1].getModelPlayer().Special = "big";
      _controller.getModelPoker().Players = players_rightOrder;
      _controller.getModelPoker().IndexStopPlayer = 0;

      //toevoegen view van flop, turn, river, total pot
      playerController flop = new playerController(_controller, 5);
      /*flop.getModelPlayer().Cards[0].getModelCard().CardValue = 2;
      flop.getModelPlayer().Cards[1].getModelCard().CardValue = 3;
      flop.getModelPlayer().Cards[2].getModelCard().CardValue = 4;
      flop.getModelPlayer().Cards[3].getModelCard().CardValue = 5;
      flop.getModelPlayer().Cards[4].getModelCard().CardValue = 6;*/
      _controller.getModelPoker().FlopController = flop;
      playerView flopView = flop.getViewPlayer();
      flopView.Location = new Point(280, 20);
      Controls.Add(flopView);
      flopView.updateKapitaal();

      _controller.makeCurrent(1);
      _controller.getModelPoker().FirstGame = true;
      _controller.getModelPoker().FirstRoundOfHand = false;
      
    }
  }
}