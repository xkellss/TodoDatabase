using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TodoDatabase.Data;
using TodoDatabase.Models;


namespace TodoDatabase.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        //dependency injection creates/passes an instance of TodoDatabaseContext
        //"_context" holds database context  gives access to TOdoTasks table

        private readonly TodoDatabaseContext _context;

        public TodoController(TodoDatabaseContext context)
        {
            _context = context; 
        }

        [HttpGet] //read data
        //action Result -returns list of TodoTask objects 
        public  async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks(){ //GetTasks() method name to fetch data
            return await _context.TodoTasks.ToListAsync(); //EF to fetch all records from ToDo table
            // Async converts it into a list
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TodoTask todotask)
        {
            todotask.Id = Guid.NewGuid(); //dont want to passs todo guid from ui, everytime we create tassk we want to assign id from backend

            _context.TodoTasks.Add(todotask);

           await _context.SaveChangesAsync();

            return Ok(todotask);
        }



        //IGNORE - from past video using ADO.NET 
        //public JsonResult GetNotes()
        //{
        //    //query to get data
        //    string query = "Select * from dbo.Notes";
        //    DataTable table = new DataTable();
        //    string sqlDatasource = _configuration.GetConnectionString("todoAppDBCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDatasource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}
    }
}

