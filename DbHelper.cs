using System.Data;
using MySql.Data.MySqlClient;

public static class DbHelper
{
    public static string ConnectionString =>
        System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

    public static DataTable GetTables()
    {
        using var conn = new MySqlConnection(ConnectionString);
        conn.Open();
        var dt = conn.GetSchema("Tables");
        return dt;
    }

    public static DataTable GetTableData(string tableName)
    {
        using var conn = new MySqlConnection(ConnectionString);
        conn.Open();
        var dt = new DataTable();
        using var cmd = new MySqlCommand($"SELECT * FROM `{tableName}`", conn);
        using var da = new MySqlDataAdapter(cmd);
        try
        {
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            // Fallback: tenta ler todos os campos como string para evitar erro de data inválida
            System.Diagnostics.Debug.WriteLine($"Tabela {tableName}: erro ao ler como DataTable: {ex.Message}");
            dt.Clear();
            dt.Columns.Clear();
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            using var conn2 = new MySqlConnection(ConnectionString);
            conn2.Open();
            var columns = GetColumnNames(conn2, tableName);
            using var cmd2 = new MySqlCommand($"SELECT "+
                "CONCAT_WS('|'," +
                string.Join(",", columns.Select(c => $"IFNULL(CAST(`{c}` AS CHAR), '')")) +
                $") as RowData FROM `" + tableName.Replace("`", "``") + "`", conn2);
            using var rdr = cmd2.ExecuteReader();
            foreach(var col in columns)
                dt.Columns.Add(col);
            while(rdr.Read())
            {
                var rowData = rdr.GetString(0).Split('|');
                dt.Rows.Add(rowData);
            }
        }
        return dt;
    }

    private static List<string> GetColumnNames(MySqlConnection conn, string tableName)
    {
        var cols = new List<string>();
        using var cmd = new MySqlCommand($"SHOW COLUMNS FROM `{tableName}`", conn);
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            cols.Add(rdr.GetString(0));
        return cols;
    }

    public static void BulkInsert(string tableName, DataTable dataTable)
    {
        using var conn = new MySqlConnection(ConnectionString);
        conn.Open();
        using var transaction = conn.BeginTransaction();
        try
        {
            foreach (DataRow row in dataTable.Rows)
            {
                var columns = string.Join(", ", dataTable.Columns.Cast<DataColumn>().Select(c => $"`{c.ColumnName}`"));
                var parameters = string.Join(", ", dataTable.Columns.Cast<DataColumn>().Select(c => "@" + c.ColumnName));
                var cmd = new MySqlCommand($"INSERT INTO `{tableName}` ({columns}) VALUES ({parameters})", conn, transaction);
                foreach (DataColumn col in dataTable.Columns)
                    cmd.Parameters.AddWithValue("@" + col.ColumnName, row[col] ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
