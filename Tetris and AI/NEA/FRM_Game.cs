using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace NEA
{
    public partial class FRM_Game : Form
    {
        //new user U
        User U = new User();
        public FRM_Game(User U_)
        {
            InitializeComponent();
            //set all values of U to U_
            U = U_;
        }

        //an array to hold where everything is before it's displayed in the main dgv
        public string[,] grid = new string[10, 20];
        //an array to hold where everything is before it's displayed in the preview dgv
        public string[,] next = new string[4, 4];
        //boolean variable to hold whether a new piece is needed or not 
        public bool newPiece = true;
        //create the first tetrimino that will be used throughout the game
        Tetrimino a = new Tetrimino();
        //create the second tetrimino that will be used throughout the game
        Tetrimino b = new Tetrimino();
        //to hold how many combos the user has got
        int combo = 0;
        //to hold whether the user has paused the game before
        bool p = false;
        //to hold whether the game has ended
        bool end = false;

        //when the form loads
        private void FRM_Game_Load(object sender, EventArgs e)
        {
            //disable the timer
            TMR_Time.Enabled = false;

            //score, rows and level are 0 at the start
            LB_Level.Text = "0";
            LB_Rows.Text = "0";
            LB_Score.Text = "0";

            //language is english
            if (U.Language == 0)
            {
                //set objects to have english text:
                LB_Next.Text = "Next:";
                LB_S.Text = "Score:";
                LB_L.Text = "Level:";
                LB_R.Text = "Rows:";

                LB_Message.Text = "Press ESC to play game";

                Text = "Game";
            }
            //language is spanish
            else if (U.Language == 1)
            {
                //set objects to have english text:
                LB_Next.Text = "Siguiente:";
                LB_S.Text = "Puntaje:";
                LB_L.Text = "Nivel:";
                LB_R.Text = "Fila:";

                LB_Message.Text = "Press ESC to play game";

                Text = "Juego";
            }
            //language is japanese
            else if (U.Language == 2)
            {
                //set objects to have english text:
                LB_Next.Text = "ついで:";
                LB_S.Text = "とくてん:";
                LB_L.Text = "レベル:";
                LB_R.Text = "れつ:";

                LB_Message.Text = "ESCを押して再生します";

                Text = "ガーム";
            }

            //---font size---//
            //to hold the font size
            float s = 12;
            //font size is small
            if (U.FontSize == 0)
            {
                s = 8;
            }
            //medium
            else if (U.FontSize == 1)
            {
                s = 12;
            }
            //large
            else if (U.FontSize == 2)
            {
                s = 16;
            }
            //make new font with chosen settings
            Font f = new Font(FontFamily.GenericSansSerif, s);
            LB_Next.Font = f;
            LB_S.Font = f;
            LB_L.Font = f;
            LB_R.Font = f;
            LB_Score.Font = f;
            LB_Level.Font = f;
            LB_Rows.Font = f;

            //add 20 rows to the game dgv
            DGV_Game.Rows.Add(20);
            //add 4 rows to the next dgv
            DGV_Next.Rows.Add(4);
            //get rid of the highlight on both of the data grid views (will be at (0, 0) to start)
            DGV_Game.Rows[0].Cells[0].Selected = false;
            DGV_Next.Rows[0].Cells[0].Selected = false;

            //set the whole main array to empty:
            //do this 20 times
            for (int i = 0; i < 10; i++)
            {
                //do this 10 times
                for (int j = 0; j < 20; j++)
                {
                    //make each part of the array empty
                    grid[i, j] = "E";
                    //add text to each cell in the DGV_Game
                    DGV_Game.Rows[j].Cells[i].Value = "p";
                }
            }
            //set the whole next array to empty:
            //do this 4 times
            for (int i = 0; i < 4; i++)
            {
                //do this 4 times
                for (int j = 0; j < 4; j++)
                {
                    //make each part of the array empty
                    next[i, j] = "E";
                    //add text to each cell in the DGV_Next
                    DGV_Next.Rows[j].Cells[i].Value = "p";
                }
            }
            //make the tetrimino a the active tetrimino
            a.makeActive();

            //update the active piece in the main array
            grid = a.updateActivePiece(grid);
            //display the main array to the user
            displayMainArray();
            //update the next piece in the next array
            next = b.updateNextPiece(next);
            //display the next array to the user
            displayNextArray();
        }

        //ends the game
        public void endGame()
        {
            //the game has ended
            end = true;
            //disable the timer
            TMR_Time.Enabled = false;
            //bring LB_Pause to the front
            LB_Message.BringToFront();
            //make it visible 
            LB_Message.Visible = true;
            //to hold a message for the user in their chosen language
            string message1 = null;
            string message2 = null;
            //to hold the title of a message box in their chosen language
            string title = null;

            //if the language is english
            if (U.Language == 0)
            {
                //change the text of LB_Message
                LB_Message.Text = "GAME OVER\nYour score was " + LB_Score.Text + "\nPress ESC to return to the main menu";
                //hold a message for the user in their chosen language
                message1 = "Would you like to add your score to the leader board?";
                message2 = "Your score has been added to the leader board.";
                //title of the message box
                title = "Leader board";
            }
            //language is spanish
            else if (U.Language == 1)
            {
                //change the text of LB_Message
                LB_Message.Text = "GAME OVER\nYour score was " + LB_Score.Text + "\nPress ESC to return to the main menu";
                //hold a message for the user in their chosen language
                message1 = "Would you like to add your score to the leader board?";
                message2 = "Your score has been added to the leader board.";
                //title of the message box
                title = "Marcador";
            }
            //language is japanese
            else if (U.Language == 2)
            {
                //change the text of LB_Message
                LB_Message.Text = "ゲームオーバー！\nスコアは " + LB_Score.Text + "\nメインメニューに戻るためにESCを押してください";
                //hold a message for the user in their chosen language
                message1 = "スコアをリーダーボードに追加しますか？";
                message2 = " スコアがリーダーボードに追加されました";
                //title of the message box
                title = "りーだーぼーど";
            }
            //ask the user if they would like to submit their score
            DialogResult result = MessageBox.Show(message1, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if they said yes
            if (result == DialogResult.Yes)
            {
                //add their score to the leaderboard:
                //make a new DBI object
                DBI l = new DBI();
                //send the SQL statement 
                l.noReturnSQL("INSERT INTO Tb_Leaderboard([L_Score], [L_AI]) VALUES('" + Convert.ToInt32(LB_Score.Text) + "', '" + 0 + "')");
                //inform the user that their score has been added
                MessageBox.Show(message2, title);
            }
        }

        //display tetriminos in the main data grid view
        private void displayMainArray()
        {
            //if the game hasn't ended
            if (end == false)
            {
                //if colour blind mode is on
                if (U.ColourBlind == true)
                {
                    //do this 10 times
                    for (int i = 0; i < 10; i++)
                    {
                        //do this 20 times
                        for (int j = 0; j < 20; j++)
                        {
                            //if its empty
                            if (grid[i, j] == "E")
                            {
                                //set the cell background and foreground to black
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 0, 0, 0);
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 0, 0, 0);
                            }
                            //the cell contains a tetrimino piece
                            else if (grid[i, j] != "E")
                            {
                                //set the cell background to light grey
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 200, 200, 200);
                                //set the cell foreground to dark grey
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 75, 75, 75);

                                //check which piece it is 
                                if (grid[i, j] == "A0" || grid[i, j] == "P0")
                                {
                                    //set the cells text 
                                    DGV_Game.Rows[j].Cells[i].Value = "p";
                                }
                                else if (grid[i, j] == "A1" || grid[i, j] == "P1")
                                {
                                    //set the cells text
                                    DGV_Game.Rows[j].Cells[i].Value = "n";
                                }
                                else if (grid[i, j] == "A2" || grid[i, j] == "P2")
                                {
                                    //set the cells text
                                    DGV_Game.Rows[j].Cells[i].Value = "l";
                                }
                                else if (grid[i, j] == "A3" || grid[i, j] == "P3")
                                {
                                    //set the cells text
                                    DGV_Game.Rows[j].Cells[i].Value = "v";
                                }
                                else if (grid[i, j] == "A4" || grid[i, j] == "P4")
                                {
                                    //set the cells text
                                    DGV_Game.Rows[j].Cells[i].Value = "£";
                                }
                                else if (grid[i, j] == "A5" || grid[i, j] == "P5")
                                {
                                    //set the cells text
                                    DGV_Game.Rows[j].Cells[i].Value = "u";
                                }
                                else if (grid[i, j] == "A6" || grid[i, j] == "P6")
                                {
                                    //set the cells text
                                    DGV_Game.Rows[j].Cells[i].Value = "w";
                                }
                            }
                        }
                    }
                }
                //colour blind mode is off
                else
                { 
                    //to hold the user's level MOD 10
                    int lev = Convert.ToInt32(LB_Level.Text) % 10;

                    //do this 10 times
                    for (int i = 0; i < 10; i++)
                    {
                        //do this 20 times
                        for (int j = 0; j < 20; j++)
                        {
                            //if its empty
                            if (grid[i, j] == "E")
                            {
                                //if the user's level ends in 0
                                if (lev == 0)
                                {
                                    //make the cell the right colour for that level
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 0, 0, 0);
                                }
                                //if the user's level ends in 1
                                else if (lev == 1)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 250, 190, 190);
                                }
                                //if the user's level ends in 2
                                else if (lev == 2)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 255, 216, 177);
                                }
                                //if the user's level ends in 3
                                else if (lev == 3)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 255, 250, 200);
                                }
                                //if the user's level ends in 4
                                else if (lev == 4)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 170, 255, 195);
                                }
                                //if the user's level ends in 5
                                else if (lev == 5)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 230, 190, 255);
                                }
                                //if the user's level ends in 6
                                else if (lev == 6)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 240, 50, 230);
                                }
                                //if the user's level ends in 7
                                else if (lev == 7)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 188, 246, 12);
                                }
                                //if the user's level ends in 8
                                else if (lev == 8)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 128, 128, 128);
                                }
                                //if the user's level ends in 9
                                else if (lev == 9)
                                {
                                    DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                                }
                                //make the text match the background
                                DGV_Game[i, j].Style.ForeColor = DGV_Game[i, j].Style.BackColor;
                            }
                            //check which piece it is 
                            else if (grid[i, j] == "A0" || grid[i, j] == "P0")
                            {
                                //make the cell the right colour for that piece
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 255, 255, 25);
                                //make the text the right colour for that piece
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 128, 128, 0);
                            }
                            else if (grid[i, j] == "A1" || grid[i, j] == "P1")
                            {
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 70, 240, 240);
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 0, 128, 128);
                            }
                            else if (grid[i, j] == "A2" || grid[i, j] == "P2")
                            {
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 60, 180, 75);
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 170, 255, 195);
                            }
                            else if (grid[i, j] == "A3" || grid[i, j] == "P3")
                            {
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 230, 25, 75);
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 250, 190, 190);
                            }
                            else if (grid[i, j] == "A4" || grid[i, j] == "P4")
                            {
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 245, 130, 49);
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 255, 216, 177);
                            }
                            else if (grid[i, j] == "A5" || grid[i, j] == "P5")
                            {
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 67, 99, 216);
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 0, 0, 117);
                            }
                            else if (grid[i, j] == "A6" || grid[i, j] == "P6")
                            {
                                DGV_Game[i, j].Style.BackColor = Color.FromArgb(255, 145, 30, 180);
                                DGV_Game[i, j].Style.ForeColor = Color.FromArgb(255, 230, 190, 255);
                            }
                        }
                    }
                }
            }
        }

        //display the next tetrimino in the preview data grid view
        private void displayNextArray()
        {
            //if the game hasn't ended
            if (end == false)
            {
                //if colour blind mode is on
                if (U.ColourBlind == true)
                {
                    //do this 10 times
                    for (int i = 0; i < 4; i++)
                    {
                        //do this 20 times
                        for (int j = 0; j < 4; j++)
                        {
                            //if its empty
                            if (next[i, j] == "E")
                            {
                                //set the cell background and foreground to black
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 0, 0, 0);
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 0, 0, 0);
                            }
                            //the cell contains a tetrimino piece
                            else if (next[i, j] != "E")
                            {
                                //set the cell background to light grey
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 200, 200, 200);
                                //set the cell foreground to dark grey
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 75, 75, 75);

                                //check which piece it is 
                                if (next[i, j] == "A0" || next[i, j] == "P0")
                                {
                                    //set the cells text 
                                    DGV_Next.Rows[j].Cells[i].Value = "p";
                                }
                                else if (next[i, j] == "A1" || next[i, j] == "P1")
                                {
                                    //set the cells text
                                    DGV_Next.Rows[j].Cells[i].Value = "n";
                                }
                                else if (next[i, j] == "A2" || next[i, j] == "P2")
                                {
                                    //set the cells text
                                    DGV_Next.Rows[j].Cells[i].Value = "l";
                                }
                                else if (next[i, j] == "A3" || next[i, j] == "P3")
                                {
                                    //set the cells text
                                    DGV_Next.Rows[j].Cells[i].Value = "v";
                                }
                                else if (next[i, j] == "A4" || next[i, j] == "P4")
                                {
                                    //set the cells text
                                    DGV_Next.Rows[j].Cells[i].Value = "£";
                                }
                                else if (next[i, j] == "A5" || next[i, j] == "P5")
                                {
                                    //set the cells text
                                    DGV_Next.Rows[j].Cells[i].Value = "u";
                                }
                                else if (next[i, j] == "A6" || next[i, j] == "P6")
                                {
                                    //set the cells text
                                    DGV_Next.Rows[j].Cells[i].Value = "w";
                                }
                            }
                        }
                    }
                }
                //colour blind mode is off
                else
                {
                    //to hold the user's level MOD 10
                    int lev = Convert.ToInt32(LB_Level.Text) % 10;

                    //do this 4 times
                    for (int i = 0; i < 4; i++)
                    {
                        //do this 4 times
                        for (int j = 0; j < 4; j++)
                        {
                            //if its empty
                            if (next[i, j] == "E")
                            {
                                //if the user's level ends in 0
                                if (lev == 0)
                                {
                                    //make the cell the right colour for that level
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 0, 0, 0);
                                }
                                //if the user's level ends in 1
                                else if (lev == 1)
                                {
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 250, 190, 190);
                                }
                                //if the user's level ends in 2
                                else if (lev == 2)
                                {
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 255, 216, 177);
                                }
                                //if the user's level ends in 3
                                else if (lev == 3)
                                {
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 255, 250, 200);
                                }
                                //if the user's level ends in 4
                                else if (lev == 4)
                                {
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 170, 255, 195);
                                }
                                //if the user's level ends in 5
                                else if (lev == 5)
                                {
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 230, 190, 255);
                                }
                                //if the user's level ends in 6
                                else if (lev == 6)
                                {
                                    //magenta
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 240, 50, 230);
                                }
                                //if the user's level ends in 7
                                else if (lev == 7)
                                {
                                    //lime
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 188, 246, 12);
                                }
                                //if the user's level ends in 8
                                else if (lev == 8)
                                {
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 128, 128, 128);
                                }
                                //if the user's level ends in 9
                                else if (lev == 9)
                                {
                                    DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 255, 255, 255);
                                }
                                //make the text the same as the background
                                DGV_Next[i, j].Style.ForeColor = DGV_Next[i, j].Style.BackColor;
                            }
                            //check which piece it is 
                            else if (next[i, j] == "0")
                            {
                                //make it the right colour for that piece
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 255, 255, 25);
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 128, 128, 0);
                            }
                            else if (next[i, j] == "1")
                            {
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 70, 240, 240);
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 0, 128, 128);
                            }
                            else if (next[i, j] == "2")
                            {
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 60, 180, 75);
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 170, 255, 195);
                            }
                            else if (next[i, j] == "3")
                            {
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 230, 25, 75);
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 250, 190, 190);
                            }
                            else if (next[i, j] == "4")
                            {
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 245, 130, 49);
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 255, 216, 177);
                            }
                            else if (next[i, j] == "5")
                            {
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 67, 99, 216);
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 0, 0, 117);
                            }
                            else if (next[i, j] == "6")
                            {
                                DGV_Next[i, j].Style.BackColor = Color.FromArgb(255, 145, 30, 180);
                                DGV_Next[i, j].Style.ForeColor = Color.FromArgb(255, 230, 190, 255);
                            }
                        }
                    }
                }
            }
        }

        //when the timer ticks
        private void TMR_Time_Tick(object sender, EventArgs e)
        {
            //if a is active
            if (a.tStatus == 1)
            {
                tick(a, b);
            }
            //b is active
            else
            {
                tick(b, a);
            }
            //display the updated array to the user
            displayMainArray();
        }

        //give the active tetrimino and the next tetrimino
        private void tick(Tetrimino act, Tetrimino nxt)
        {
            //if active has touched the bottom or landed on a permanent  tetrimino
            if (act.touchedBottom() == true || act.checkDownCol(grid) == true)
            {
                //switch the tetriminos
                switchTetriminos(act, nxt);
                //update active in the grid
                grid = nxt.updateActivePiece(grid);
                //update and display the next array in data grid view
                next = act.updateNextPiece(next);
                //display the arrays in data grid views
                displayMainArray();
                displayNextArray();
                
            }
            //active has not touched the bottom
            else
            {
                //move active down in the grid
                act.moveDown();
                //update active in the grid
                grid = act.updateActivePiece(grid);
                //display the arrays in data grid views
                displayMainArray();
                displayNextArray();
            }
        }

        //switches the tetriminos around
        public void switchTetriminos(Tetrimino act, Tetrimino nxt)
        {
            //if the game needs to end
            if (act.touchedTop() == true)
            {
                //end the game
                endGame();
            }
            //the game does not need to end
            else
            {
                //pause the game
                TMR_Time.Enabled = false;
                //make the active tetrimino next
                grid = act.switchActive(grid);
                //if any rows are full, remove them before adding the new active tetrimino to the grid
                //update the user's score
                LB_Score.Text = (Convert.ToInt32(LB_Score.Text) + removeRows()).ToString();
                //update the user's level
                LB_Level.Text = Convert.ToString(Convert.ToInt32(LB_Rows.Text)/10);
                //make the next tetrimino active
                grid = nxt.switchNext(grid);
                //update the timer speed:
                //if the user's level is less than 15
                if (Convert.ToInt32(LB_Level.Text) < 15)
                {
                    //interval is 500 - level x 20
                    TMR_Time.Interval = 500 - Convert.ToInt32(LB_Level.Text) * 20;
                }
                //the level is 15 or more
                else
                {
                    TMR_Time.Interval = 100;
                }
                //play the game
                TMR_Time.Enabled = true;
            }
        }

        //if any rows are full, remove them and return the user's score
        public int removeRows()
        {
            //to hold the amount of rows the user has completed in this turn
            int r = 0;
            //go through each y coordinate
            for (int j = 0; j < 20; j++)
            {
                //to hold whether the row is full
                bool full = true;
                //go through each x coordinate
                for (int i = 0; i < 10; i++)
                {
                    //if the coordinate is empty
                    if (grid[i, j] == "E")
                    {
                        //the row is not full
                        full = false;
                    }
                }
                //if after going through all the x coordinates in the row j, full is still true
                if (full == true)
                {
                    //add 1 to r for this turn
                    r++;
                    //add one to rows and display to user
                    LB_Rows.Text = (Convert.ToInt32(LB_Rows.Text) + 1).ToString();

                    //--delete row j--//

                    //loop through each coordinate in row j
                    for (int i = 0; i < 10; i++)
                    {
                        //empty the space in the grid
                        grid[i, j] = "E";
                    }
                    //dislay this to the user
                    displayMainArray();

                    //--move everything down above row j--//

                    //m is y coordinates - start at 1 above j and go down (up in the grid) to 0
                    for (int m = (j - 1); m > 0; m--)
                    {
                        //n is x coordinates - go through all
                        for (int n = 0; n < 10; n++)
                        {
                            //swap (n, m) with the space underneith it:
                            grid[n, m + 1] = grid[n, m];
                            grid[n, m] = "E";
                        }
                        //dislay this to the user
                        displayMainArray();
                    }
                }
            }
            //if the user has no rows
            if (r == 0)
            {
                //no combo
                combo = 0;
                return 0;
            }
            //the user has rows
            else
            {
                //combo + 1
                combo++;
                //to hold multiplier
                int mult = 1;
                //user's combo
                if (combo == 1)
                {
                    //multilpier for that combo
                    mult = 1;
                }
                else if (combo == 2)
                {
                    mult = 3;
                }
                else if (combo == 3)
                {
                    mult = 5;
                }
                else if (combo >= 4)
                {
                    mult = 7;
                }
                //score given back is 2^r-1 x 100 x mult
                return Convert.ToInt32(Math.Pow(2, (r - 1)) * 100 * mult);
            }
        }

        //when the user clicks a cell on DGV_Game
        private void DGV_Game_SelectionChanged(object sender, EventArgs e)
        {
            //go through the whole grid
            //do 10 times
            for (int i = 0; i < 10; i++)
            {
                //do 20 times
                for (int j = 0; j < 20; j++)
                {
                    //get rid of the highlight on the main data grid view
                    DGV_Game.Rows[j].Cells[i].Selected = false;
                }
            }
        }

        private void DGV_Next_SelectionChanged(object sender, EventArgs e)
        {
            //go through the whole grid
            //do 2 times
            for (int i = 0; i < 4; i++)
            {
                //do 4 times
                for (int j = 0; j < 4; j++)
                {
                    //get rid of the highlight on the preview data grid view
                    DGV_Next.Rows[i].Cells[j].Selected = false;
                }
            }
        }

        //when a key is pressed
        private void FRM_Game_KeyDown(object sender, KeyEventArgs e)
        {
            //take the value of the 
            switch (a.tStatus)
            {
                //a is active
                case 1:
                    //call key pressed with the button pressed, active tetrimino a, next tetrimino b
                    keyPressed(e, a, b);
                    //end the case
                    break;
                //a is next or dormant, b is active
                case 0:
                case 2:
                    //call key pressed with the button pressed, active tetrimino b, next tetrimino a
                    keyPressed(e, b, a);
                    //end the case
                    break;
            }    
            //display the updated array to the user
            displayMainArray();
        }

        //when a keyboard button is pressed by the user
        public void keyPressed(KeyEventArgs e, Tetrimino act, Tetrimino nxt)
        {
            //take the value of the key pressed
            switch (e.KeyCode)
            {
                //----ESC----//
                case Keys.Escape:
                    //if the game has ended
                    if (end == true)
                    {
                        //get rid of this form
                        this.Dispose();
                    }
                    //the game is already paused
                    else if (LB_Message.Visible)
                    {
                        //send LB_Pause to the back
                        LB_Message.SendToBack();
                        //make it invisible
                        LB_Message.Visible = false;
                        //unpause the game by enabling TMR_Time
                        TMR_Time.Enabled = true;
                    }
                    //the game is active
                    else
                    {
                        //if this is the first time the user has paused the game
                        if (p == true)
                        {
                            //language is english
                            if (U.Language == 0)
                            {
                                //change the text from start the game to
                                LB_Message.Text = "GAME PAUSED\nPress ESC to unpause";
                            }
                            //language is spanish
                            else if (U.Language == 1)
                            {



                                //change the text from start the game to
                                LB_Message.Text = "spanish";
                            }
                            //language is japanese
                            else if (U.Language == 2)
                            {
                                //change the text from start the game to
                                LB_Message.Text = "一時停止を解除するにはESCを押します";
                            }
                            //this isn't the first time the user has paused anymore
                            p = false;
                        }
                        //pause the game by disabling TMR_Time
                        TMR_Time.Enabled = false;
                        //bring LB_Pause to the front
                        LB_Message.BringToFront();
                        //make it visible 
                        LB_Message.Visible = true;
                    }
                    break;

                //----E----//
                case Keys.E:
                    //if the game is not paused
                    if (TMR_Time.Enabled == true)
                    {
                        //rotate clockwise
                        act.rotate(true, false, grid);
                        //update act in the grid
                        grid = act.updateActivePiece(grid);
                    }
                    break;

                //----Q----//
                case Keys.Q:
                    //if the game is not paused
                    if (TMR_Time.Enabled == true)
                    {
                        //rotate anticlockwise
                        act.rotate(false, false, grid);
                        //update act in the grid
                        grid = act.updateActivePiece(grid);
                    }
                    break;

                //----LEFT----//
                case Keys.Left:
                    //if the game is not paused
                    if (TMR_Time.Enabled == true)
                    {
                        //if act can move left
                        if (act.checkHorizCol(false, grid) == false)
                        {
                            //move the active tetrimino down
                            act.moveLeft();
                            //update act in the grid
                            grid = act.updateActivePiece(grid);
                        }
                    }
                    //end the case
                    break;

                //----RIGHT----//
                case Keys.Right:
                    //if the game is not paused
                    if (TMR_Time.Enabled == true)
                    {
                        //if act can move right
                        if (act.checkHorizCol(true, grid) == false)
                        {
                            //move the active tetrimino down
                            act.moveRight();
                            //update act in the grid
                            grid = act.updateActivePiece(grid);
                        }
                    }
                    //end the case
                    break;

                //----DOWN----//
                case Keys.Down:
                    //if the game is not paused
                    if (TMR_Time.Enabled == true)
                    {
                        //if act can move down
                        if (act.checkDownCol(grid) == false && act.touchedBottom() == false)
                        {
                            //move the active tetrimino down
                            act.moveDown();
                            //update act and nxt in the grids
                            grid = act.updateActivePiece(grid);
                            next = nxt.updateNextPiece(next);
                        }
                        else
                        {
                            //switch the tetriminos, act has hit the bottom or an active piece
                            switchTetriminos(act, nxt);
                            //if the game hasn't ended
                            if (end == false)
                            {
                                //update active in the grid
                                grid = nxt.updateActivePiece(grid);
                                //update and display the next array in data grid view
                                next = act.updateNextPiece(next);
                            }
                        }
                    }
                    //end the case
                    break;
            }
            //display the arrays in the data grid views
            displayMainArray();
            displayNextArray();
        }
    }
}
