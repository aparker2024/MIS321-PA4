using API.Models.Database;
using API.Models.Interfaces;

namespace API.Models
{
    public class Exercise
    {
        public int exerciseID{get;set;}
       
        public string activityType{get;set;}
        public int distanceMiles{get;set;}
        public string completionDate{get;set;}
        public string Pinned{get;set;}
        public string Deleted{get;set;}


        
        public ISaveAllData SaveData {get;set;}

        public Exercise()
        {
            SaveData = new SaveData();
        }
        public override string ToString()
        {
            return $"Exercise {exerciseID} - {activityType} {distanceMiles} miles on {completionDate}";
        }
    }
}