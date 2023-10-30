
using System.Security.Claims;
using MySql.Data.MySqlClient;

namespace MIS321_PA4.Database
{
    public class SaveData : ISaveData
    {

       
        public static void CreateExerciseTable() //create table for data
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE exercises(exerciseID INTEGER PRIMARY KEY AUTO_INCREMENT, activityType TEXT, distanceMiles INTEGER, completionDate TEXT, Pinned TEXT, Deleted TEXT)";
            
            using var cmd = new MySqlCommand(stm,con);
            cmd.ExecuteNonQuery();
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
        }



        void ISaveData.SaveExercise(Exercise value)
        {
            
        }

        // public void SeedData(Exercise exercise) //point of seeding data is to get initial data out, for testing data to be deleted
        // {
        //     // created connection string, connected to data base, and opened data base
        //     ConnectionString myConnection = new ConnectionString();
        //     string cs = myConnection.cs;       
        //     using var con = new MySqlConnection(cs);
        //     con.Open();

        //     using var cmd = new MySqlCommand(cs, con);

        //     //drops table why? - to delete testing tables
        //     cmd.CommandText = "DROP TABLE IF EXISTS exercises";
        //     cmd.ExecuteNonQuery();

        //     //creates table
        //     cmd.CommandText = @"CREATE TABLE exercises(exerciseID INTEGER PRIMARY KEY, activityType TEXT, distanceMiles INTEGER, completionDate DATE, Pinned TEXT, Deleted TEXT)";
        //     cmd.ExecuteNonQuery();

        //     //prepared statements - avoid enjection attack by creating parameters as placeholders and update the parameter to execute the query
        //     cmd.CommandText = @"INSERT INTO exercises(activityType, distanceMiles, completionDate, Pinned, Deleted) VALUES(@activityType, @distanceMiles, @completionDate, @Pinned, @Deleted)" ;
        //     cmd.Parameters.AddWithValue("@activityType", exercise.activityType);
        //     cmd.Parameters.AddWithValue("@distanceMiles", exercise.distanceMiles);
        //     cmd.Parameters.AddWithValue("@completionDate", exercise.completionDate);
        //     cmd.Parameters.AddWithValue("@Pinned", exercise.Pinned);
        //     cmd.Parameters.AddWithValue("@Deleted", exercise.Deleted);
        //     cmd.Prepare();
        //     cmd.ExecuteNonQuery();

        //     cmd.CommandText = @"INSERT INTO exercises(activityType, distanceMiles, completionDate, Pinned, Deleted) VALUES(@activityType, @distanceMiles, @completionDate, @Pinned, @Deleted)" ;
        //      cmd.Parameters.AddWithValue("@activityType", exercise.activityType);
        //     cmd.Parameters.AddWithValue("@distanceMiles", exercise.distanceMiles);
        //     cmd.Parameters.AddWithValue("@completionDate", exercise.completionDate);
        //     cmd.Parameters.AddWithValue("@Pinned", exercise.Pinned);
        //     cmd.Parameters.AddWithValue("@Deleted", exercise.Deleted);
        //     cmd.Prepare();
        //     cmd.ExecuteNonQuery();

        //     cmd.CommandText = @"INSERT INTO exercises(activityType, distanceMiles, completionDate, Pinned, Deleted) VALUES(@activityType, @distanceMiles, @completionDate, @Pinned, @Deleted)" ;
        //      cmd.Parameters.AddWithValue("@activityType", exercise.activityType);
        //     cmd.Parameters.AddWithValue("@distanceMiles", exercise.distanceMiles);
        //     cmd.Parameters.AddWithValue("@completionDate", exercise.completionDate);
        //     cmd.Parameters.AddWithValue("@Pinned", exercise.Pinned);
        //     cmd.Parameters.AddWithValue("@Deleted", exercise.Deleted);
        //     cmd.Prepare();
        //     cmd.ExecuteNonQuery();

      

        // }


    }
}