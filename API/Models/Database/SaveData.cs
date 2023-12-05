using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Database
{
    public class SaveData : ISaveAllData
    {
        public static void CreateExerciseTable() //create table for data
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE exercises(exerciseID INTEGER PRIMARY KEY AUTO_INCREMENT, activityType TEXT, distanceMiles INTEGER, completionDate TEXT, Pinned BOOL, Deleted TEXT)";
            
            using var cmd = new MySqlCommand(stm,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void CreateExercise(Exercise value) //inserrt data
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO exercises(activityType, distanceMiles, completionDate, Pinned, Deleted) VALUES(@activityType, @distanceMiles, @completionDate, @Pinned, @Deleted)";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@activityType", value.activityType);
            cmd.Parameters.AddWithValue("@distanceMiles", value.distanceMiles);
            cmd.Parameters.AddWithValue("@completionDate", value.completionDate);
            cmd.Parameters.AddWithValue("@Pinned", value.Pinned);
            cmd.Parameters.AddWithValue("@Deleted", value.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
             con.Close();
        }



        void ISaveAllData.SaveExercise(Exercise value)
        {
            
        }

    }
}