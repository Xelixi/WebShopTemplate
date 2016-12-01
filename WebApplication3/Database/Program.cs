using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WebApplication3.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = Connection.Initialize();
            conn.Open();
            var cm = new MySqlCommand("SELECT COUNT(*) from user", conn);
            cm.Prepare();
            var r = cm.ExecuteReader();
            while (r.Read())
            {
                uId = Int32.Parse(r[0].ToString()) + 1;
            }
            var cmd = new MySqlCommand("INSERT INTO user (uId, uPassword, uName, uSurname, uEmail) VALUES (@val1,@val3,@val4,@val5,@val6)", Connection.connection);
            cmd.Parameters.AddWithValue("@val1", uId);
            cmd.Parameters.AddWithValue("@val3", password);
            cmd.Parameters.AddWithValue("@val4", name);
            cmd.Parameters.AddWithValue("@val5", surname);
            cmd.Parameters.AddWithValue("@val6", email);
            cmd.Prepare(); cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}