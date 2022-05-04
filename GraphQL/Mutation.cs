using SuperSimpleGraphQLTutorial.Data;
using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.GraphQL
{
    public class Mutation
    {
        public async Task<Project?> UpdateProject([Service] IProjectRepository projectRepository, int id, string name)
        {
            Project? project = await projectRepository.GetProject(id);
            if (project != null)
            {
                project.Name = name;
                return await projectRepository.UpdateProjetc(project);
            }

            return null;
        }

        public async Task<TimeLog?> AddProjectTimeLog(
            [Service] IProjectRepository projectRepository, 
            [Service] ITimeLogRepository timeLogRepository, 
            int projectId, 
            DateTime fromDate,
            DateTime toDate,
            string user
        ) {

            Project? project = await projectRepository.GetProject(projectId);
            if (project == null)
            {
                return null;
            }

            TimeLog timeLog = new TimeLog()
            {
                From = fromDate,
                To = toDate,
                User = user,
                Project = project
            };

            return await timeLogRepository.AddProjectTimeLog(timeLog);
        }
    }
}
