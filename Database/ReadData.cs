
using System.Data.SQLite;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace MIS321_PA4.Database
{
    public class ReadData : IReadData
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

    }
}