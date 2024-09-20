
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ConsoleApp
{
    class Program
    {


        static void AddProgramExecuteNonQueryExample() {

            //Console.WriteLine("  AddProgramExecuteNonQueryExample");
            //connectin first to sql
          
            
        
        }


        static void GetProgramsExecuteReaderExample()
        {
            Console.WriteLine("GetProgramsExecuteReaderExample");

            //connect it first to sql
            SqlConnection MyDataSource = new(); //declaration
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=FARAHNS;Server=(localDB)\MSSQLLocalDB;";
            MyDataSource.Open();


            //set up sql command
            SqlCommand ExampleCommand = new();
            {
                ExampleCommand.Connection = MyDataSource;
                ExampleCommand.CommandType = CommandType.StoredProcedure;
                ExampleCommand.CommandText = "GetPrograms";
            };

            SqlDataReader ExampleDataReader;
            ExampleDataReader=ExampleCommand.ExecuteReader();

            if (ExampleDataReader.HasRows)
            {
                Console.WriteLine("Columns");
                Console.WriteLine("------");

                for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                {

                    Console.WriteLine(ExampleDataReader.GetName(Index));
                }

                Console.WriteLine("Values");
                Console.WriteLine("_");

                while (ExampleDataReader.Read())
                {
                    for(int Index = 0;Index < ExampleDataReader.FieldCount; Index++)
                    {
                        Console.WriteLine(ExampleDataReader[Index].ToString());
                    }
                    Console.WriteLine("_");
                }

                ExampleDataReader.Close();
                MyDataSource.Close();
            }

        }
        static void Main(string[] args)
        {
            //make sure the app is working 
            //Console.WriteLine("Hello world");

            //AddProgramExecuteNonQueryExample();

            GetProgramsExecuteReaderExample();
        }
    }
}