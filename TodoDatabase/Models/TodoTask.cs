namespace TodoDatabase.Models
{
    public class TodoTask
    {

        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
