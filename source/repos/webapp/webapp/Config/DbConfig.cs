using MySql.Data.MySqlClient;
using System.Data;


namespace webapp.Config
{
    public class DbConfig
    {
        MySqlConnection MySqlConnection = new MySqlConnection(@"server=localhost; port=3306; database=dbemp; username=root; password=[PASSWORD]");

        public DataTable GetDataTable(string sqlquery)
        {
            MySqlDataAdapter da;
            DataSet ds;
            DataTable dt;
            MySqlConnection.Open();
            da = new MySqlDataAdapter(sqlquery, MySqlConnection);
            da.SelectCommand.CommandTimeout = 6000;
            ds = new DataSet();
            da.Fill(ds);
            MySqlConnection.Close();
            dt = ds.Tables[0];
            return dt;
            
        }

        public string insert_query(string tablename, string[] fields, object[] values)
        {
            string sql;
            string insert;
      
            insert = "Insert Into " + tablename + "(";
      
            for (int i = 0; i < fields.Length; i++)
            {

                values[i] = values[i].ToString().Replace("\"", "\\\"");
                insert += fields[i] + ",";
            }

            insert = insert.Remove(insert.LastIndexOf(","), 1);
            insert += ") ";
     
            sql = insert + ";";
            //  sql = sql.Replace("*", "'*'");

            return sql;
        }

        public string update_query(string tablename, string[] fields, object[] values, int id)
        {
            string sql;
            string update;

            update = " update " + tablename + " set ";
            for (int i = 0; i < fields.Length; i++)
            {
                update += "`" + fields[i] + "`='" + values[i].ToString() + "', ";

            }

            update = update.Remove(update.LastIndexOf(","), 1);
            update += " where id = '" + id.ToString() + "' ";

            sql = update + ";";

            return sql;
        }

        public string delete_query(string tablename, int id)
        {
            string sql;
            string delete;

            delete = "DELETE FROM " + tablename + " WHERE id = '" + id.ToString() + "'";

            sql = delete + ";";

            return sql;
        }

        public int executequery(string sql)
        {
            MySqlCommand cmd;
            MySqlConnection con;
            int rowsaffected;
            MySqlConnection.Open();
            cmd = new MySqlCommand(sql, MySqlConnection);

            rowsaffected = cmd.ExecuteNonQuery();
            MySqlConnection.Close();

            return rowsaffected;
        }

    }
}
