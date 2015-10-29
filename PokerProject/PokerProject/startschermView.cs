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
    public partial class startschermView : UserControl
    {
        private startschermController _controller;

        public startschermView(startschermController controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        




        private void startschermView_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    
       

        private void startButton_Click(object sender, EventArgs e)
        {
           // List<startschermView> cards = _controller.getCardsView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
