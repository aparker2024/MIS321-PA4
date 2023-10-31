namespace API.Models.Interfaces
{
    public interface ISaveAllData
    {
        public void CreateExercise(Exercise value);
        public void SaveExercise(Exercise value); 
    }
}