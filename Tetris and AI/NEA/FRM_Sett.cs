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
    public partial class FRM_Sett : Form
    {
        //new user U
        User U = new User();

        public FRM_Sett(User U_)
        {
            InitializeComponent();
            //U = U_
            U = U_;
        }

        private void FRM_Sett_Load(object sender, EventArgs e)
        {
            //whatever language the user chooses, the language options will be the same:
            CBX_Lang.Items.Add("English");
            CBX_Lang.Items.Add("日本語");
            CBX_Lang.Items.Add("Español");

            //language is english
            if (U.Language == 0)
            {
                //---set objects to have english text---//
                LB_Title.Text = "Settings";

                BTN_Back.Text = "Back";
                BTN_Play.Text = "Play";
                BTN_Save.Text = "Save";

                LB_Lang.Text = "Language:";
                LB_Size.Text = "Font Size:";
                LB_Colour.Text = "Colour Blind Mode:";

                this.Text = "Settings";

                //---add english options to the combo boxes---//
                //colour blind mode
                CBX_Colour.Items.Add("On");
                CBX_Colour.Items.Add("Off");
                //sizes
                CBX_Size.Items.Add("Small");
                CBX_Size.Items.Add("Medium");
                CBX_Size.Items.Add("Large");

                //---display the settings the user has already chosen---//
                //display english
                CBX_Lang.Text = "English";

                //if font size is small
                if (U.FontSize == 0)
                {
                    CBX_Size.Text = "Small";
                }
                //if font size is medium
                else if (U.FontSize == 1)
                {
                    CBX_Size.Text = "Medium";
                }
                //if font size is large
                else if (U.FontSize == 2)
                {
                    CBX_Size.Text = "Large";
                }

                //if colour blind is on
                if (U.ColourBlind == true)
                {
                    CBX_Colour.Text = "On";
                }
                //colour blind is false
                else
                {
                    CBX_Colour.Text = "Off";
                }
            }
            //language is Spanish
            else if (U.Language == 1)
            {
                //---set objects to have spanish text---//
                LB_Title.Text = "Configuración";

                BTN_Back.Text = "De Regreso";
                BTN_Play.Text = "Jugar";
                BTN_Save.Text = "Guardar";

                LB_Lang.Text = "Idioma:";
                LB_Size.Text = "Tamaño do Funte:";
                LB_Colour.Text = "Modo Daltónico:";

                this.Text = "Configuración";

                //---add spanish options to the combo boxes---//
                //colour blind mode
                CBX_Colour.Items.Add("Encendido");
                CBX_Colour.Items.Add("Apagar");
                //sizes
                CBX_Size.Items.Add("Peqeño");
                CBX_Size.Items.Add("Mediano");
                CBX_Size.Items.Add("Grande");

                //---display the settings the user has already chosen---//
                //display spanish
                CBX_Lang.Text = "Español";

                //if font size is small
                if (U.FontSize == 0)
                {
                    CBX_Size.Text = "Peqeño";
                }
                //if font size is medium
                else if (U.FontSize == 1)
                {
                    CBX_Size.Text = "Mediano";
                }
                //if font size is large
                else if (U.FontSize == 2)
                {
                    CBX_Size.Text = "Grande";
                }

                //if colour blind is on
                if (U.ColourBlind == true)
                {
                    CBX_Colour.Text = "Encendido";
                }
                //colour blind is false
                else
                {
                    CBX_Colour.Text = "Apagar";
                }
            }
            //language is Japanese
            else if (U.Language == 2)
            {
                //---set objects to have japanese text---//
                LB_Title.Text = "せってい";

                BTN_Back.Text = "かえる";
                BTN_Play.Text = "あそぶ";
                BTN_Save.Text = "セーブ";

                LB_Lang.Text = "語:";
                LB_Size.Text = "フォントサイズ:";
                LB_Colour.Text = "しきかくいじょう:";

                this.Text = "せってい";

                //---add japanese options to the combo boxes---//
                //colour blind mode
                CBX_Colour.Items.Add("かっせいかする");
                CBX_Colour.Items.Add("けす");
                //sizes
                CBX_Size.Items.Add("こがた");
                CBX_Size.Items.Add("ちゅうがた");
                CBX_Size.Items.Add("おおがた");

                //---display the settings the user has already chosen---//
                //display japanese
                CBX_Lang.Text = "日本語";

                //if font size is small
                if (U.FontSize == 0)
                {
                    CBX_Size.Text = "こがた";
                }
                //if font size is medium
                else if (U.FontSize == 1)
                {
                    CBX_Size.Text = "ちゅうがた";
                }
                //if font size is large
                else if (U.FontSize == 2)
                {
                    CBX_Size.Text = "おおがた";
                }

                //if colour blind is on
                if (U.ColourBlind == true)
                {
                    CBX_Colour.Text = "かっせいかする";
                }
                //colour blind is false
                else
                {
                    CBX_Colour.Text = "けす";
                }
            }

            //---font size---//
            //to hold the font size
            float s = 12;
            //font size is small
            if (U.FontSize == 0)
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
            BTN_Back.Font = f;
            BTN_Play.Font = f;
            LB_Title.Font = f;
            BTN_Save.Font = f;
            LB_Lang.Font = f;
            LB_Size.Font = f;
            LB_Colour.Font = f;
            CBX_Colour.Font = f;
            CBX_Size.Font = f;
            CBX_Lang.Font = f;
        }

        //when the user clicks back
        private void BTN_Back_Click(object sender, EventArgs e)
        {
            //hide the current form
            this.Hide();
            //show the main menu form
            FRM_Main frmmain = new FRM_Main(U);
            frmmain.ShowDialog();
            //when the main menu closes, dispose of this form
            this.Dispose();
        }

        //when the user clicks play
        private void BTN_Play_Click(object sender, EventArgs e)
        {
            //hide the current form
            this.Hide();
            //show the game form
            FRM_Game frmgame = new FRM_Game(U);
            frmgame.ShowDialog();
            //when the main form closes (the user presses back), show the current form again
            this.Show();
        }

        //when the user clicks save
        private void BTN_Save_Click(object sender, EventArgs e)
        {
            //---language---//
            //if the user chose english
            if (CBX_Lang.Text == "English")
            {
                //set language to english
                U.Language = 0;
            }
            //if the user chose spanish
            else if (CBX_Lang.Text == "Español")
            {
                //set language to spanish
                U.Language = 1;
            }
            //if the user chose japanese
            else if (CBX_Lang.Text == "日本語")
            {
                //set language to japanese
                U.Language = 2;
            }

            //---colour blind mode---//
            //if the user chose on
            if (CBX_Colour.Text == "On" || CBX_Colour.Text == "Encendido" || CBX_Colour.Text == "かっせいかする")
            {
                //set colour blind to on
                U.ColourBlind = true;
            }
            //the user chose off
            else
            {
                //set colour blind to off
                U.ColourBlind = false;
            }

            //---font size---//
            //if the user chose small
            if (CBX_Size.Text == "Small" || CBX_Colour.Text == "Peqeño" || CBX_Colour.Text == "こがた")
            {
                //set font size to small
                U.FontSize = 0;
            }
            //if the user chose large
            else if (CBX_Size.Text == "Large" || CBX_Colour.Text == "Grande" || CBX_Colour.Text == "おおがた")
            {
                // set font size to large
                U.FontSize = 2;
            }
            //the user chose medium (default)
            else
            {
                // set font size to medium
                U.FontSize = 1;
            }
            //inform the user their settings have been saved
            MessageBox.Show("Save Successful");
        }
    }
}
