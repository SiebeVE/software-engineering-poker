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
    private void buttonView_Load(object sender, EventArgs e)
    {

    }

    private void raise_Click(object sender, EventArgs e)
    {
      controller.Raise();
    }

    private void call_bttn_Click(object sender, EventArgs e)
    {
      omdraaienCardsHuidige();
      controller.Call();
    }

    private void fold_bttn_Click(object sender, EventArgs e)
    {
      controller.Fold();
    }

    public void updateUIButton()
    {
      //Inzet.Text = "Check";

    }
    public void updateUIAllin()
    {
      raise_bttn.Text = "All in";

    }

    public void updateCurrentPlayer()
    {
      currentPlayer.Text = "Huidige speler: " + controller.getControllerPoker().getModelPoker().getCurrentPlayer().getModelPlayer().Name;
    }

    public void toggleDisable()
    {
      //omdraaien of enabled van alle knoppen en velden
      call_bttn.Enabled = !call_bttn.Enabled;
      showCards.Enabled = !showCards.Enabled;
      fold_bttn.Enabled = !fold_bttn.Enabled;
      raise_bttn.Enabled = !raise_bttn.Enabled;
      inzet.Enabled = !inzet.Enabled;
    }

    public void omdraaienCardsHuidige()
    {
      //terug omdraaien van enable knoppen
      toggleDisable();
      //ophalen controller huidige speler
      playerController curPlayerController = controller.getControllerPoker().getModelPoker().getCurrentPlayer();
      //tonen kaarten van huidige speler
      List<cardView> kaarten = curPlayerController.getCardsView();
      foreach (cardView kaart in kaarten)
      {
        kaart.getControllerCard().flipCard();
      }
    }

    private void showCards_Click(object sender, EventArgs e)
    {
      omdraaienCardsHuidige();
    }

    private void inzet_ValueChanged(object sender, EventArgs e)
    {
      if (!(inzet.Value % 1 == 0))
      {
        //getal is decimaal, afronden
        inzet.Value = Math.Round(inzet.Value);
      }
    }

    public void toggleCheck()
    {
      if (call_bttn.Text == "Call\r\n")
      {
        call_bttn.Text = "Check\r\n";
      }
      else
      {
        call_bttn.Text = "Call\r\n";
      }
    }

    public string getTextButton()
    {
      return call_bttn.Text;
    }
  }
}
