using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using TodoDatabase.Data;
using TodoDatabase.Models;

using TodoDatabaseContext context = new TodoDatabaseContext();

//adding task 
//----------------------------------------
//TodoTask taskThree = new TodoTask()
//{
//    Name = "Task 3",
//    Description = " This is task 3."
//};
//TodoTask taskFour = new TodoTask()
//{
//    Name = "Task 4",
//    Description = " This is task 4."
//};
//context.TodoTasks.Add(taskThree);
//context.TodoTasks.Add(taskFour);
//context.SaveChanges();



//Update Entity 
//------------------------------------------
//query table to find "task 3" name

//var taskThree = context.TodoTasks
//    .Where(t => t.Name == "Task 3").FirstOrDefault();

//if (taskThree is TodoTask)
//{
//    taskThree.Description = "This is an important task 3";
//}
//context.SaveChanges();


//Delete Entity
//---------------------------------------------------
var taskFour = context.TodoTasks
    .Where(t => t.Name == "Task 4").FirstOrDefault();
if (taskFour is TodoTask)
{
    context.Remove(taskFour);
}
context.SaveChanges();


//Output Tasks
//----------------------------------
var tasks = context.TodoTasks
    .OrderBy(t => t.Name);

foreach ( TodoTask t in tasks)
{
    Console.WriteLine( $"Name: {t.Name}");
    Console.WriteLine( $"Description: {t.Description}");
}




//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
