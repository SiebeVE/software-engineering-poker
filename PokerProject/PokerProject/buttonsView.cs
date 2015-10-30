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
      if (call_bttn.Text == "Check\r\n")
      {
        toggleCheck();
      }
      omdraaienCardsHuidige();
      controller.Raise(roundNumber(inzet.Value));
    }

    private void call_bttn_Click(object sender, EventArgs e)
    {
      controller.getControllerPoker().endGame();
      /*omdraaienCardsHuidige();
      controller.Call();*/
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
      roundNumber(inzet.Value);
      if (inzet.Value == inzet.Maximum)
      {
        raise_bttn.Text = "All-in\r\n";
      }
      else
      {
        raise_bttn.Text = "Raise\r\n";
      }
    }

    public void toggleRaise()
    {
      if (raise_bttn.Text == "Raise\r\n")
      {
        raise_bttn.Text = "Bet\r\n";
      }
      else
      {
        int test = controller.getControllerPoker().getModelPoker().IndexCurrentPlayer;
        int test2 = controller.getControllerPoker().getModelPoker().IndexStopPlayer;
        raise_bttn.Text = "Raise\r\n";
      }
    }

    public int roundNumber(decimal number)
    {
      if (!(number % 1 == 0))
      {
        //getal is decimaal, afronden
        number = Math.Round(number);
      }
      return (int)number;
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

    public void changeBoundriesRaise(int min, int max)
    {
      inzet.Minimum = min;
      inzet.Maximum = max;
    }
  }
}
