using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA
{
    public partial class FRM_Main : Form
    {
        //new user U
        User U = new User();

        public FRM_Main(User U_)
        {
            InitializeComponent();
            //set all values in U to the values given from U_
            U = U_;
        }

        private void FRM_Main_Load(object sender, EventArgs e)
        {
            //---language---//
            //language is english
            if (U.Language == 0)
            {
                //set objects to have english text:
                LB_Title.Text = "Main Menu";

                BTN_Game.Text = "Play Game";
                BTN_Inst.Text = "Instructions";
                BTN_AI.Text = "AI";
                BTN_Lead.Text = "Leader Board";
                BTN_Sett.Text = "Settings";
                BTN_Close.Text = "Close";

                this.Text = "Main Menu";
            }
            //language is spanish
            else if (U.Language == 1)
            {
                //set objects to have spanish text:
                LB_Title.Text = "Menú Principal";

                BTN_Game.Text = "Jugar al Juego";
                BTN_Inst.Text = "Instrucciones";
                BTN_AI.Text = "Inteligencia Artificial";
                BTN_Lead.Text = "Marcador";
                BTN_Sett.Text = "Configuración";
                BTN_Close.Text = "Cerrar";

                this.Text = "Menú Principal";
            }
            //language is japanese
            else if (U.Language == 2)
            {
                //set objects to have japanese text:
                LB_Title.Text = "メニュー";

                BTN_Game.Text = "ゲームをする";
                BTN_Inst.Text = "せつめいしょ";
                BTN_AI.Text = "じんこうちのう";
                BTN_Lead.Text = "りーだーぼーど";
                BTN_Sett.Text = "せってい";
                BTN_Close.Text = "閉じます";

                this.Text = "メニュー";
            }

            //---font size---//
            //to hold the font size
            float s = 12;
            //font size is small
            if (U.FontSize ==  0)
            {
                s = 8;
            }
            else if (U.FontSize == 1)
            {
                s = 12;
            }
            else if (U.FontSize == 2)
            {
                s = 16;
            }
            //make new font with chosen settings
            Font f = new Font(FontFamily.GenericSansSerif, s);
            LB_Title.Font = f;
            BTN_Game.Font = f;
            BTN_Inst.Font = f;
            BTN_AI.Font = f;
            BTN_Lead.Font = f;
            BTN_Sett.Font = f;
            BTN_Close.Font = f;
        }

        private void BTN_Game_Click(object sender, EventArgs e)
        {
            //hide the current form
            this.Hide();
            //show the game form
            FRM_Game frmgame = new FRM_Game(U);
            frmgame.ShowDialog();
            //when the main form closes (the user presses back), show the current form again
            this.Show();
        }

        private void BTN_Inst_Click(object sender, EventArgs e)
        {
            //hide the current form
            this.Hide();
            //show the instructions form
            FRM_Inst frminst = new FRM_Inst(U);
            frminst.ShowDialog();
            //when the main form closes (the user presses back), show the current form again
            this.Show();
        }

        private void BTN_AI_Click(object sender, EventArgs e)
        {
            //hide the current form
            this.Hide();
            //show the AI form
            FRM_AI frmai = new FRM_AI(U);
            frmai.ShowDialog();
            //when the main form closes (the user presses back), show the current form again
            this.Show();
        }

        private void BTN_Lead_Click(object sender, EventArgs e)
        {
            //hide the current form
            this.Hide();
            //show the leader board form
            FRM_Lead frmlead = new FRM_Lead(U);
            frmlead.ShowDialog();
            //when the main form closes (the user presses back), show the current form again
            this.Show();
        }

        private void BTN_Sett_Click(object sender, EventArgs e)
        {
            //hide the current form
            this.Hide();
            //show the settings form
            FRM_Sett frmsett = new FRM_Sett(U);
            frmsett.ShowDialog();
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
