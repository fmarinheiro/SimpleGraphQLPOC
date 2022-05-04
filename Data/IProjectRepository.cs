using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.Data
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project?> GetProject(int projectId);
        Task<Project> AddProject(Project project);
        Task<Project?> UpdateProjetc(Project project);
        void DeleteProject(int projetcId);
    }
}