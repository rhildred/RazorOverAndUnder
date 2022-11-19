using Microsoft.Data.Sqlite;

namespace OrderBot
{
    public class Order : ISQLModel
    {
        private string _size = String.Empty;
        private string _phone = String.Empty;
        private string _veggies1 = String.Empty;
        private string _veggies2 = String.Empty;
        private string _curry1 = String.Empty;
        private string _curry2 = String.Empty;
        private string _dessert1 = String.Empty;


        public string Phone { get => _phone; set => _phone = value; }
        public string Size { get => _size; set => _size = value; }
        public string Veggies1 { get => _veggies1; set => _veggies1 = value; }
        public string Veggies2 { get => _veggies2; set => _veggies2 = value; }
        public string Curry1 { get => _curry1; set => _curry1 = value; }
        public string Curry2 { get => _curry2; set => _curry2 = value; }
        public string Dessert1 { get => _dessert1; set => _dessert1 = value; }

        public void Save(){
           using (var connection = new SqliteConnection(DB.GetConnectionString()))
            {
                connection.Open();

                var commandUpdate = connection.CreateCommand();
                commandUpdate.CommandText =
                @"
        UPDATE orders
        SET size = $size
        WHERE phone = $phone
    ";
                commandUpdate.Parameters.AddWithValue("$size", Size);
                commandUpdate.Parameters.AddWithValue("$phone", Phone);
                int nRows = commandUpdate.ExecuteNonQuery();
                if(nRows == 0){
                    var commandInsert = connection.CreateCommand();
                    commandInsert.CommandText =
                    @"
            INSERT INTO orders(size, phone)
            VALUES($size, $phone)
        ";
                    commandInsert.Parameters.AddWithValue("$size", Size);
                    commandInsert.Parameters.AddWithValue("$phone", Phone);
                    int nRowsInserted = commandInsert.ExecuteNonQuery();

                }
            }

        }
    }
}
