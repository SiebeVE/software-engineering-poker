using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerProject
{
  public partial class pokerView : Form
  {
    public pokerView()
    {
      InitializeComponent();

      //toevoegen yathzee
      cardController card = new cardController();
      cardView cardView = card.getView();
      cardView.Location = new Point(0, 0);
      //card.initialize();
      Controls.Add(cardView);
    }

        private void pokerView_Load(object sender, EventArgs e)
        {
            // Beginwaarde, hoeveel kaarten er zijn
          /*  int aantalKaarten = 1; */

            // Alle kaarten in een lijst opvangen
            List<pokerController> kaarten = new List<pokerController>();

            // Instanties maken van de kaarten
           /* for (int k_length = 0; k_length < aantalKaarten; ++k_length) {



            } */
        }
    }
}
