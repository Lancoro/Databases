using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LehaBD_Lab2
{
    class Programm
    {

        static void Main(string[] args)
        {
            var cs = "Host=127.0.0.1;Username=postgres;Password=qwerty;Database=Site";
            var con = new NpgsqlConnection(cs);
            con.Open();
            BDController.Menu(con);
            con.Close();
        }
    }
}
