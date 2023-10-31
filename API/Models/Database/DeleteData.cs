using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Database
{
    public class DeleteData : IDeleteData
    {
     
        public static void DropExerciseTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS exercises";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
        void IDeleteData.DeleteData(int exerciseID) //soft delete
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"Update exercises SET Deleted = 'Yes' WHERE exerciseID= @exerciseID";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@exerciseID",exerciseID);
            cmd.ExecuteNonQuery();
            
        }
        

    }
}

