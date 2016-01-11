using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADODemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var DataReadSample = new DataReadSample();
            var DataWritesample = new DataWriteSample();
            DataWritesample.runDataWrite();
            //DataReadSample.RunDemoRead();
        }

    }
    class DataReadSample
    {
        public void RunDemoRead()
                {
                    try 
                    {
                        //Sql Connection constructor
                        string query = "SELECT * FROM Categories ;";
                        using (SqlConnection Connection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;" +
                                                                     "AttachDbFilename=C:\\Users\\NSCCSTUDENT\\Source\\Repos\\DBAS\\ADODemo\\ADODemo\\Northwind.mdf;" +
                                                                     "Integrated Security = True"))
                        {
                            Connection.Open();
                            Console.WriteLine("Successful Connection");
                            using (SqlCommand command = new SqlCommand(query, Connection))
                            {
                                //command.Parameters.AddWithValue("@PricePoint", 100);
                                SqlDataReader reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    int readerHelper = 0;
                                    Console.WriteLine("\t{0}\t{1}\t{2}", reader[readerHelper], reader[readerHelper+1], reader[readerHelper+2]);
                                    
                                }
                            }
                            Console.ReadLine();


                        }
                    }
    
                    catch(SqlException sqlex)
                    {
                        Console.WriteLine("Sql Connection error: " + sqlex.Message);
                    }

                    catch(Exception ex)
                    {
                           Console.WriteLine("Global Error: " + ex.Message);
                    }   
        
            


                    //Alternate Sql Connection - Literal use of a string - does not need extra \ as escape character
                //SqlConnection ConnectionAlt = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;" +
                //                                                 "AttachDbFilename=C:\Users\NSCCSTUDENT\Source\Repos\DBAS\ADODemo\ADODemo\Northwind.mdf;" +
                //                                                 "Integrated Security = True");
            }
        
        }

    class DataWriteSample
    {
        public void runDataWrite()
            {
                try
                {
                    using (SqlConnection Connection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;" +
                                                                         "AttachDbFilename=C:\\Users\\NSCCSTUDENT\\Source\\Repos\\DBAS\\ADODemo\\ADODemo\\Northwind.mdf;" +
                                                                         "Integrated Security = True"))
                    {
                        string Name = Console.ReadLine();
                        string Description = Console.ReadLine();
                        Connection.Open();
                        string query = "INSERT INTO Categories (CategoryName, Description)" +
                                       " VALUES('" + Name + "', '" + Description + "'); ";
                        using (SqlCommand command = new SqlCommand(query, Connection))
                            {
                                SqlDataReader reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    int readerHelper = 0;
                                    Console.WriteLine("\t{0}\t{1}\t{2}", reader[readerHelper], reader[readerHelper + 1], reader[readerHelper + 2]);

                                }
                            }
                        Console.ReadLine();
                    }   
                    
                }

                catch (Exception e)
                {
                    Console.WriteLine("General Error: " + e.Message);
                }


            }
    }
}
