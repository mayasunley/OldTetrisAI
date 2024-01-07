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
    public partial class FRM_AI : Form
    {
        //new user U
        User U = new User();

        public FRM_AI(User U_)
        {
            InitializeComponent();
            //set all values in U to the values given from U_
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
        //to hold whether the game has ended
        bool end = false;

        private void FRM_AI_Load(object sender, EventArgs e)
        {
            //language is english
            if (U.Language == 0)
            {
                //set objects to have english text:
                LB_Next.Text = "Next:";

                LB_S.Text = "Score:";
                LB_L.Text = "Level:";
                LB_R.Text = "Rows:";

                LB_Score.Text = "0";
                LB_Level.Text = "0";
                LB_Rows.Text = "0";

                BTN_Start.Text = "Start";
                BTN_End.Text = "End";

                this.Text = "AI";
            }
            //language is spanish
            else if (U.Language == 1)
            {
                //set objects to have spanish text:
                LB_Next.Text = "Siguiente:";

                LB_S.Text = "Puntaje:";
                LB_L.Text = "Nivel:";
                LB_R.Text = "Fila:";

                LB_Score.Text = "0";
                LB_Level.Text = "0";
                LB_Rows.Text = "0";

                BTN_Start.Text = "Empezar";
                BTN_End.Text = "Finalizar";

                this.Text = "Inteligencia Artificial";
            }        
            //language is japanese
            else if (U.Language == 2)
            {
                //set objects to have japanese text:
                LB_Next.Text = "ついで:";

                LB_S.Text = "とくてん:";
                LB_L.Text = "レベル:";
                LB_R.Text = "れつ:";

                LB_Score.Text = "0";
                LB_Level.Text = "0";
                LB_Rows.Text = "0";

                BTN_Start.Text = "はじめ";
                BTN_End.Text = "とめる";

                this.Text = "じんこうちのう";
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
            LB_Next.Font = f;
            LB_S.Font = f;
            LB_L.Font = f;
            LB_R.Font = f;
            LB_Score.Font = f;
            LB_Level.Font = f;
            LB_Rows.Font = f;
            BTN_Start.Font = f;
            BTN_End.Font = f;

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
            //to hold a message for the user in their chosen language
            string message = null;
            //to hold the title of a message box in their chosen language
            string title = null;

            //if the language is english
            if (U.Language == 0)
            {
                //hold a message for the user in their chosen language
                message = "GAME OVER\nThe AI's score was " + LB_Score.Text + "\nThe score has been added to the leader board\nPress ESC to return to the main menu";
                //title of the message box
                title = "Leader board";
            }
            //language is spanish
            else if (U.Language == 1)
            {
                //hold a message for the user in their chosen language
                message = "GAME OVER\nThe AI's score was " + LB_Score.Text + "\nThe score has been added to the leader board\nPress ESC to return to the main menu";
                //title of the message box
                title = "Marcador";
            }
            //language is japanese
            else if (U.Language == 2)
            {
                //hold a message for the user in their chosen language
                message = "ゲームオーバー！\nスコアは " + LB_Score.Text + "\nメインメニューに戻るためにESCを押してください";
               //title of the message box
               title = "りーだーぼーど";
            }
            //add their score to the leaderboard:
            //make a new DBI object
            DBI l = new DBI();
            //send the SQL statement 
            l.noReturnSQL("INSERT INTO Tb_Leaderboard([L_Score], [L_AI]) VALUES('" + Convert.ToInt32(LB_Score.Text) + "', '" + -1 + "')");
            //inform the user that the score has been added
            MessageBox.Show(message, title);
            //close this form, displaying the last form
            this.Close();
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
                //make the active tetrimino next
                grid = act.switchActive(grid);
                //if any rows are full, remove them before adding the new active tetrimino to the grid:
                //to hold how many rows have been removed
                int r = removeRows(grid);
                //add r to rows and display to user
                LB_Rows.Text = (Convert.ToInt32(LB_Rows.Text) + r).ToString();
                //to hold the amount that needs to be added to the score
                int s;
                //if the user has no rows
                if (r == 0)
                {
                    //no combo
                    combo = 0;
                    s = 0;
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
                    s = Convert.ToInt32(Math.Pow(2, (r - 1)) * 100 * mult);
                }
                //update the score
                LB_Score.Text = (Convert.ToInt32(LB_Score.Text) + s).ToString();
                //update the level
                LB_Level.Text = Convert.ToString(Convert.ToInt32(LB_Rows.Text) / 10);
                //make the next tetrimino active
                grid = nxt.switchNext(grid);
                //do an AI move
                moveAI(nxt);
            }
        }

        //interact with the AI 
        public void moveAI(Tetrimino act)
        {
            //pause game
            TMR_Time.Enabled = false;
            //get an array of possible legal moves
            int[,] moves = getMoves(act);
            //execute the best move, given the best move available from calculateMove()
            executeMove(act, moves, calculateMove(moves));
            //play game
            TMR_Time.Enabled = true;
        }

        //if any rows are full, remove them and return the user's score
        public int removeRows(string[,] grid)
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

                    //--delete row j--//

                    //loop through each coordinate in row j
                    for (int i = 0; i < 10; i++)
                    {
                        //empty the space in the grid
                        grid[i, j] = "E";
                    }

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
            //return the amount of rows
            return r;
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

        //when the user clicks the end button
        private void BTN_End_Click(object sender, EventArgs e)
        {
            //end the game
            endGame();
            //close this form, displaying the last form
            this.Close();
        }

        //returns an array of columns / rotations of legal moves
        public int[,] getMoves(Tetrimino act)
        {
            //to hold all possible moves for act:
            //the highest possible amount of moves is 40 (10 columns * 4 rotations)
            int[,] moves = new int[41, 5];
            //to hold how many rotations of act are needed to be checked (highest is 3)
            int rotVal = 3;
            //if its type is 0
            if (act.tType == 0)
            {
                //only has 1 rotation
                rotVal = 0;
            }
            //if its type is 1, 2, or 3
            else if (act.tType == 1 || act.tType == 2 || act.tType == 3)
            {
                //has 2 rotations
                rotVal = 1;
            }

            //make a copy of act that can be edited
            Tetrimino n = act;

            //to hold how many moves are in array 'moves'
            int totMoves = 0;
            //go through each rotation of act
            for (int r = 0; r <= rotVal; r++)
            {
                //go though each column in the grid
                for (int c = 0; c <= 9; c++)
                {

                    //set n to be at the top
                    n.Y[0] = 0;
                    //set the rotation of n
                    n.tRotation = r;
                    //set the column value of n
                    n.X[0] = c;
                    //build n with the new settings
                    n.buildTetrimino();

                    //to hold if the move is legal
                    bool legal = true;
                    //go through each piece of tetrimino n
                    for (int i = 0; i < 4; i++)
                    {
                        //if the piece is outside the grid
                        if (n.X[i] > 9 || n.X[i] < 0)
                        {
                            //the move is not legal
                            legal = false;
                        }
                    }

                    //if the move is still legal
                    if (legal == true)
                    {
                        //----------------------------//
                        //---calculate holes before---//
                        //----------------------------//

                        //to hold how many holes there are before executing the move:
                        int holesBefore = holes(grid, true);

                        //-------------------//
                        //---copy the grid---//
                        //-------------------//

                        //make a copy of the grid that can be edited without changing the main game:
                        //empty array the same size as grid
                        string[,] copyGrid = new string[10, 20];
                        //do this 10 times
                        for (int i = 0; i < 10; i++)
                        {
                            //do this 20 times
                            for (int j = 0; j < 20; j++)
                            {
                                //copy the value of grid to copygrid
                                copyGrid[i, j] = grid[i, j];
                            }
                        }

                        //-------------------------------//
                        //---add the move to the array---//
                        //-------------------------------//

                        //column
                        moves[totMoves, 0] = c;
                        //rotation
                        moves[totMoves, 1] = r;

                        //---------------------------//
                        //---how far n can go down---//
                        //---------------------------//

                        //while there is not a permanent piece below n OR n has not hit the bottom
                        while (n.checkDownCol(copyGrid) == false && n.touchedBottom() == false)
                        {
                            //move n down
                            n.moveDown();
                            //update n in the copy of grid
                            copyGrid = n.updateActivePiece(copyGrid);
                            displayMainArray();
                        }

                        //to hold how far it can go down
                        int p = 0;
                        //go through each piece
                        for (int i = 0; i < 4; i++)
                        {
                            //add score to p
                            p += n.Y[i];
                        }
                        //add p to moves
                        moves[totMoves, 2] = p;

                        //---------------------------------//
                        //---will the move complete rows---//
                        //---------------------------------//

                        //if the move can complete rows
                        if (removeRows(copyGrid) > 0)
                        {
                            //add to moves
                            moves[totMoves, 3] = 1;
                        }
                        //it cannot remove any rows
                        else
                        {
                            //add to moves
                            moves[totMoves, 3] = 0;
                        }

                        //---------------------------------------//
                        //---how many holes will the move make---//
                        //---------------------------------------//

                        //to hold how many holes there are after executing the move
                        int holesAfter = holes(copyGrid, false);
                        //add the amount of holes created by the move to moves
                        moves[totMoves, 4] = (holesAfter - holesBefore);

                        //add 1 to totMoves
                        totMoves++;
                    }
                }
            }
            //set totMoves column to 500
            moves[totMoves, 0] = 500;
            //return the array of moves
            return moves;
        }

        public int holes(string[,] grid, bool before)
        {
            //to hold the amount of holes in the grid
            int h = 0;
            //do this 10 times
            for (int i = 0; i < 10; i++)
            {
                //to hold whether there has been a full piece yet in the column
                bool full = false;
                //do this 20 times
                for (int j = 0; j < 20; j++)
                {
                    //if there has been a full piece in the column so far
                    if (full == true)
                    {
                        //if the current piece is empty
                        if (grid[i, j] == "E")
                        {
                            //there is a hole
                            h++;
                        }
                    }
                    //if the current piece is not empty AND before is false OR if the current piece contains p AND before is true
                    else if ((grid[i, j] != "E" && before == false) || (grid[i, j].Contains("P") && before == true))
                    {
                        //there has been a full piece in the grid now
                        full = true;
                    }
                }
            }
            //return the number of holes
            return h;
        }

        //calculate the best move out of the given array and return it's index
        public int calculateMove(int[,] moves)
        {
            //get the size of moves (where column = 500, -1 from index to get highest real index)
            //hold the size of 'moves'
            int movesSize = 0;
            //go through each in moves
            for (int i = 0; i < 41; i++)
            {
                //if the column is 500
                if (moves[i, 0] == 500)
                {
                    //size of array is i - 1
                    movesSize = i - 1;
                }
            }

            //to hold the maximum score from a move
            int maxM = 0;
            //to hold how many moves give the maximum points
            int countMaxM = 1;
            //a list holding the reference of the potential moves (in array moves) that give the maximum score
            int[] maxMoves = new int[42];
            //loop through each move
            for (int i = 0; i < movesSize; i++)
            {
                //to hold the points for that move
                int points = moves[i, 2];
                //if the move completes rows
                if (moves[i, 3] == 1)
                {
                    //times points by 3
                    points *= 3;
                }

                //if the move creates holes
                if (moves[i, 4] > 0)
                {
                    //divide points by the amount of holes + 1
                    points /= (moves[i, 4] + 1);
                }

                //if the move has the same points as the max
                if (points == maxM)
                {
                    //add the move to maxMoves
                    maxMoves[countMaxM] = i;                
                    //add 1 to countMaxM
                    countMaxM++;
                }
                //if the move has more points than the max
                else if (points > maxM)
                {
                    //clear maxMoves
                    Array.Clear(maxMoves, 0, 42);
                    //there is only 1 in maxMoves now
                    countMaxM = 1;
                    //set maxM to points
                    maxM = points;
                    //add the move to maxMoves
                    maxMoves[countMaxM] = i;
                    //add 1 to countMaxM
                    countMaxM++;
                }
            }
            //take one away from countMaxM (it is waiting for a new move)
            countMaxM--;
            //to hold the best move (automatically set to first in maxMoves)
            int bestMove = maxMoves[1];
            //if there is more than 1 maximum move
            if (countMaxM > 1)
            {
                //pick a random move from the maxMoves:
                //random integer
                Random rand = new Random();
                //pick a random move between 1 and countMaxM
                bestMove = maxMoves[rand.Next(1, countMaxM)];
            }
            //return the best move
            return bestMove;
        }

        //executes the move
        public void executeMove(Tetrimino act, int[,] moves, int bestMove)
        { 
            //set the centre Y coordinate to 0
            act.Y[0] = 0;
            //best column centre
            act.X[0] = moves[bestMove, 0];
            //best rotation
            act.tRotation = moves[bestMove, 1];
            //build the tetrimino around the given attributes
            act.buildTetrimino();
            //update it in the grid
            grid = act.updateActivePiece(grid);
        }

        //when the user clicks start
        private void BTN_Start_Click(object sender, EventArgs e)
        {
            //start the timer
            TMR_Time.Enabled = true;
            //do the first AI move
            moveAI(a);
        }

        //when the timer ticks
        private void TMR_Time_Tick_1(object sender, EventArgs e)
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
    }
}
