using MIS321_PA4.Interfaces;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;

namespace MIS321_PA4.Database
{
    public class UpdateData : IUpdateData
    {
        void IUpdateData.UpdateData(Exercise value)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand(cs,con);

            cmd.CommandText= @"UPDATE exercises set activityType = @activityType, distanceMiles = @distanceMiles, completionDate = @completionDate, Pinned = @pinned, Deleted = @Deleted WHERE exerciseID = @exerciseID";
            cmd.Parameters.AddWithValue("@exerciseID", value.exerciseID);
            cmd.Parameters.AddWithValue("@activityType", value.activityType);
            cmd.Parameters.AddWithValue("@distanceMiles", value.distanceMiles);
            cmd.Parameters.AddWithValue("@completionDate", value.completionDate);
            cmd.Parameters.AddWithValue("@Pinned", value.Pinned);
            cmd.Parameters.AddWithValue("@Deleted", value.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }


    }
}
