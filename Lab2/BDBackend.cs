using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LehaBD_Lab2
{
    class BDBackend
    {

        public static void ExecuteQuery(NpgsqlCommand _cmd)
        {
            try
            {
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);

            }
        }

        static public void Execute(NpgsqlCommand _cmd)
        {
            ExecuteQuery(_cmd);
        }
        static public void ReaderClient(NpgsqlConnection con)
        {
            Console.WriteLine("Client");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"Client\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t {rdr.GetName(2),10}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-3}\t {rdr.GetString(2),10}");
            }
            rdr.Close();
        }

        static public void ReaderCabinet(NpgsqlConnection con)
        {
            Console.WriteLine("Cabinet");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"Cabinet\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetInt32(1),-3}\t");
            }
            rdr.Close();

        }
        static public void ReaderCompany(NpgsqlConnection con)
        {
            Console.WriteLine("Company");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"Company\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t\t {rdr.GetName(1),5}\t\t{rdr.GetName(2),10}\t\t\t{rdr.GetName(3),14}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t\t {rdr.GetString(1),5}\t\t\t{rdr.GetString(2),10}\t\t\t{rdr.GetInt32(3),14}\t");
            }
            rdr.Close();

        }

        static public void ReaderCourse(NpgsqlConnection con)
        {
            Console.WriteLine("Course");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"Course\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),5}\t\t{rdr.GetName(2),10}\t\t\t{rdr.GetName(3),14}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),5}\t\t{rdr.GetString(2),10}\t\t\t{rdr.GetInt32(3),14}\t");
            }
            rdr.Close();

        }

        static public void ReaderLeader(NpgsqlConnection con)
        {
            Console.WriteLine("Leader");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"Leader\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-3}\t");
            }
            rdr.Close();
        }

        static public void AddClient(NpgsqlConnection con, int id, string name, string email)
        {
            var sql = "insert into \"Client\"(id,name,email) VALUES(@id, @name, @email)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Prepare();

            Execute(cmd);
            Console.WriteLine("row inserted");
        }

        static public void AddCourse(NpgsqlConnection con, int id, string course_name, string language, int company_id)
        {
            var sql = "insert into \"Course\"(id,course_name,language, company_id) VALUES(@id, @course_name, @language, @company_id)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("course_name", course_name);
            cmd.Parameters.AddWithValue("language", language);
            cmd.Parameters.AddWithValue("company_id", company_id);
            cmd.Prepare();

            Execute(cmd);
            Console.WriteLine("row inserted");
        }

        static public void AddCompany(NpgsqlConnection con, int id, string company_name, string company_country, int leader_id)
        {
            var sql = "insert into \"Company\"(id,company_name,company_country,leader_id) VALUES(@id, @company_name, @company_country, @leader_id)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("company_name", company_name);
            cmd.Parameters.AddWithValue("company_country", company_country);
            cmd.Parameters.AddWithValue("leader_id", leader_id);
            cmd.Prepare();

            Execute(cmd);
            Console.WriteLine("row inserted");
        }

        static public void DeleteClient(NpgsqlConnection con, int id)
        {
            var sql = $"DELETE FROM \"Client\" WHERE id=" + id;
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }
        static public void DeleteCourse(NpgsqlConnection con, int id)
        {
            var sql = $"DELETE FROM \"Course\" WHERE id=" + id;
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }
        static public void DeleteCompany(NpgsqlConnection con, int id)
        {
            var sql = $"DELETE FROM \"Company\" WHERE id=" + id;
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }

        static public void UpdateClient(NpgsqlConnection con, int id, string name, string email)
        {
            var sql = $"UPDATE \"Client\" SET name='{name}', email ='{email}' WHERE id = {id} ";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }

        static public void UpdateCompany(NpgsqlConnection con, int id, string company_name, string company_country, int leader_id)
        {
            var sql = $"UPDATE \"Company\" SET company_name='{company_name}', company_country ='{company_country}', leader_id = {leader_id} WHERE id = {id} ";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }

        static public void UpdateCourse(NpgsqlConnection con, int id, string course_name, string language, int company_id)
        {
            var sql = $"UPDATE \"Course\" SET course_name='{course_name}', language ='{language}', company_id = {company_id} WHERE id = {id} ";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }

        static public void RandomLeader(NpgsqlConnection con)
        {
            Console.WriteLine("Num of randomized rows: ");
            int num = Convert.ToInt32(Console.ReadLine());
            //var rand_char = "chr(trunc(65+random()*25)::int)";
            string[] masstr = new string[num];
            for (int j = 0; j < num; j++) masstr[j] += " chr(trunc(65+random()*25)::int)";
            string rand_char = String.Join("||", masstr);
            for (int i = 0; i < num; i++)
            {
                var sql = $"insert into \"Leader\"(id,name) VALUES((random()*10000)::int , {rand_char})";
                var cmd = new NpgsqlCommand(sql, con);
                Execute(cmd);
            }

        }

        static public void DynamicSearch1(NpgsqlConnection con)
        {
            Console.WriteLine("\n\nПоиск идентификатора и названия курса по идентифиатору клиента\n");
            string client_id; ;
            Console.WriteLine("Client id: ");
            client_id = Console.ReadLine();

            var sql = $"select \"Client\".id, \"Course\".id, \"Course\".course_name from \"Client\" " +
                $"inner join \"Cabinet\" on \"Client\".id = \"Cabinet\".id " +
                $"inner join \"Course\" on \"Cabinet\".course_id = \"Course\".id " +
                $"where \"Client\".id = {client_id}";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t \t{rdr.GetName(2),10}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetInt32(1),-3}\t\t {rdr.GetString(2),10} \t\t ");
            }
            rdr.Close();
        }

        static public void DynamicSearch2(NpgsqlConnection con)
        {
            Console.WriteLine("\n\nПоиск названия, идентификатора курса, и названия компании, что выпустила этот курс по идентификатору директора компании\n");
            int leader_id;
            Console.WriteLine("Идентификатор директора: ");
            leader_id = Convert.ToInt32(Console.ReadLine());
           
            var sql = $"select \"Leader\".id, \"Leader\".name, \"Course\".id, \"Course\".course_name, \"Company\".company_name from \"Leader\" " +
                $"inner join \"Company\" on \"Leader\".id = \"Company\".leader_id " +
                $"inner join \"Course\"  on \"Company\".id = \"Course\".company_id" +
                $" where \"Leader\".id = {leader_id}";

            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t\t\t {rdr.GetName(2),10}\t\t {rdr.GetName(3),10} \t {rdr.GetName(4),15}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-3}\t\t {rdr.GetInt32(2),10} \t\t {rdr.GetString(3),10} \t {rdr.GetString(4),15}");
            }
            rdr.Close();

        }
    }
}
