using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
    public class buttonsController
    {
        // Voor le communicatie 
        private buttonsView view_buttons;
        private buttonsModel model_buttons;

        // Constructor maken van buttonsController
        public buttonsController()
        {

            view_buttons = new buttonsView(this);
            model_buttons = new buttonsModel();

        }

    public buttonsView getView()
    {
      return view_buttons;
    }

        // Return de view van de buttons voor le communicatie
        public buttonsView getView_buttons()
        {

            return view_buttons;

        }

        /*
            Mee gaan en de gevraagde inzet betalen, evenveel chips in de pot doen als vereist.
        */
        public void Call()
        {

            model_buttons.Call();

            //Update de view met de nieuwe waarde
            view_buttons.updateUI();

        }

        /*
            Passen, je hand weggooien. Men verliest hierbij de kans om de pot te winnen.
        */
        public void Fold()
        {

            model_buttons.Fold();

            //Update de view met de nieuwe waarde
            view_buttons.updateUI();

        }

        /*
            Inzet verhogen.
        */
        public void Raise()
        {

            model_buttons.Raise();

            //Update de view met de nieuwe waarde
            view_buttons.updateUI();
           
        }

        /* * * * * * * * * * * * * * * * * * * * * * * * * * *

        *                G  E  T  T  E  R  S                 *

        * * * * * * * * * * * * * * * * * * * * * * * * * *  *
        
        *   *   *   *   *  Returns de waarde  *   *   *   *  */

        public int ChipsPersoon {

            get
            {
                return model_buttons.ChipsPersoon;
            }

        }

        public int TeBetalenChips {

            get
            {
                return model_buttons.TeBetalenChips;
            }

        }

        public int GegevenChips {

            get
            {
                return model_buttons.GegevenChips;
            }

        }

        public bool ButtonClicked {

            get
            {
                return model_buttons.ButtonClicked;
            }

        }

    }

 }
