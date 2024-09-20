
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BAIST
{
   internal class Program
    {


        static void AddProgramExecuteNonQueryExample() {

            //Console.WriteLine("  AddProgramExecuteNonQueryExample");
            //connectin first to sql
            SqlConnection MyDataSource;
            MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=FARAH;Server=(localDB)\MSSQLLocalDB;";
            MyDataSource.Open();

            SqlCommand ExampleCommand = new();
            ExampleCommand.Connection = MyDataSource;
            ExampleCommand.CommandType = CommandType.StoredProcedure;
            ExampleCommand.CommandText = "addProgram";

            SqlParameter ExampleCommandParameter;

            ExampleCommandParameter = new()
            {
               ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = "EXAMPLE"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommandParameter = new()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    SqlValue = "EXAMPLE"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommand.ExecuteNonQuery();

            MyDataSource.Close();
            Console.WriteLine("Success- Executenon Query");
        }


        static void GetProgramsExecuteReaderExample()
        {
            //Console.WriteLine("GetProgramsExecuteReaderExample");

            //connect it first to sql
            SqlConnection MyDataSource = new(); //declaration
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=FARAH;Server=(localDB)\MSSQLLocalDB;";
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


        static void GetProgramExecuteReaderExample()
        {
            //Console.WriteLine("GetProgramsExecuteReaderExample");

            //connect it first to sql
            SqlConnection MyDataSource = new(); //declaration
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=FARAH;Server=(localDB)\MSSQLLocalDB;";
            MyDataSource.Open();


            //set up sql command
            SqlCommand ExampleCommand = new();
            {
                ExampleCommand.Connection = MyDataSource;
                ExampleCommand.CommandType = CommandType.StoredProcedure;
                ExampleCommand.CommandText = "GetProgram";
            };

            SqlDataReader ExampleDataReader;
            ExampleDataReader = ExampleCommand.ExecuteReader();

            if (ExampleDataReader.HasRows)
            {
                Console.WriteLine("Columns");
                Console.WriteLine("------");

                for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                {
                     
                    Console.WriteLine(ExampleDataReader.GetName(Index));
                }

                Console.WriteLine("CS101");
                Console.WriteLine("_");

                while (ExampleDataReader.Read())
                {
                    for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                    {
                        Console.WriteLine(ExampleDataReader[Index].ToString());
                    }
                    Console.WriteLine("_");
                }

                ExampleDataReader.Close();
                MyDataSource.Close();
            }

        }



        static void GetProgramExecuteScalarExample()
        {
            Console.WriteLine("GetProgramExecuteScalarExample");
            SqlConnection MyDataSource = new(); //declaration
            MyDataSource.ConnectionString = @"Persist Security Info=False;Integrated Security=True;Database=FARAH;Server=(localDB)\MSSQLLocalDB;";
            MyDataSource.Open();


            SqlCommand ExampleCommand = new();
            {
                ExampleCommand.Connection = MyDataSource;
                ExampleCommand.CommandType = CommandType.StoredProcedure;
                ExampleCommand.CommandText = "GetProgramm";
            };

            SqlParameter ExampleCommandParameter;

            ExampleCommandParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "CS101"
            };
          
         
             ExampleCommand.Parameters.Add(ExampleCommandParameter);

            Console.WriteLine((string)ExampleCommand.ExecuteScalar());

            MyDataSource.Close();
            Console.WriteLine("Success- ExecuteScalar");

        }
        static void Main(string[] args)
        {
            //make sure the app is working 
            //Console.WriteLine("Hello world");

            //AddProgramExecuteNonQueryExample();

            // GetProgramsExecuteReaderExample();
          //  GetProgramExecuteReaderExample();
            GetProgramExecuteScalarExample();


        }
    }
}