namespace SuperSimpleGraphQLTutorial.Models
{
    public class TimeLog
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public string User { get; set; } = default!;

        public int ProjectId { get; set; } = default!;
        public Project Project { get; set; } = default!;
    }
}
