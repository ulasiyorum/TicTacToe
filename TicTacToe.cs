using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToe
    {
        public const int X = 1, O = -1, EMPTY = 0;
        private int[][] board = new int[3][] { new int[3] {0,0,0}, new int[3] {0,0,0}, new int[3] { 0, 0, 0 } };
        private int currentPlayer;

        private static int[][][] winnerIndices = new int[8][][] {
        new int[3][] { new int[2] { 0, 0 }, new int[2] { 0, 1 }, new int[2] { 0, 2 } } ,
        new int[3][] { new int[2] { 1,0}, new int[2] { 1,1}, new int[2] { 1,2} },
        new int[3][] { new int[2] { 2,0}, new int[2] { 2,1}, new int[2] { 2,2} },

        new int[3][]  { new int[2] { 0,0}, new int[2] { 1,0}, new int[2] { 2,0} },
        new int[3][]  { new int[2] { 0,1}, new int[2] { 1,1}, new int[2] { 2,1} },
        new int[3][]  { new int[2] { 0,2}, new int[2] { 1,2}, new int[2] { 2,2} },

        new int[3][]  { new int[2] { 0,0}, new int[2] { 1,1}, new int[2] { 2,2} },
        new int[3][]  { new int[2] { 0,2}, new int[2] { 1,1}, new int[2] { 2,0} },};

        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Play();
        }
        public TicTacToe()
        {
            board = new int[3][] { new int[3] { 0, 0, 0 }, new int[3] { 0, 0, 0 }, new int[3] { 0, 0, 0 } };
            this.currentPlayer = X;
        }

        public void putMark(int i, int j)
        {
            if ((i < 0) || (i > 2) || (j < 0) || (j > 2))
                throw new ArgumentException("Invalid board position");
            if (board[i][j] != EMPTY)
                throw new ArgumentException("Board position occupied");

            board[i][j] = currentPlayer;
            currentPlayer = -1 * currentPlayer;

        }
        public bool isWinner(int player)
        {

            foreach (int[][] positions in winnerIndices)
            {
                int sum = 0;
                foreach (int[] position in positions)
                {
                    sum += board[position[0]][position[1]];
                }
                if (sum == player * 3)
                    return true;
            }
            return false;
        }


        public int getWinner()
        {
            if (isWinner(X))
                return X;
            else if (isWinner(O))
                return O;
            else
                return EMPTY;
        }

        public void printBoard()
        {
            foreach (int[] line in this.board)
            {
                foreach (int cell in line)
                {
                    if (cell == X)
                    {
                        Console.Write("X");
                    }
                    else if (cell == O)
                    {
                        Console.Write("O");
                    }
                    else if (cell == EMPTY)
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }


        public bool isAvailablePositionExists()
        {
            foreach (int[] line in this.board)
            {
                foreach (int cell in line)
                {
                    if (cell == 0)
                        return true;
                }
            }
            return false;
        }
        public void Play()
        {
            if (!isAvailablePositionExists()) { board = new int[3][] { new int[3] { 0, 0, 0 }, new int[3] { 0, 0, 0 }, new int[3] { 0, 0, 0 } }; }
            string turn = "";
            if (currentPlayer == -1) { turn = "O"; }
            else { turn = "X"; }
            printBoard();
            Console.WriteLine(turn + "'s turn");
            Console.WriteLine("Enter coordinates (x,y) ");
            Scanner scanner = new Scanner(Console.ReadLine());
            putMark(scanner.nextInt(),scanner.nextInt());
            if (getWinner() == currentPlayer * -1)
            {
                printBoard();
                Console.WriteLine(turn + " is the winner!");
            }
            else
            {
                Play();
            }
        }
    }
}


