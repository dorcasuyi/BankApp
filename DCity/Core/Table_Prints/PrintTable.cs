using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCity.Core.Table_Prints
{
    public class PrintTable
    {
        private string[] Titles;
        private List<int> Lengths;
        private List<string[]> rows = new List<string[]>();

        public PrintTable(params string[] titles)
        {
            Titles = titles;

            Lengths = titles.Select(t => t.Length).ToList();
        }
        public void AddRow(params string[] row)
        {
            if (row.Length != Titles.Length)
            {
                throw new Exception($"Added row Length [{row.Length}] is not equal to Title row Length [{Titles.Length}]");
            }

            rows.Add(row.Select(o => o.ToString()).ToArray());

            for (int i = 0; i < Titles.Length; i++)
            {
                if (rows.Last()[i].Length > Lengths[i])
                {
                    Lengths[i] = rows.Last()[i].Length;
                }
            };
        }

        public void prints()
        {
            //methode to print the header, and rows.
            Lengths.ForEach(len => Console.Write("*-" + new string('-', len) + "-"));
            Console.WriteLine('*');

            string TitlePrint = "";
            for (int i = 0; i < Titles.Length; i++)
            {
                TitlePrint += "| " + Titles[i].PadRight(Lengths[i]) + ' ';
            }
            Console.WriteLine(TitlePrint + "|");
            Lengths.ForEach(len => Console.Write("*-" + new string('-', len) + "-"));
            Console.WriteLine('*');

            foreach (var row in rows)
            {
                string rowPrint = "";
                for (int i = 0; i < row.Length; i++)
                {
                    rowPrint += "| " + row[i].PadRight(Lengths[i]) + ' ';
                }
                Console.WriteLine(rowPrint + "|");
            }

            Lengths.ForEach(len => Console.Write("*-" + new string('-', len) + "-"));
            Console.WriteLine('*');
        }
    }
}
