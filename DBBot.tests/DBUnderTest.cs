using System;
using System.IO;
using Xunit;
using DBBot;
using Microsoft.Data.Sqlite;

namespace DBBot.tests
{
    public class DBUnderTest
    {
        public string phoneNumber = "4372154615";
        public int    password    = 1234;
        public string hierarchy   = "Driver"; 
        public string firstName   = "Heloisa"; 
        public string lastName    = "Prog8060";
        public string dateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

        [Fact]
        public void TestPersonTable()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandDelete = connection.CreateCommand();
                var commandInsert = connection.CreateCommand();

                //Deleting the content to execute the tests
                commandDelete.CommandText =
                @"DELETE FROM Person";
                int nRowsDeleted  = commandDelete.ExecuteNonQuery();
                
                //DBTC1 - Adding a Driver
                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $dateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber", phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"   , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"  , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"  , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"   , lastName);
                commandInsert.Parameters.AddWithValue("$dateRegist" , dateRegist);
                int nRowsInserted = commandInsert.ExecuteNonQuery();

                //DBTC4 - Adding a Driver - Phone Number alread exists
                try
                {
                    commandInsert.CommandText =
                    @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                      VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $dateRegist)";
                    commandInsert.Parameters.AddWithValue("$phoneNumber", phoneNumber);
                    commandInsert.Parameters.AddWithValue("$password"   , password);
                    commandInsert.Parameters.AddWithValue("$hierarchy"  , hierarchy);
                    commandInsert.Parameters.AddWithValue("$firstName"  , firstName);
                    commandInsert.Parameters.AddWithValue("$lastName"   , lastName);
                    commandInsert.Parameters.AddWithValue("$dateRegist" , dateRegist);
                    nRowsInserted = commandInsert.ExecuteNonQuery();
                }
                catch (System.Exception)
                {
                    Console.Write("False Negative");                     
                }
            }
        }
    }
}
