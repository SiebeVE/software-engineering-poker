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
    private string cardsPath = "../cardsImages/";
    private string cardsExtension = ".png";

    public cardView(cardController controller)
    {
      _controller = controller;
      InitializeComponent();
      var cardName = "back";
      cardPicture.ImageLocation = cardsPath + cardName + cardsExtension;
      cardPicture.SizeMode = PictureBoxSizeMode.AutoSize;
    }
  }
}
