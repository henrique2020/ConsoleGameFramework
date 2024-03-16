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

        public int Draw(int line, int column, string phrase)
        {
            bool exibe = true;
            int total_lines = 1;
            phrase = phrase.Replace("\r\n", "\n");
            phrase = phrase.Replace("\r", "\n");
            phrase = phrase.Trim('\n').Trim('\t');
            for (int col = column, pos = 0; pos < phrase.Length; col++, pos++)
            {
                if ((line == 0 || line >= this.Lines) || (column == 0 || column + phrase.Length - pos >= this.Columns))
                {
                    exibe = false;
                    this.Fill();
                    Console.WriteLine("A frase chegou na borda, não foi possível escrever");
                    break;
                }
                char symbol = phrase[pos];
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

            //if (exibe) this.Print();
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
