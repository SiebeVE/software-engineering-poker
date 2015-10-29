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
  public partial class playerView : UserControl
  {
    private playerController _controller;
    public playerView(playerController controller)
    {
      _controller = controller;
      InitializeComponent();
    }
    private void playerView_Load(object sender, EventArgs e)
    {
      //toevoegen kaarten
      List<cardView> cards = _controller.getCardsView(); //Lijst met alle views
      int cardWidth = cards[0].Width;
      int cardHeight = cards[0].Height;
      foreach (cardView card in cards)
      {
        cardView currentCard = card;

        int xPos = cards.IndexOf(card) * cardWidth; //x positie zetten afhankelijk van index en width
        currentCard.Location = new Point(xPos, 0);

        Controls.Add(currentCard); //huidige kaart toevoegen aan view

        currentCard.updateView();
      }
      int height = cardHeight;
      if (_controller == _controller.getControllerPoker().getModelPoker().FlopController)
      {
        naam.Hide();
        curInzet.Hide();
        height += 5;
        kapitaal.Font = new Font(kapitaal.Font.Name, (kapitaal.Font.Size+5), kapitaal.Font.Style, kapitaal.Font.Unit);
      }
      else
      {
        updateName();
        naam.Location = new Point(5, height);
        height += naam.Height + 5;
        updateCurInzet();
        curInzet.Location = new Point(5, height + kapitaal.Height +5);
      }
      updateKapitaal();
      kapitaal.Location = new Point(5, height);
      
    }

    public void updateName()
    {
      naam.Text = _controller.getModelPlayer().Name;
    }
    public void updateCurInzet()
    {
      curInzet.Text = "Uw inzet: €"+_controller.getModelPlayer().MomenteleInzet;
    }

    public void updateKapitaal()
    {
      string tekstVoor;
      if (_controller == _controller.getControllerPoker().getModelPoker().FlopController)
      {
        tekstVoor = "Totaalpot: € ";
      }
      else
      {
        tekstVoor = "Uw kapitaal: € ";
      }
      kapitaal.Text = tekstVoor + _controller.getModelPlayer().Kapitaal;
    }

    public void updateBack(Color newColor)
    {
      this.BackColor = newColor;
    }

    public playerController getControllerPlayer()
    {
      return _controller;
    }
  }
}
