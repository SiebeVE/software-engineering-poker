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
  public partial class pokerGame : Form
  {
    public pokerGame()
    {
      InitializeComponent();
    }

    private void pokerView_Load(object sender, EventArgs e)
    {
      pokerController poker = new pokerController();
      pokerView pokerView = poker.getView();
      pokerView.Location = new Point(0, 0);
      poker.makeCardViews(5);
      Controls.Add(pokerView);
    }

  }
}