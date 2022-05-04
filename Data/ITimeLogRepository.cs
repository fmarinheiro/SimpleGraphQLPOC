using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.Data
{
    public interface ITimeLogRepository
    {
        List<TimeLog> GetProjectTimelogs(Project project);
        Task<TimeLog> AddProjectTimeLog(TimeLog timeLog);
    }
}