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
  public partial class cardView : UserControl
  {
    private cardController _controller;
    private cardModel _model;

    public cardView(cardController controller)
    {
      _controller = controller;
      _model = _controller.getModel();

      InitializeComponent();
      updateView();
    }

    public void updateView()
    {
      string cardName;
      if (_model.ShowCard)
      {
        cardName = _model.CardKind + _model.CardValue;
      }
      else
      {
        cardName = "back";
      }
      cardPicture.ImageLocation = _model.CardsPath + cardName + _model.CardsExtension;
      cardPicture.SizeMode = PictureBoxSizeMode.AutoSize;
    }

        private void cardPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
