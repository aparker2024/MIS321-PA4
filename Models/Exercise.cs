using MIS321_PA4.Database;

namespace MIS321_PA4
{
    public class Exercise
    {
        public int exerciseID{get;set;}
       
        public string activityType{get;set;}
        public int distanceMiles{get;set;}
        public string completionDate{get;set;}
        public string Pinned{get;set;}
        public string Deleted{get;set;}


        
        public ISaveData SaveData {get;set;}

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