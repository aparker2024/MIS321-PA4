namespace MIS321_PA4
{
    public class ConnectionString
    {
        
        public string cs {get;set;}

        public ConnectionString()
        {
            string server = "lyn7gfxo996yjjco.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database ="npzvks221ti9ak4w";
            string port ="3306";
            string username ="ca9me552kzuqnlr0";
            string password ="dwnuzusl16hkj5bl";


            cs = $@"server = {server};username={username};database={database};port={port};password={password}";
            
        }
    }
}

