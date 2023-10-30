//SQLiteConnection - creates a connection to a specific data source
//SQLiteCommand - exectues an SQL statement against a data source
//SQLiteDataReader - reads streams of data from a data source
// using statement - drop string after use 

using System.Buffers;
using System.Data.SQLite;
using MIS321_PA4;
using MIS321_PA4.Database;
using MIS321_PA4.Interfaces;

// string cs = @"URI=file:C:\Users\apark\OneDrive - The University of Alabama\MIS321-fall2023\PA's\MIS321-PA4\PA4.db";

// using var con = new SQLiteConnection(cs);

// con.Open();

// string stm = "select SQLite_VERSION()";

// using var cmd = new SQLiteCommand(stm, con);

// string version = cmd.ExecuteScalar().ToString();

// System.Console.WriteLine($"SQLite version: {version}"); // check SQLite version 



//reads through list of exercise and prints data
IReadData readObject = new ReadData();
List<Exercise> allExercises = readObject.GetAllExercises();
foreach(Exercise exercise in allExercises)
{
    System.Console.WriteLine(exercise.ToString());
}

//testing 
// DeleteData.DropExerciseTable(); //delete table
// SaveData.CreateExerciseTable(); //create new table


Exercise exercises = new Exercise();
// exercises.SaveData.CreateExercise(exercises);

// IUpdateData update = new UpdateData();
// allExercises[0].completionDate = "2023-10-22";
// update.UpdateData(allExercises[0]); //updates and saves
// System.Console.WriteLine("\n\n");
// foreach(Exercise exercise in allExercises)
// {
//     System.Console.WriteLine(exercise.ToString());
// }

System.Console.WriteLine($"which would you like to delete?");
int userInput = int.Parse(Console.ReadLine());
IDeleteDAta delete = new DeleteData();
delete.DeleteData(userInput);


