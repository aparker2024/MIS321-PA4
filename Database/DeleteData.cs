using MIS321_PA4.Interfaces;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;

namespace MIS321_PA4.Database
{
    public class DeleteData : IDeleteDAta
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
        void IDeleteDAta.DeleteData(int exerciseID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM exercises WHERE exerciseID= @exerciseID";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@exerciseID",exerciseID);
            cmd.ExecuteNonQuery();
        }

    }
}