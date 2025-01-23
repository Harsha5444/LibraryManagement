using System;
using System.Data;

public class TablePrinter
{
    public static void PrintDataTable(DataTable dataTable)
    {
        if (dataTable == null || dataTable.Rows.Count == 0)
        {
            Console.WriteLine("No data available to display.");
            return;
        }

        // Print a separator line
        Console.WriteLine(new string('-', dataTable.Columns.Count * 25));

        // Print column headers
        foreach (DataColumn column in dataTable.Columns)
        {
            Console.Write(column.ColumnName.PadRight(25));
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', dataTable.Columns.Count * 25));

        // Print rows
        foreach (DataRow row in dataTable.Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write(item.ToString().PadRight(25));
            }
            Console.WriteLine();
        }

        // Print a separator line
        Console.WriteLine(new string('-', dataTable.Columns.Count * 25));
    }
}
