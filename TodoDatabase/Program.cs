using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Newtonsoft.Json.Serialization;
using TodoDatabase.Data;
using TodoDatabase.Models;

//using TodoDatabaseContext context = new TodoDatabaseContext();



//Creating new task without Name or Description 
//TodoTask nullTask = new TodoTask()
//{
//    Id = Guid.NewGuid()
//     // no desc or name here
//};
//context.TodoTasks.Add(nullTask);
//context.SaveChanges();

// output - database did not update and reeceived Null error in console when required was removed


//adding task 
//----------------------------------------


//TodoTask taskThree = new TodoTask()
//                     {
//                         Name = "Task 3",
//                         Description = " This is task 3."
//                     };
//TodoTask taskFour = new TodoTask()
//{
//    Name = "Task 4",
//    Description = " This is task 4."
//};
//context.TodoTasks.Add(taskThree);
//context.TodoTasks.Add(taskFour);

//try
//{
//    context.SaveChanges();
//}
//catch(Exception ex)
//{

//}



//Update Entity 
//------------------------------------------
//query table to find "task 3" name
//try
//{
//    var taskThree = context.TodoTasks
//        .Where(t => t.Name == "Task 3").FirstOrDefault();

//    if (taskThree != null)
//    {
//        taskThree.Description = "This is an important task 3";
//        context.SaveChanges();
//    }
//    else
//    {
//        Console.WriteLine("Task 3 not found");
//    }
//}
//catch(Exception ex)
//{
//    Console.WriteLine("Updating Error "+ ex.Message);
//}
    

//Delete Entity
//---------------------------------------------------
//var taskFour = context.TodoTasks
//    .Where(t => t.Name == "Task 4").FirstOrDefault();
//if (taskFour is TodoTask)
//{
//    context.Remove(taskFour);
//}
//context.SaveChanges();


//Output Tasks
//----------------------------------

//try
//{
//    var tasks = context.TodoTasks
//    .OrderBy(t => t.Name);

//    foreach (TodoTask t in tasks)
//    {
//        Console.WriteLine($"Name: {t.Name}");
//        Console.WriteLine($"Description: {t.Description}");
//    }
//}
//catch(Exception ex)
//{
//    Console.WriteLine( "**Error has occurred**" + ex.Message);   

//}




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TodoDatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("todoAppDBCon")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//JSON Serializer
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options=>options.SerializerSettings.ContractResolver=new DefaultContractResolver());

var app = builder.Build();


//Enable Cors to consume services from front end project
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
