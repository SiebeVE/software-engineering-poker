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
  }
}
