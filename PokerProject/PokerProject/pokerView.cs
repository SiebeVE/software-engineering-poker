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
      foreach (playerView player in players)
      {
        playerView currentPlayer = player;

        currentPlayer.Location = new Point(0, 0);

        Controls.Add(currentPlayer);
      }

      //toevoegen view van flop, turn, river, total pot

      //toevoegen knoppen speler
      buttonsController button = new buttonsController();
      buttonsView buttonView = button.getViewButtons();
      buttonView.Location = new Point(0, 200 + 5);
      Controls.Add(buttonView);
    }
  }
}