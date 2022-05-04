namespace SuperSimpleGraphQLTutorial.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string CreatedBy { get; set; } = default!;
    }
}
