using SuperSimpleGraphQLTutorial.Data;
using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.GraphQL.Resolvers
{
    public class ProjectLogsResolver
    {
        public List<TimeLog> GetLogs([Parent] Project project, [Service] ITimeLogRepository timeLogRepository)
        {
            return timeLogRepository.GetProjectTimelogs(project);
        }
    }
}
