using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXICodility
{
    public class Solution
    {
        private const char CsvNewLineCharacter = '\n';
        private const char CsvCellSeperator = ',';
        private const string CsvNullCellIdentifier = "NULL";

        /// <summary>
        /// Takes CSV string input, parses CSV and returns CSV, where any rows containing specifically "NULL" is removed.
        /// Assumption is made that fields are not and do not include double-quotes and each data "cell" is seperated by a comma.
        /// </summary>
        /// <param name="S">CSV string representing data</param>
        /// <returns>CSV formatted string with expected results.</returns>
        public static string solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)
            StringBuilder sb = new StringBuilder();

            // split each each line by new line character '\n' and then by ',' to get a list of strings giving us rows of cells.
            IList<IEnumerable<string>> csv_cell_rows = S.Split(CsvNewLineCharacter)
                .Select(csv_line => csv_line.Split(CsvCellSeperator).AsEnumerable()).ToList();

            // index our data, so we know that the first row is always headers, and access this first row when we need to
            IList<IndexedCsvRow> indexed_csv_cell_rows = csv_cell_rows.Select((row, idx) => IndexedCsvRow.Create(row, idx)).ToList();

            foreach (IndexedCsvRow csv_row in indexed_csv_cell_rows)
            {
                // First row > headers > continue
                if (csv_row.Index == 0)
                {
                    sb.AppendJoin(CsvCellSeperator, csv_row.Row);
                    continue;
                }

                // If row does not contain NULL - add to our returning data - The method IList.Contains() by default IS case-sensitive!
                if (csv_row.Row.Contains(CsvNullCellIdentifier) == false)
                {
                    sb.Append(CsvNewLineCharacter);
                    sb.AppendJoin(CsvCellSeperator, csv_row.Row);
                }
            }

            string results = sb.ToString();
            return results;
        }

        public static string simple_solution(string S)
        {
            StringBuilder sb = new StringBuilder();

            string[] csv_rows = S.Split(CsvNewLineCharacter);
            for (int row = 0; row != csv_rows.Length; row++)
            {
                string[] csv_cells = csv_rows[row].Split(CsvCellSeperator);
                if (row == 0)
                {
                    sb.AppendJoin(CsvCellSeperator, csv_cells);
                    continue;
                }

                if (csv_cells.Contains(CsvNullCellIdentifier) == false)
                {
                    sb.Append(CsvNewLineCharacter);
                    sb.AppendJoin(CsvCellSeperator, csv_cells);
                }
            }

            string results = sb.ToString();
            return results;
        }
    }
}