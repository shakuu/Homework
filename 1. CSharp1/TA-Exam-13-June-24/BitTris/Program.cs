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
            int rowCurrPiece = 0;
            int Score = 0;
            int currPieceOnes = 0;
            for (int round = 0; round < inputN / 4; round++)
            {
                //get current Piece, 
                currPiece = long.Parse(Console.ReadLine());
                currShape = ((Convert.ToString(currPiece, 2)).PadLeft(32, '0')).Substring(24, 8);
                //no 1 bits on row 0 by definition, print new piece on top row
                playField = PrintInMatrix(0, currShape, playField);
                rowCurrPiece = 0;
                // reset
                canMove = true;
                //get all 1s
                currPieceOnes = 0;
                while (currPiece > 0)
                {
                    if (currPiece % 2 == 1)
                    {
                        currPieceOnes++;
                    }
                    currPiece = currPiece >> 1;
                }

                // next 3 inputs -> shift left / righ + move down
                for (int input = 1; input < 4; input++)
                {

                    //get input
                    currInput = Console.ReadLine();
                    //Shift Left/ Right if needed
                    switch (currInput)
                    {
                        case "L":
                            if (currShape.IndexOf("1") - 1 >= 0)
                            {
                                if (playField[rowCurrPiece, currShape.IndexOf("1") - 1] != '1')
                                {
                                    if (canMove)
                                    {
                                        playField[rowCurrPiece, currShape.LastIndexOf('1')] = '0';
                                        currShape = currShape.Remove(0, 1);
                                        currShape = currShape.PadRight(8, '0');
                                        playField = PrintInMatrix(rowCurrPiece, currShape, playField);
                                    }
                                }
                            }
                            break;
                        case "R":
                            if (currShape.LastIndexOf("1") + 1 <= 7)
                            {
                                if (playField[rowCurrPiece, currShape.LastIndexOf("1") + 1] != '1')
                                {
                                    if (canMove)
                                    {
                                        playField[rowCurrPiece, currShape.IndexOf('1')] = '0';
                                        currShape = currShape.Remove(7, 1);
                                        currShape = currShape.PadLeft(8, '0');
                                        playField = PrintInMatrix(rowCurrPiece, currShape, playField);
                                    }
                                }
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
                        rowCurrPiece++;
                        for (int col = 0; col < playFieldCols; col++)
                        {
                            if (currShape[col] == '1')
                            {
                                playField[input, col] = currShape[col];
                                playField[input - 1, col] = '0';
                            }
                        }
                    }
                    else
                    {
                        //break;
                    }
                }

                //TODO SCORE
                bool fullRowOfOnes = true;
                for (int col = 0; col < 8; col++)
                {
                    if (playField[rowCurrPiece, col] == '0')
                    {
                        fullRowOfOnes = false;
                    }
                }
                if (fullRowOfOnes)
                {
                    Score += 10 * currPieceOnes;
                    for (int col = 0; col < 8; col++)
                    {
                        playField[rowCurrPiece, col] = '0';
                    }
                }
                else
                {
                    Score += currPieceOnes;
                }


                for (int col = 0; col < playFieldCols; col++)
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

            Console.WriteLine(Score);
        }

        static char[,] PrintInMatrix(int Row, string toPrint, char[,] Matrix)
        {
            for (int col = 0; col < 8; col++)
            {
                if (toPrint[col] == '1')
                {
                    Matrix[Row, col] = toPrint[col];
                }
            }

            return Matrix;
        }
    }
}
