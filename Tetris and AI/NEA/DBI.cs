using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    class DBI
    {
        //perform an SQL statement inserting or updating data (not returning anything)
        public void noReturnSQL(string SQL)
        {
            //create a connection
            var conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Db_Leaderboard.accdb");
            //open the connection
            conn.Open();
            //create a command for the information with the SQL message and the connection
            var cmd = new OleDbCommand(SQL, conn);
            //execute the command
            cmd.ExecuteNonQuery();
            //close the connection
            conn.Close();
        }

        //perform an SQL statement to return data
        public DataTable returnSQL(string SQL)
        {
            //create a connection
            var conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Db_Leaderboard.accdb");
            //open the connection
            conn.Open();
            //Make a place to store the eventual data
            var data_place = new DataTable();
            //Create a pipe for the information with a message and a connection.
            var adapter = new OleDbDataAdapter(SQL, conn);
            //Fill the data store with the information
            adapter.Fill(data_place);
            //End connection
            conn.Close();
            return data_place;
        }
    }
}
