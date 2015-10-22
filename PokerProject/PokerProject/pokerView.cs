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
      //toevoegen kaarten
      List<cardView> cards = _controller.getCardsView(); //Lijst met alle views
      int cardWidth = cards[0].Width;
      int cardHeight = cards[0].Height;
      foreach (cardView card in cards)
      {
        cardView currentCard = card;

        int xPos = cards.IndexOf(card) * cardWidth; //x positie zetten afhankelijk van index en width
        currentCard.Location = new Point(xPos, 0);

        Controls.Add(currentCard); //huidige teerling toevoegen aan view

        currentCard.updateView();
      }

      //toevoegen knoppen speler
      buttonsController button = new buttonsController();
      buttonsView buttonView = button.getView();
      buttonView.Location = new Point(0, cardHeight + 5);
      Controls.Add(buttonView);
    }
  }
}