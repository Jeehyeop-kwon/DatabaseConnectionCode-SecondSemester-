using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ConsoleAppAdo.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlConnectionString = @"Server = aws.computerstudi.es;UserId = gcc200199736; Password = TC2yJiWaKY; Database = gcc200199736;";

            MySqlConnection mySql = new MySqlConnection(sqlConnectionString);
            mySql.Open();
            Console.WriteLine("Connected!");


            try
            {
                MySqlCommand com = new MySqlCommand("SELECT count(*) FROM customers", mySql);
                var result = com.ExecuteScalar();
                Console.WriteLine(result + "customers were found");

                DataSet dataResult = new DataSet();
                MySqlCommand comA = new MySqlCommand("SELECT * FROM customers", mySql);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comA);
                adapter.Fill(dataResult);
                Console.WriteLine(dataResult.Tables[0].Rows.Count + " customers were found.");

                foreach (DataColumn item in dataResult.Tables[0].Columns) 
                {
                    Console.Write(item.ColumnName + " ");
                }
                Console.WriteLine();

                foreach (DataRow item in dataResult.Tables[0].Rows)
                {
                    for (int i = 0; i < dataResult.Tables[0].Columns.Count; i++) 
                    {
                        Console.Write(item[i] + " ");
                      
                    }
                    Console.WriteLine();
                }

                comA.CommandText = "insert into customers(first_name, last_name)" + "values('Kevin9898443252','li')";
                comA.ExecuteNonQuery();

                comA.CommandText = "update customers set email_address = @email" + "where id = 30";
                comA.Parameters.Add(new MySqlParameter("email", "948585st@gmail.com"));
                comA.ExecuteNonQuery();

                comA.CommandText = "select email_address from customers" + "where id = 31";
                Console.WriteLine(comA.ExecuteScalar());

               
            }

            catch (Exception)
            {
                mySql.Close();
                Console.WriteLine("Disconnected!");

            }

            finally
            {
                mySql.Close();
            }

            Console.ReadLine();
        }

    }


}
