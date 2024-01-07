using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    public class Tetrimino
    {
        //random number variable
        static Random rand = new Random();

        //to hold the type of the tetrimino
        private int _tType;
        //to hold the rotation of the tetrimino
        private int _tRotation;
        //to hold whether the tetrimino is dormant (0), active (1) or next (2)
        private int _tStatus;
        //to hold the coordinates of the tetrimino
        private int[] _X = new int[4];
        private int[] _Y = new int[4];

        //get and set methods for variables:
        public int tType { get => _tType; set => _tType = value; }
        public int tRotation { get => _tRotation; set => _tRotation = value; }
        public int tStatus { get => _tStatus; set => _tStatus = value; }
        public int[] X { get => _X; set => _X = value; }
        public int[] Y { get => _Y; set => _Y = value; }

        //constructor method for tetrimino class
        public Tetrimino()
        {
            //select a random number between 0 and 7 for the type of the tetrimino
            tType = rand.Next(0, 7);
            //rotation is the default rotation for each
            tRotation = 0;
            //tetrimino is next when it is created
            tStatus = 2;
            //the centre (X[0], Y[0]) of the tetrimino is (1, 0)
            X[0] = 1;
            Y[0] = 0;
            //build the tetrimino around the centre
            buildTetrimino();
        }

        //checks if the rotated tetrimino is illegal
        public bool checkOverlap(string[,] grid)
        {
            //loop through each piece of the tetrimino
            for (int i = 0; i < 4; i++)
            {
                //if the piece at i is invalid
                if (X[i] < 0 || X[i] > 9 || Y[i] < 0 || Y[i] > 19)
                {
                    return true;
                }
            }

            //loop through each piece of the tetrimino
            for (int i = 0; i < 4; i++)
            {
                //loop through each piece of the tetrimino
                for (int j = 0; j < 4; j++)
                {
                    //if the piece at (i, j) is permanent
                    if (grid[X[i], Y[j]].Contains("P"))
                    {
                        return true;
                    }
                }
            }
            
            //if all pieces are valid
            return false;
        }

        //rotates the tetrimino clockwise is c is true and anticlockwise is c is false
        public void rotate(bool c, bool b, string[,] grid)
        {
            //to hold the value added to the rotation
            int rotAdd = 1;
            //if its being rotated ACW
            if (c == false)
            {
                rotAdd = -1;
            }

            //if the rotation is 3 and going clockwise
            if ((tRotation == 3) && (c == true))
            {
                //set to 0
                tRotation = 0;
            }
            //if the rotation is 0 and going anticlockwise
            else if ((tRotation == 0) && (c == false))
            {
                //set to 3
                tRotation = 3;
            }
            else
            {
                //change the tetriminos rotation
                tRotation = tRotation + rotAdd;
            }
            //build the tetrimino according to it's new rotation
            buildTetrimino();
            //if the tetrimino is not rotating back and checkOverlap returns true
            if (b == false && checkOverlap(grid) == true)
            {
                //rotate back (b is true) the other way (not c)
                rotate(!c, true, grid);
            }
        }

        //returns true if a piece of tetrimino is touching the top of the grid
        public bool touchedTop()
        {
            //loop through each piece in the tetrimino
            for (int i = 0; i < 4; i++)
            {
                //if the y value of any piece is 0
                if (Y[i] == 0)
                {
                    return true;
                }
            }
            //no pieces are touching the top
            return false;
        }

        //makes this tetrimino permanent in the grid
        public string[,] switchActive(string[,] grid)
        {
            //go through the whole grid:
            //do this 20 times
            for (int i = 0; i < 10; i++)
            {
                //do this 10 times
                for (int j = 0; j < 20; j++)
                {
                    //if the current space contains a piece of the active tetrimino
                    if ((i == X[0] && j == Y[0]) || (i == X[1] && j == Y[1]) || (i == X[2] && j == Y[2]) || (i == X[3] && j == Y[3]))
                    {
                        //check which piece it is 
                        if (tType == 0)
                        {
                            //sets the permanent piece in the array so it contains the correct piece
                            grid[i, j] = "P0";
                        }
                        else if (tType == 1)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "P1";
                        }
                        else if (tType == 2)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "P2";
                        }
                        else if (tType == 3)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "P3";
                        }
                        else if (tType == 4)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "P4";
                        }
                        else if (tType == 5)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "P5";
                        }
                        else if (tType == 6)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "P6";
                        }
                    }
                }
            }
            //reset all variables for this tetrimino:
            //make this tetrimino 'next' status
            tStatus = 2;
            //select a random number between 0 and 6 for the type of the tetrimino
            tType = rand.Next(0, 7);
            //rotation is the default rotation 
            tRotation = 0;
            //the centre (X[0], Y[0]) of the tetrimino is (1, 0)
            X[0] = 1;
            Y[0] = 0;
            //build the tetrimino around the centre
            buildTetrimino();

            //return the updated array
            return grid;
        }

        //makes this tetrimino permanent in the grid
        public string[,] switchNext(string[,] grid)
        {
            //reset all variables for this tetrimino:
            //make this tetrimino 'active' status
            tStatus = 1;
            //the centre (X[0], Y[0]) of the tetrimino is (5, 0)
            X[0] = 5;
            Y[0] = 0;
            //build the tetrimino around the centre
            buildTetrimino();

            //go through the whole grid:
            //do this 20 times
            for (int i = 0; i < 10; i++)
            {
                //do this 10 times
                for (int j = 0; j < 20; j++)
                {
                    //if the current space contains a piece of the active tetrimino
                    if ((i == X[0] && j == Y[0]) || (i == X[1] && j == Y[1]) || (i == X[2] && j == Y[2]) || (i == X[3] && j == Y[3]))
                    {
                        //check which piece it is 
                        if (tType == 0)
                        {
                            //sets the permanent piece in the array so it contains the correct piece
                            grid[i, j] = "A0";
                        }
                        else if (tType == 1)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A1";
                        }
                        else if (tType == 2)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A2";
                        }
                        else if (tType == 3)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A3";
                        }
                        else if (tType == 4)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A4";
                        }
                        else if (tType == 5)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A5";
                        }
                        else if (tType == 6)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A6";
                        }
                    }
                }
            }
            //return the updated array
            return grid;
        }

        //moves the tetrimino down one space
        public void moveDown()
        {
            //if any of the y-coordiantes of any piece of the tetrimino are touching the bottom of the grid
            if (touchedBottom() == false)
            {
                //go through each piece in the tetrimino
                for (int i = 0; i < 4; i++)
                {
                    //move the piece corresponding to i down one by adding 1 to the y value
                    Y[i]++;
                }
            }
        }

        //moves the tetrimino right one space
        public void moveRight()
        {
            //if any of the x-coordiantes of any piece of the tetrimino are touching the right of the grid
            if (X[0] == 9 || X[1] == 9 || X[2] == 9 || X[3] == 9)
            {
                //don't do anything, the active piece cannot move right
            }
            else
            {
                //go through each piece in the tetrimino
                for (int i = 0; i < 4; i++)
                {
                    //move the piece corresponding to i right one by adding 1 to the x value
                    X[i]++;
                }
            }
        }

        //moves the tetrimino left one space
        public void moveLeft()
        {
            //if any of the x-coordiantes of any piece of the tetrimino are touching the left of the grid
            if (X[0] == 0 || X[1] == 0 || X[2] == 0 || X[3] == 0)
            {
                //don't do anything, the active piece cannot move down
            }
            else
            {
                //go through each piece in the tetrimino
                for (int i = 0; i < 4; i++)
                {
                    //move the piece corresponding to i down one by adding 1 to the y value
                    X[i]--;
                }
            }
        }

        //checks if there is a permanent piece to the right or left of the tetrimino, if r is true or false respectively 
        public bool checkHorizCol(bool r, string[,] grid)
        {
            //to hold the value added to the x-coordinate (1 if r is true)
            int Xadd = 1;
            //if checking left
            if(r == false)
            {
                //make Xadd -1
                Xadd = -1;
            }
            //can left be checked:
            if (r == false)
            {
                //if any of the x-coordiantes of any piece of the tetrimino are touching the left of the grid
                if (X[0] <= 0 || X[1] <= 0 || X[2] <= 0 || X[3] <= 0 || X[0] > 9 || X[1] > 9 || X[2] > 9 || X[3] > 9 || Y[0] > 19 || Y[1] > 19 || Y[2] > 19 || Y[3] > 19)
                {
                    return false;
                }
            }
            //can right be checked:
            else
            {
                //if any of the x-coordiantes of any piece of the tetrimino are touching the right of the grid
                if (X[0] >= 9 || X[1] >= 9 || X[2] >= 9 || X[3] >= 9)
                {
                    return false;
                }
            }

            //loop 4 times for the 4 pieces 
            for (int i = 0; i < 4; i++)
            {
                //if the space either left or right the current space is permenent
                if (grid[X[i] + Xadd, Y[i]].Contains("P"))
                {
                    //there is a permanent piece to the left or right of it
                    return true;
                }
            }
            //after looping through each piece, return false
            return false;
        }

        //checks if there is a permanent piece below the active tetrimino
        public bool checkDownCol(string[,] grid)
        {
            //if the tetrimino is not at the bottom of the grid
            if (touchedBottom() == false)
            {
                //loop 4 times for the 4 pieces 
                for (int i = 0; i < 4; i++)
                {
                    //if the space below the current space is permanent
                    if (grid[X[i], Y[i] + 1].Contains("P"))
                    {
                        //there is a permanent piece below it
                        return true;
                    }
                }
                //after looping through each piece, return false
                return false;
            }
            //if it is at the bottom, there can't be anything below it
            else
            {
                return false;
            }
        }

        //to checek if the tetrimino is touching the bottom of the grid
        public bool touchedBottom()
        {
            //if the Y co-ordinate of any of the parts of the current tetromino is at the bottom
            if (Y[0] == 19 || Y[1] == 19 || Y[2] == 19 || Y[3] == 19)
            {
                return true;
            }
            //if its not
            else
            {
                return false;
            }
        }

        //makes the tetrimino active
        public void makeActive()
        {
            //set the tetrimino to active
            tStatus = 1;
            //the centre (X[0], Y[0]) of the tetrimino is (5, 0)
            X[0] = 5;
            Y[0] = 0;
            //build the tetrimino around the new centre
            buildTetrimino();
        }

        //updates the active piece in the array given
        public string[,] updateActivePiece(string[,] grid)
        {
            //GETS RID OF THE OLD ACTIVE PIECE:
            //do this 10 times
            for (int i = 0; i < 10; i++)
            {
                //do this 20 times
                for (int j = 0; j < 20; j++)
                {
                    //this needs to be here otherwise theres an error
                    if (grid[i, j] == "") { }                 
                    //if the current space in the array contains anything that contains A (active piece)
                    else if (grid[i, j].Contains("A"))
                    {
                        //make it say E (empty)
                        grid[i, j] = "E";
                    }
                }
            }
            //UPDATE CURRENT PIECE IN THE ARRAY
            //do this 20 times
            for (int i = 0; i < 10; i++)
            {
                //do this 10 times
                for (int j = 0; j < 20; j++)
                {
                    //if the current space contains a piece of the active tetrimino
                    if ((i == X[0] && j == Y[0]) || (i == X[1] && j == Y[1]) || (i == X[2] && j == Y[2]) || (i == X[3] && j == Y[3]))
                    {
                        //check which piece it is 
                        if (tType == 0)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A0";
                        }
                        else if (tType == 1)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A1";
                        }
                        else if (tType == 2)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A2";
                        }
                        else if (tType == 3)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A3";
                        }
                        else if (tType == 4)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A4";
                        }
                        else if (tType == 5)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A5";
                        }
                        else if (tType == 6)
                        {
                            //sets the active piece in the array so it contains the correct piece
                            grid[i, j] = "A6";
                        }
                    }
                }
            }
            //return the updated array
            return grid;
        }

        //updates the next piece in the array given
        public string[,] updateNextPiece(string[,] grid)
        {
            //GETS RID OF THE OLD PIECE:
            //do this 4 times
            for (int i = 0; i < 4; i++)
            {
                //do this 4 times
                for (int j = 0; j < 4; j++)
                {
                    //if the current space in the array contains anything other than E
                    if (grid[i, j].Contains("E") == false)
                    {
                        //make it say E (empty)
                        grid[i, j] = "E";
                    }
                }
            }
            //UPDATE PIECE IN THE ARRAY
            //do this 4 times
            for (int i = 0; i < 4; i++)
            {
                //do this 4 times
                for (int j = 0; j < 4; j++)
                {
                    //if the current space contains a piece of the active tetromino
                    if ((i == X[0] && j == Y[0]) || (i == X[1] && j == Y[1]) || (i == X[2] && j == Y[2]) || (i == X[3] && j == Y[3]))
                    {
                        //check which piece it is 
                        if (tType == 0)
                        {
                            //sets the piece in the array so it contains the correct piece
                            grid[i, j] = "0";
                        }
                        else if (tType == 1)
                        {
                            //sets the piece in the array so it contains the correct piece
                            grid[i, j] = "1";
                        }
                        else if (tType == 2)
                        {
                            //sets the piece in the array so it contains the correct piece
                            grid[i, j] = "2";
                        }
                        else if (tType == 3)
                        {
                            //sets the piece in the array so it contains the correct piece
                            grid[i, j] = "3";
                        }
                        else if (tType == 4)
                        {
                            //sets the piece in the array so it contains the correct piece
                            grid[i, j] = "4";
                        }
                        else if (tType == 5)
                        {
                            //sets the piece in the array so it contains the correct piece
                            grid[i, j] = "5";
                        }
                        else if (tType == 6)
                        {
                            //sets the piece in the array so it contains the correct piece
                            grid[i, j] = "6";
                        }
                    }
                }
            }
            //return the updated array
            return grid;
        }

        //builds the tetrimino around the centre (X[0], Y[0]) which will have been set
        public void buildTetrimino()
        {
            //the rotation is 0
            if(tRotation == 0)
            {
                //if type is 0
                if(tType == 0)
                {
                    X[1] = X[0] + 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 1
                else if(tType == 1)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0];
                    Y[2] = Y[0] + 2;

                    X[3] = X[0];
                    Y[3] = Y[0] + 3;
                }
                //if type is 2
                else if (tType == 2)
                {
                    X[1] = X[0] + 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] - 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 3
                else if (tType == 3)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 4
                else if (tType == 4)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0];
                    Y[2] = Y[0] + 2;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 2;
                }
                //if type is 5
                else if (tType == 5)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0];
                    Y[2] = Y[0] + 2;

                    X[3] = X[0] - 1;
                    Y[3] = Y[0] + 2;
                }
                //if type is 6
                else if (tType == 6)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0] + 1;
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] - 1;
                    Y[3] = Y[0] + 1;
                }
            }
            //the rotation is 1
            else if(tRotation == 1)
            {
                //if type is 0
                if (tType == 0)
                {
                    X[1] = X[0] + 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 1
                else if (tType == 1)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0];

                    X[2] = X[0] + 1;
                    Y[2] = Y[0];

                    X[3] = X[0] + 2;
                    Y[3] = Y[0];
                }
                //if type is 2
                else if (tType == 2)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0] + 1;
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 2;
                }
                //if type is 3
                else if (tType == 3)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0] + 1;

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] - 1;
                    Y[3] = Y[0] + 2;
                }
                //if type is 4
                else if (tType == 4)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0];

                    X[2] = X[0] + 1;
                    Y[2] = Y[0];

                    X[3] = X[0] - 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 5
                else if (tType == 5)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0] + 1;
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 2;
                    Y[3] = Y[0] + 1;
                }
                //if type is 6
                else if (tType == 6)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0] + 1;
                    Y[2] = Y[0] + 1;

                    X[3] = X[0];
                    Y[3] = Y[0] + 2;
                }
            }
            //the rotation is 2
            else if (tRotation == 2)
            {
                //if type is 0
                if (tType == 0)
                {
                    X[1] = X[0] + 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 1
                else if (tType == 1)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0];
                    Y[2] = Y[0] + 2;

                    X[3] = X[0];
                    Y[3] = Y[0] + 3;
                }
                //if type is 2
                else if (tType == 2)
                {
                    X[1] = X[0] + 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] - 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 3
                else if (tType == 3)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 4
                else if (tType == 4)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0];
                    Y[3] = Y[0] + 2;
                }
                //if type is 5
                else if (tType == 5)
                {
                    X[1] = X[0] + 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0];
                    Y[3] = Y[0] + 2;
                }
                //if type is 6
                else if (tType == 6)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0];

                    X[2] = X[0] + 1;
                    Y[2] = Y[0];

                    X[3] = X[0];
                    Y[3] = Y[0] + 1;
                }
            }
            //the rotation is 3
            else if (tRotation == 3)
            {
                //if type is 0
                if (tType == 0)
                {
                    X[1] = X[0] + 1;
                    Y[1] = Y[0];

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 1
                else if (tType == 1)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0];

                    X[2] = X[0] + 1;
                    Y[2] = Y[0];

                    X[3] = X[0] + 2;
                    Y[3] = Y[0];
                }
                //if type is 2
                else if (tType == 2)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0] + 1;
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 2;
                }
                //if type is 3
                else if (tType == 3)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0] + 1;

                    X[2] = X[0];
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] - 1;
                    Y[3] = Y[0] + 2;
                }
                //if type is 4
                else if (tType == 4)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0] - 1;
                    Y[2] = Y[0] + 1;

                    X[3] = X[0] - 2;
                    Y[3] = Y[0] + 1;
                }
                //if type is 5
                else if (tType == 5)
                {
                    X[1] = X[0] - 1;
                    Y[1] = Y[0];

                    X[2] = X[0] + 1;
                    Y[2] = Y[0];

                    X[3] = X[0] + 1;
                    Y[3] = Y[0] + 1;
                }
                //if type is 6
                else if (tType == 6)
                {
                    X[1] = X[0];
                    Y[1] = Y[0] + 1;

                    X[2] = X[0] - 1;
                    Y[2] = Y[0] + 1;

                    X[3] = X[0];
                    Y[3] = Y[0] + 2;
                }
            }
        }
    }
}
