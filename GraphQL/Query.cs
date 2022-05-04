using SuperSimpleGraphQLTutorial.Data;
using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.GraphQL
{
    public class Query
    {
        public async Task<IEnumerable<Project>> Projects([Service] IProjectRepository projectRepository)
        {
            return await projectRepository.GetProjects();
        }

        public async Task<Project?> Project([Service] IProjectRepository projectRepository, int projectId)
        {
            return await projectRepository.GetProject(projectId);
        }
    }
}
