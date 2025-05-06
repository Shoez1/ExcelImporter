using System.Data;
using ClosedXML.Excel;

public static class ExcelHelper
{
    public static DataTable ReadExcelToDataTable(string filePath)
    {
        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheets.Worksheet(1);
        var dataTable = new DataTable();
        bool firstRow = true;
        foreach (var row in worksheet.RowsUsed())
        {
            if (firstRow)
            {
                foreach (var cell in row.Cells())
                    dataTable.Columns.Add(cell.Value.ToString());
                firstRow = false;
            }
            else
            {
                dataTable.Rows.Add();
                int i = 0;
                foreach (var cell in row.Cells())
                    dataTable.Rows[dataTable.Rows.Count - 1][i++] = cell.Value.ToString();
            }
        }
        return dataTable;
    }

    public static void WriteDataTableToExcel(DataTable dt, string filePath)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Export");
        for (int i = 0; i < dt.Columns.Count; i++)
            worksheet.Cell(1, i + 1).Value = dt.Columns[i].ColumnName;

        for (int i = 0; i < dt.Rows.Count; i++)
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                string cellValue = dt.Rows[i][j]?.ToString() ?? string.Empty;
                if (cellValue.Length > 32767)
                    cellValue = cellValue.Substring(0, 32767);
                worksheet.Cell(i + 2, j + 1).Value = cellValue;
            }

        workbook.SaveAs(filePath);
    }
}
