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
    }
  }
}
