using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.src
{
    internal class World
    {
        public int Lines;
        public int Columns;

        private string[,] Map;

        public World(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;

            Map = new string[lines, columns];
        }

        public void Fill()
        {
            for (int i = 0; i < Lines; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    string temp = " ";
                    if (i == 0)
                    {
                        if (j == 0) temp = "╔";
                        else if (j + 1 < Columns) temp = "═";
                        else temp = "╗";
                    }
                    else if (i + 1 == Lines)
                    {
                        if (j == 0) temp = "╚";
                        else if (j + 1 < Columns) temp = "═";
                        else temp = "╝";
                    }
                    else if (j == 0 || j + 1 == Columns)
                    {
                        temp = "║";
                    }

                    Map[i, j] = temp;
                }
            }
        }

        public int Draw(int line, int column, string text)
        {
            bool borda = false;
            int total_lines = 1;
            text = text.Replace("\r\n", "\n");
            text = text.Replace("\r", "\n");
            text = text.Trim('\n').Trim('\t');
            for (int col = column, pos = 0; pos < text.Length; col++, pos++)
            {
                if ((line == 0 || line+1 >= this.Lines) || (column == 0 || column + text.Length - pos >= this.Columns))
                {
                    borda = true;
                    break;
                }
                char symbol = text[pos];
                if (symbol == '\n')
                {
                    line++;
                    total_lines++;
                    col = column - 1;
                } else
                {
                    Map[line, col] = symbol.ToString();
                }
            }

            if (borda)
            {
                this.Fill();
                this.Draw(1, column, text);
                total_lines = -Lines + 1;
            }

            return total_lines;
        }

        public void Print()
        {
            for (int i = 0; i < Lines; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(Map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
