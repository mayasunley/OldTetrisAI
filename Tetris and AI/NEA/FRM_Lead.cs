using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA
{
    public partial class FRM_Lead : Form
    {
        //new user U
        User U = new User();

        public FRM_Lead(User U_)
        {
            InitializeComponent();            
            //U = U_
            U = U_;
        }

        private void FRM_Lead_Load(object sender, EventArgs e)
        {
            //language is english
            if (U.Language == 0)
            {
                //set objects to have english text:
                CBX_Show.Items.Add("All");
                CBX_Show.Items.Add("AI");
                CBX_Show.Items.Add("Player");

                BTN_Back.Text = "Back";
                BTN_Play.Text = "Play";

                LB_Show.Text = "Show:";

                this.Text = "Leader Board";
            }
            //language is spanish
            else if (U.Language == 1)
            {
                //set objects to have spanish text:
                CBX_Show.Items.Add("Todo");
                CBX_Show.Items.Add("Inteligencia Artificial");
                CBX_Show.Items.Add("Jugador");

                BTN_Back.Text = "De Regreso";
                BTN_Play.Text = "Jugar";

                LB_Show.Text = "Mostrar:";

                this.Text = "Marcador";
            }
            //language is japanese
            else if (U.Language == 2)
            {
                //set objects to have japanese text:
                CBX_Show.Items.Add("すべて");
                CBX_Show.Items.Add("じんこうちのう");
                CBX_Show.Items.Add("せんしゅ");

                BTN_Back.Text = "かえる";
                BTN_Play.Text = "あそぶ";

                LB_Show.Text = "みせる:";

                this.Text = "りーだーぼーど";
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
            CBX_Show.Font = f;
            DGV_Lead.Font = f;
            BTN_Back.Font = f;
            BTN_Play.Font = f;
            LB_Show.Font = f;

            //default to display all data
            display();
        }

        //displays the relevent data in DGV_
        private void display()
        {
            //new DBI object
            DBI l = new DBI();
            //empty data table
            DataTable D = new DataTable();

            //if selection is player
            if (CBX_Show.Text == "Player" || CBX_Show.Text == "Jugador" || CBX_Show.Text == "せんしゅ")
            {
                //get data with this SQL statement
                D = l.returnSQL("SELECT TOP 10 [L_Score], [L_AI], [L_ID] FROM [Tb_Leaderboard] WHERE [L_AI] = 0 ORDER BY [L_Score] DESC");
            }
            //if selection is AI
            else if (CBX_Show.Text == "AI" || CBX_Show.Text == "Inteligencia Artificial" || CBX_Show.Text == "じんこうちのう")
            {
                //get data with this SQL statement
                D = l.returnSQL("SELECT TOP 10 [L_Score], [L_AI], [L_ID] FROM [Tb_Leaderboard] WHERE [L_AI] = -1 ORDER BY [L_Score] DESC");
            }
            //if selection is all or blank
            else
            {
                //get data with this SQL statement
                D = l.returnSQL("SELECT TOP 10 [L_Score], [L_AI], [L_ID] FROM [Tb_Leaderboard] ORDER BY [L_Score] DESC");
            }
            //display the data selected
            DGV_Lead.DataSource = D;
            //---column headers:
            //if language is english
            if (U.Language == 0)
            {
                //score
                DGV_Lead.Columns[0].HeaderText = "Score";
                //AI
                DGV_Lead.Columns[1].HeaderText = "AI";
                //ID
                DGV_Lead.Columns[2].HeaderText = "ID";
            }
            //language is spanish
            else if (U.Language == 1)
            {
                //score
                DGV_Lead.Columns[0].HeaderText = "Putaje";
                //AI
                DGV_Lead.Columns[1].HeaderText = "Inteligencia Artificial";
                //ID
                DGV_Lead.Columns[2].HeaderText = "Identificación";
            }
            //language is japanese
            else if (U.Language == 2)
            {
                //score
                DGV_Lead.Columns[0].HeaderText = "とくてん";
                //AI
                DGV_Lead.Columns[1].HeaderText = "じんこうちのう";
                //ID
                DGV_Lead.Columns[2].HeaderText = "しきべつ";
            }
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            //close this form and display the last form
            this.Close();
        }

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

        //when the user changes their selection
        private void CBX_Show_SelectedIndexChanged(object sender, EventArgs e)
        {
            //display the data they have chosen
            display();
        }
    }
}
