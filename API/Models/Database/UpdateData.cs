using System.Runtime.CompilerServices;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models.Database
{
    public class UpdateData : IUpdateData
    {
         void IUpdateData.UpdateData(Exercise value, int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand(cs,con);
      
            cmd.CommandText= @"Update exercises SET Pinned = 'Yes' WHERE exerciseID = @exerciseID";
           
            cmd.Parameters.AddWithValue("@exerciseID", id);
          
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
        }

    }
}