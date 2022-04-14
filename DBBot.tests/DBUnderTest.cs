using System;
using System.IO;
using Xunit;
using DBBot;
using Microsoft.Data.Sqlite;

namespace DBBot.tests
{
    public class DBUnderTest
    {

        public int nRowsInserted = 0;

        public string phoneNumber  = "4372154699";
        public int    password     = 1234;
        public string hierarchy    = "Driver"; 
        public string firstName    = "Heloisa"; 
        public string lastName     = "Prog8060";
        public string pDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

        public string licensePlate = "A1A1A1"; 
        public string typeVehicle  = "Van";
        public string vDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

        public int    orderNumber  = 1; 
        public int    qtyProducts  = 3;
        public string oDateRegist  = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

        public string person_PhoneNumber   = "4372154699"; 
        public string vehicle_LicensePlate = "A1A1A1"; 
        public int    order_OrderNumber    = 1; 
        public string dDateRegist          = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

        public string dateReceived          = DateTime.UtcNow.ToString("yyyy-MM-dd");
        public string timeReceived          = DateTime.UtcNow.ToString("hh:mm");
        public int    valueReceived         = 12345;
        public string oVehicle_LicensePlate = "A1A1A1"; 
        public string oPerson_PhoneNumber   = "4372154699"; 

        [Fact]
        public void DeletePersonTable()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandDelete = connection.CreateCommand();

                //Deleting Person table
                commandDelete.CommandText = @"DELETE FROM Person";
                int nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Deleting Vehicle table
                commandDelete.CommandText = @"DELETE FROM Vehicle";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Deleting Order table
                commandDelete.CommandText = @"DELETE FROM Order";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Deleting Delivery table
                commandDelete.CommandText = @"DELETE FROM Delivery";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                //Deleting Odometer table
                commandDelete.CommandText = @"DELETE FROM Odometer";
                nRowsDeleted  = commandDelete.ExecuteNonQuery();

