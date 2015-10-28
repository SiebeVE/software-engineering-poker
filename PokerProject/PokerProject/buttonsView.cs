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
  public partial class buttonsView : UserControl
  {
    // member die de controller onthoudt
    private buttonsController controller;

    /*
        Constructor die de dependency injection van de controller opvangt
    */
    public buttonsView(buttonsController bttncontroller)
    {
      InitializeComponent();

      // Ken de controller injection toe aan de member
      controller = bttncontroller;
    }
<<<<<<< HEAD

    private void buttonView_Load(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
      /* raise */
      controller.Raise();
    }

    private void call_bttn_Click(object sender, EventArgs e)
    {
      controller.Call();
    }

    private void fold_bttn_Click(object sender, EventArgs e)
    {
      controller.Fold();
    }

    public void updateUI()
    {
=======

    private void buttonView_Load(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
      /* raise */
      controller.Raise();
    }

    private void call_bttn_Click(object sender, EventArgs e)
    {
      controller.Call();
    }

    private void fold_bttn_Click(object sender, EventArgs e)
    {
      controller.Fold();
    }

        public void updateUIButton() {
            Inzet.Text = "Check";

        }
        public void updateUIAllin() {
            raise_bttn.Text = "All in";

        }
>>>>>>> 10faf2f6086d676849d05360c67cfe09998dca69

        private void Inzet_Click(object sender, EventArgs e)
        {

    }
  }
}
