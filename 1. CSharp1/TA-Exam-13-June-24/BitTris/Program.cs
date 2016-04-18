using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTris
{
    class Program
    {
        static void Main()
        {
            //settings
            int playFieldRows = 4;
            int playFieldCols = 8;

            //initialize the playing field
            char[,] playField = new char[playFieldRows, playFieldCols];
            for (int row = 0; row < playFieldRows; row++)
            {
                for (int col = 0; col < playFieldCols; col++)
                {
                    playField[row, col] = '0';
                }
            }

            //input N, number of iterations
            int inputN = int.Parse(Console.ReadLine());

            //for inputN iterations
            long currPiece;
            string currShape;
            string currInput;
            bool canMove = true;
            bool gameOver = false;
            for (int round = 0; round < inputN; round++)
            {
                //get current Piece, 
                currPiece = long.Parse(Console.ReadLine());
                currShape = ((Convert.ToString(currPiece, 2)).PadLeft(32, '0')).Substring(24, 8);
                //no 1 bits on row 0 by definition, print new piece on top row
                for (int col = 0; col < playFieldCols; col++)
                {
                    if (currShape[col] == '1')
                    {
                        playField[0, col] = currShape[col];
                    }
                }

                // next 3 inputs -> shift left / righ + move down
                for (int input = 1; input < 4; input++)
                {
                    // reset
                    canMove = true;
                    //get input
                    currInput = Console.ReadLine();
                    //Shift Left/ Right if needed
                    switch (currInput)
                    {
                        case "L":
                            //TODO possible OUT OF RANGE exception 
                            if (playField[input, currInput.IndexOf("1") -1] != '1')
                            {
                                // TODO REPRINT CURRENT ROW AFTER SHIFT
                                currShape = currShape.Remove(0, 1);
                                currShape = currShape.PadRight(8, '0');
                            }
                            break;
                        case "R":
                            //TODO possible OUT OF RANGE exception 
                            if (playField[input, currInput.LastIndexOf("1") +1] != '1')
                            {
                               // TODO REPRINT CURRENT ROW AFTER SHIFT
                                currShape = currShape.Remove(7, 1);
                                currShape = currShape.PadLeft(8, '0');
                            }
                            break;
                    }
                    //move the piece ( if position is free )
                    //step 1 : check if next row is free
                    for (int col = 0; col < playFieldCols; col++)
                    {
                        if (playField[input, col] == '1'
                            && currShape[col] == '1')
                        {
                            canMove = false;
                        }
                    }
                    //step 2 : move the piece down
                    if (canMove)
                    {
                        for (int col = 0; col < playFieldCols; col++)
                        {
                            if (currShape[col] == '1')
                            {
                                playField[input, col] = currShape[col];
                                playField[input - 1, col] = '0';
                            }
                        }
                    }
                }

                for ( int col = 0; col<playFieldCols; col++)
                {
                    if (playField[0, col] == '1')
                    {
                        //game over
                        gameOver = true;
                    }
                }
                if (gameOver)
                {
                    break;
                }
            }
        }
    }
}
