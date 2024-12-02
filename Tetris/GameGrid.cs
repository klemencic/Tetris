using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;  
        public int Columns { get; set; }
        public int Rows { get; set; }

        public GameGrid(int columns, int rows)
        {
            this.Columns = columns;
            this.Rows = rows;
            grid = new int[columns, rows];
        }

        public bool IsInside(int r, int c)
        {
           return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[c, r] == 0;
        }

        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[c, r] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[c, r] = 0;
            }
        }

        public void MoveRowDown(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                for (int i = r; i > 0; i--)
                {
                    grid[c, i] = grid[c, i - 1];
                }
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;
            for (int r = 0; r < Rows; r++)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r);
                }
            }

            return cleared;
        }





    }
}
