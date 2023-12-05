using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.Database;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        // GET: api/Exercise
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Exercise> Get()
        {
        IReadAllData readObject = new ReadData();
        return readObject.GetAllExercises();
        }

        // GET: api/Exercise/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Exercise Get(int id)
        {
            IGetBook readObject = new ReadData();
            return readObject.GetExercise(id);
        }

        // POST: api/Exercise
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Exercise value)
        {
            System.Console.WriteLine(value.activityType);
            ISaveAllData insertObject = new SaveData();
            insertObject.CreateExercise(value);
        }

        // PUT: api/Exercise/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Exercise value)
        {
            IUpdateData update = new UpdateData();
            update.UpdateData(value, id);

        }

        // DELETE: api/Exercise/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteData deletes = new DeleteData();
            deletes.DeleteData(id);
        }
    }
}


