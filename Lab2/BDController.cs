using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LehaBD_Lab2
{
    class BDController
    {

        static public void Menu(NpgsqlConnection con)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("\tMain menu");
                Console.WriteLine("1 => Show one table\n2 => Insert data\n3 => Delete  \n4 => Update data\n5 => Search text \n6 => Randomize data in Leader \n7 => Exit");
                int param = Convert.ToInt32(Console.ReadLine());

                switch (param)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine(" 1 => Client \n 2 => Cabinet \n 3 => Company \n 4 => Course \n 5 => Leader \n");
                        int show = Convert.ToInt32(Console.ReadLine());
                        switch(show)
                        {
                            case 1:
                                BDBackend.ReaderClient(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;                               
                            case 2:
                                BDBackend.ReaderCabinet(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 3:
                                BDBackend.ReaderCompany(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 4:
                                BDBackend.ReaderCourse(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 5:
                                BDBackend.ReaderLeader(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine("1 => Client \n 2 => Cabinet \n 3 => Company \n 4 => Course \n 5 => Leader\n");
                        int insert = Convert.ToInt32(Console.ReadLine());
                        switch(insert)
                        {
                            case 1:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Email: ");
                                string email = Console.ReadLine();
                                BDBackend.AddClient(con, id, name, email);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                break;
                            case 3:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int company_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Company Name: ");
                                string company_name = Console.ReadLine();
                                Console.WriteLine("Company country: ");
                                string company_country = Console.ReadLine();
                                Console.WriteLine("Leader id: ");
                                int leader_id = Convert.ToInt32(Console.ReadLine());
                                BDBackend.AddCompany(con, company_id, company_name, company_country,leader_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 4:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int course_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Course Name: ");
                                string course_name = Console.ReadLine();
                                Console.WriteLine("Language: ");
                                string language = Console.ReadLine();
                                Console.WriteLine("Company id: ");
                                int com_id = Convert.ToInt32(Console.ReadLine());
                                BDBackend.AddCourse(con, course_id, course_name, language, com_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 5:
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine("1 => Client \n 2 => Cabinet \n 3 => Company \n 4 => Course \n 5 => Leader\n");
                        int delete = Convert.ToInt32(Console.ReadLine());
                        switch(delete)
                        {
                            case 1:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                BDBackend.DeleteClient(con, id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                break;
                            case 3:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int company_id = Convert.ToInt32(Console.ReadLine());
                                BDBackend.DeleteCompany(con, company_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 4:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int course_id = Convert.ToInt32(Console.ReadLine());
                                BDBackend.DeleteCourse(con, course_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 5:
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine("1 => Client \n 2 => Cabinet \n 3 => Company \n 4 => Course \n 5 => Leader\n");
                        int update = Convert.ToInt32(Console.ReadLine());
                        switch(update)
                        {
                            case 1:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Email: ");
                                string email = Console.ReadLine();
                                BDBackend.UpdateClient(con, id, name, email);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
               
                                break;
                            case 3:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int company_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Company Name: ");
                                string company_name = Console.ReadLine();
                                Console.WriteLine("Company country: ");
                                string company_country = Console.ReadLine();
                                Console.WriteLine("Leader id: ");
                                int leader_id = Convert.ToInt32(Console.ReadLine());
                                BDBackend.UpdateCompany(con, company_id, company_name, company_country, leader_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 4:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int course_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Course Name: ");
                                string course_name = Console.ReadLine();
                                Console.WriteLine("Language: ");
                                string language = Console.ReadLine();
                                Console.WriteLine("Company id: ");
                                int com_id = Convert.ToInt32(Console.ReadLine());
                                BDBackend.UpdateCourse(con, course_id, course_name, language, com_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 5:
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Choose search");
                        Console.WriteLine("1 => Поиск идентификатора и названия курса по идентифиатору клиента  \n 2 =>Поиск названия, идентификатора курса, и названия компании, что выпустила этот курс по идентификатору директора компании");
                        int search = Convert.ToInt32(Console.ReadLine());
                        switch (search)
                        {
                            case 1:
                                BDBackend.DynamicSearch1(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                BDBackend.DynamicSearch2(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 6:
                        BDBackend.RandomLeader(con);
                        Console.WriteLine("To proceed press Enter");
                        Console.ReadKey(true);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default: break;                
                }


            }

        }
    }
}
