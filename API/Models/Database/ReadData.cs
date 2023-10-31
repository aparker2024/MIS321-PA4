using API.Models.Interfaces;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;

namespace API.Models.Database
{
    public class ReadData : IReadAllData, IGetBook
    {
         public List<Exercise> GetAllExercises()
        {
            List<Exercise> allExercises = new List<Exercise>();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM exercises";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read()) // while this is returning data
            {
                allExercises.Add(new Exercise(){exerciseID=rdr.GetInt32(0),activityType=rdr.GetString(1),distanceMiles=rdr.GetInt32(2),completionDate=rdr.GetString(3),Pinned=rdr.GetString(4),Deleted=rdr.GetString(5)});
            }

            return allExercises;
        }

        

        public Exercise GetExercise(int exerciseID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM exercises WHERE exerciseID = @exerciseID";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@exerciseID", exerciseID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();

            return new Exercise(){exerciseID=rdr.GetInt32(0),activityType=rdr.GetString(1),distanceMiles=rdr.GetInt32(2),completionDate=rdr.GetString(3),Pinned=rdr.GetString(4),Deleted=rdr.GetString(5)};
        }
    }
}