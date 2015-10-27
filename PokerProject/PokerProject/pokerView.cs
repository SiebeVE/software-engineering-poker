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

    private void pokerView_Load(object sender, EventArgs e)
    {
      //toevoegen views van spelers
      List<playerView> players = _controller.getViewsPlayers();
      List<int> xPos = new List<int>(new int[] { 20,780,160,640,300,500 });
      List<int> yPos = new List<int>(new int[] { 20,20,210,210,400,400, });
      int curPlayerIndex = 0;
      foreach (playerView player in players)
      {
        playerView currentPlayer = player;
        currentPlayer.Location = new Point(xPos[curPlayerIndex], yPos[curPlayerIndex]);
        Controls.Add(currentPlayer);
        curPlayerIndex++;
      }

      //toevoegen view van flop, turn, river, total pot
      playerController flop = new playerController(_controller, 5);
      _controller.getModelPoker().FlopController = flop;
      playerView flopView = flop.getViewPlayer();
      flopView.Location = new Point(280, 20);
      Controls.Add(flopView);

      //toevoegen knoppen speler
      buttonsController button = new buttonsController();
      buttonsView buttonView = button.getViewButtons();
      buttonView.Location = new Point(320, 600);
      Controls.Add(buttonView);
    }
  }
}