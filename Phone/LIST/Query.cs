using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.LIST
{
    class Query
    {
        OleDbCommand comand;
        OleDbConnection connection;
        OleDbDataAdapter adapter;
        DataTable table;

        public  Query(string conn)
        {
            connection = new OleDbConnection(conn);
            table = new DataTable();
        }
        public DataTable UpgRade()
        {
            connection.Open();
            adapter= new OleDbDataAdapter("Select * From Base", connection);
            table.Clear();
            adapter.Fill(table);
            connection.Close();
            return table;
        }
        public void Add(string FirstName, string LastName, string NumberPhone)
        {
            connection.Open();
            comand = new OleDbCommand("INSERT INTO Base(FirstName, LastName, NumberPhone)Values (FirstName, LastName, NumberPhone)", connection);
            comand.Parameters.AddWithValue("FirstName", FirstName);
            comand.Parameters.AddWithValue("LastName", LastName);
            comand.Parameters.AddWithValue("Number", NumberPhone);
            comand.ExecuteNonQuery();
            connection.Close();
        }
        public void Delete(int Id)
        {
            connection.Open();
            comand = new OleDbCommand($"Delete From Base Where {Id}=Id ",connection);
            comand.ExecuteNonQuery();
            connection.Close();
        
        }

    }
}




