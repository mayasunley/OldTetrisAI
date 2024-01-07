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
    public partial class FRM_Inst : Form
    {
        //new user U
        User U = new User();

        public FRM_Inst(User U_)
        {
            InitializeComponent();
            //set all values in U to the values given from U_
            U = U_;
        }

        private void FRM_Inst_Load(object sender, EventArgs e)
        {
            //language is english
            if (U.Language == 0)
            {
                //set objects to have english text:
                LB_Title.Text = "How To Play";

                BTN_Back.Text = "Back";
                BTN_Play.Text = "Play";

                this.Text = "How To Play";

                TBX_Inst.Text = "Move the tetriminos left, right and down with the arrow keys on the keyboard.\r\n\r\nRotate the tetriminos clockwise with the 'E' key and anticlockwise with the 'Q' key.\r\n\r\nComplete rows to increase your score and level - every 10 rows you complete increases your level by 1, which also speeds up the falling tetriminos.\r\n\r\nThe more rows you complete at once gets you more points.\r\n\r\nThe next tetrimino is shown in the smaller grid to the right of the main game.\r\n\r\nThe game ends when you hit the top of the grid.\r\n\r\nGood Luck!";
            }
            //language is spanish
            else if (U.Language == 1)
            {
                LB_Title.Text = "Cómo Jugar";

                BTN_Back.Text = "De Regreso";
                BTN_Play.Text = "Jugar";

                this.Text = "Cómo Jugar";

                TBX_Inst.Text = "";
            }
            //language is japanese
            else if (U.Language == 2)
            {
                LB_Title.Text = "あそびかた";

                BTN_Back.Text = "かえる";
                BTN_Play.Text = "あそぶ";

                this.Text = "あそびかた";

                TBX_Inst.Text = "キーボードの矢印キーでテトリミノを左、右、下に動かします。\r\n\r\nテトリミノを「E」キーで時計回りに、「Q」キーで反時計回りに回転させます。\r\n\r\n1列をテトリミノで埋めて消すことで、スコアとレベルを上げます - 10列消すごとにレベルが1ずつ増加し、落下するテトリミノも高速化します。\r\n\r\n 一度に消す行が増えると、より多くのポイントを獲得できます。\r\n\r\n 次のテトリミノは、メインゲームの右側にある小さなグリッドに表示されます。\r\n\r\nグリッドの一番上に到達すると、ゲームは終了します。\r\n\r\n 幸運を！";
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
            LB_Title.Font = f;
            BTN_Back.Font = f;
            BTN_Play.Font = f;
            TBX_Inst.Font = f;
        }

        private void BTN_Back_Click(object sender, EventArgs e)
        {
            //close this form, displaying the last form 
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
    }
}