                connection.Close();    
            }
        }

        [Fact]
        public void DBTC01()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();   

            }
        }

        [Fact]
        public void DBTC02()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                //DBTC4 - Adding a Driver - Duplicated 
                commandInsert.CommandText =
                @"INSERT INTO Person(PhoneNumber, Password, Hierarchy, FirstName, LastName, DateRegist)
                  VALUES($phoneNumber, $password, $hierarchy, $firstName, $lastName, $pDateRegist)";
                commandInsert.Parameters.AddWithValue("$phoneNumber" , phoneNumber);
                commandInsert.Parameters.AddWithValue("$password"    , password);
                commandInsert.Parameters.AddWithValue("$hierarchy"   , hierarchy);
                commandInsert.Parameters.AddWithValue("$firstName"   , firstName);
                commandInsert.Parameters.AddWithValue("$lastName"    , lastName);
                commandInsert.Parameters.AddWithValue("$pDateRegist" , pDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC03()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                //DBTC5 - Adding a new Vehicle - Positive scenario 
                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC04()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                //DBTC5 - Adding a new Vehicle - Positive scenario 
                commandInsert.CommandText =
                @"INSERT INTO Vehicle(LicensePlate, TypeVehicle, DateRegist)
                  VALUES($licensePlate, $typeVehicle, $vDateRegist)";
                commandInsert.Parameters.AddWithValue("$licensePlate", licensePlate);
                commandInsert.Parameters.AddWithValue("$typeVehicle" , typeVehicle);
                commandInsert.Parameters.AddWithValue("$vDateRegist" , vDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC05()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                //DBTC7 - Adding a new Order - Positive scenario 
                commandInsert.CommandText =
                @"INSERT INTO Order(OrderNumber, QtyProducts, DateRegist)
                  VALUES($orderNumber, $qtyProducts, $oDateRegist)";
                commandInsert.Parameters.AddWithValue("$orderNumber" , orderNumber);
                commandInsert.Parameters.AddWithValue("$qtyProducts" , qtyProducts);
                commandInsert.Parameters.AddWithValue("$oDateRegist" , oDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC06()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                //DBTC9 - Adding a new Order - Negative scenario 
                commandInsert.CommandText =
                @"INSERT INTO Order(OrderNumber, QtyProducts, DateRegist)
                  VALUES($orderNumber, $qtyProducts, $oDateRegist)";
                commandInsert.Parameters.AddWithValue("$orderNumber" , orderNumber);
                commandInsert.Parameters.AddWithValue("$qtyProducts" , qtyProducts);
                commandInsert.Parameters.AddWithValue("$oDateRegist" , oDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC07()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                //DBTC11 - Adding a new Delivery - Positive scenario 
                commandInsert.CommandText =
                @"INSERT INTO Delivery(Person_PhoneNumber, Vehicle_LicensePlate, Order_OrderNumber, DateDelivered)
                  VALUES($person_PhoneNumber, $vehicle_LicensePlate, $order_OrderNumber, $dDateRegist)";
                commandInsert.Parameters.AddWithValue("$person_PhoneNumber"   , person_PhoneNumber);
                commandInsert.Parameters.AddWithValue("$vehicle_LicensePlate" , vehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$order_OrderNumber"    , order_OrderNumber);
                commandInsert.Parameters.AddWithValue("$dDateRegist"          , dDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC08()
        {
            person_PhoneNumber   = "4372154601"; 
            vehicle_LicensePlate = "A1A1A1"; 
            order_OrderNumber    = 1; 
            dDateRegist          = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                //DBTC11 - Adding a new Delivery - Positive scenario 
                commandInsert.CommandText =
                @"INSERT INTO Delivery(Person_PhoneNumber, Vehicle_LicensePlate, Order_OrderNumber, DateDelivered)
                  VALUES($person_PhoneNumber, $vehicle_LicensePlate, $order_OrderNumber, $dDateRegist)";
                commandInsert.Parameters.AddWithValue("$person_PhoneNumber"   , person_PhoneNumber);
                commandInsert.Parameters.AddWithValue("$vehicle_LicensePlate" , vehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$order_OrderNumber"    , order_OrderNumber);
                commandInsert.Parameters.AddWithValue("$dDateRegist"          , dDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC09()
        {
            person_PhoneNumber   = "4372154699"; 
            vehicle_LicensePlate = "A2A2A2"; 
            order_OrderNumber    = 1; 
            dDateRegist          = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                commandInsert.CommandText =
                @"INSERT INTO Delivery(Person_PhoneNumber, Vehicle_LicensePlate, Order_OrderNumber, DateDelivered)
                  VALUES($person_PhoneNumber, $vehicle_LicensePlate, $order_OrderNumber, $dDateRegist)";
                commandInsert.Parameters.AddWithValue("$person_PhoneNumber"   , person_PhoneNumber);
                commandInsert.Parameters.AddWithValue("$vehicle_LicensePlate" , vehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$order_OrderNumber"    , order_OrderNumber);
                commandInsert.Parameters.AddWithValue("$dDateRegist"          , dDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC10()
        {
            person_PhoneNumber   = "4372154699"; 
            vehicle_LicensePlate = "A1A1A1"; 
            order_OrderNumber    = 2; 
            dDateRegist          = DateTime.UtcNow.ToString("yyyy-MM-dd"); 

            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                commandInsert.CommandText =
                @"INSERT INTO Delivery(Person_PhoneNumber, Vehicle_LicensePlate, Order_OrderNumber, DateDelivered)
                  VALUES($person_PhoneNumber, $vehicle_LicensePlate, $order_OrderNumber, $dDateRegist)";
                commandInsert.Parameters.AddWithValue("$person_PhoneNumber"   , person_PhoneNumber);
                commandInsert.Parameters.AddWithValue("$vehicle_LicensePlate" , vehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$order_OrderNumber"    , order_OrderNumber);
                commandInsert.Parameters.AddWithValue("$dDateRegist"          , dDateRegist);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC11()
        {
            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                commandInsert.CommandText =
                @"INSERT INTO Odometer(DateReceived, TimeReceived, ValueReceived, Vehicle_LicensePlate, Person_PhoneNumber)
                  VALUES($dateReceived, $timeReceived, $valueReceived, $oVehicle_LicensePlate, $oPerson_PhoneNumber)";
                commandInsert.Parameters.AddWithValue("$dateReceived"          , dateReceived);
                commandInsert.Parameters.AddWithValue("$timeReceived"          , timeReceived);
                commandInsert.Parameters.AddWithValue("$valueReceived"         , valueReceived);
                commandInsert.Parameters.AddWithValue("$oVehicle_LicensePlate" , oVehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$oPerson_PhoneNumber"   , oPerson_PhoneNumber);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC12()
        {
            dateReceived          = DateTime.UtcNow.ToString("yyyy-MM-dd");
            timeReceived          = DateTime.UtcNow.ToString("hh:mm");
            valueReceived         = 12345;
            oVehicle_LicensePlate = "A1A1A1"; 
            oPerson_PhoneNumber   = "4372154601"; 

            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                commandInsert.CommandText =
                @"INSERT INTO Odometer(DateReceived, TimeReceived, ValueReceived, Vehicle_LicensePlate, Person_PhoneNumber)
                  VALUES($dateReceived, $timeReceived, $valueReceived, $oVehicle_LicensePlate, $oPerson_PhoneNumber)";
                commandInsert.Parameters.AddWithValue("$dateReceived"          , dateReceived);
                commandInsert.Parameters.AddWithValue("$timeReceived"          , timeReceived);
                commandInsert.Parameters.AddWithValue("$valueReceived"         , valueReceived);
                commandInsert.Parameters.AddWithValue("$oVehicle_LicensePlate" , oVehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$oPerson_PhoneNumber"   , oPerson_PhoneNumber);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }

        [Fact]
        public void DBTC13()
        {
            dateReceived          = DateTime.UtcNow.ToString("yyyy-MM-dd");
            timeReceived          = DateTime.UtcNow.ToString("hh:mm");
            valueReceived         = 12345;
            oVehicle_LicensePlate = "A2A2A2"; 
            oPerson_PhoneNumber   = "4372154699"; 

            using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandInsert = connection.CreateCommand();

                commandInsert.CommandText =
                @"INSERT INTO Odometer(DateReceived, TimeReceived, ValueReceived, Vehicle_LicensePlate, Person_PhoneNumber)
                  VALUES($dateReceived, $timeReceived, $valueReceived, $oVehicle_LicensePlate, $oPerson_PhoneNumber)";
                commandInsert.Parameters.AddWithValue("$dateReceived"          , dateReceived);
                commandInsert.Parameters.AddWithValue("$timeReceived"          , timeReceived);
                commandInsert.Parameters.AddWithValue("$valueReceived"         , valueReceived);
                commandInsert.Parameters.AddWithValue("$oVehicle_LicensePlate" , oVehicle_LicensePlate);
                commandInsert.Parameters.AddWithValue("$oPerson_PhoneNumber"   , oPerson_PhoneNumber);
                nRowsInserted = commandInsert.ExecuteNonQuery();

                connection.Close();             
            }
        }
    }
}
