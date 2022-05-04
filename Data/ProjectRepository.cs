
using Microsoft.EntityFrameworkCore;
using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.Data
{
    public class ProjectRepository : IProjectRepository
    {
        protected SuperSimpleGraphQLTutorialContext Context { get; set; }
        public ProjectRepository(SuperSimpleGraphQLTutorialContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await Context.Project.ToListAsync();
        }

        public async Task<Project?> GetProject(int projectId)
        {
            return await Context.Project.FirstOrDefaultAsync(p => p.Id == projectId);
        }
        public async Task<Project> AddProject(Project project)
        {
            var result = await Context.Project.AddAsync(project);
            await Context.SaveChangesAsync();

            return result.Entity;
        }
        public async Task<Project?> UpdateProjetc(Project project)
        {
            var result = await Context.Project.FirstOrDefaultAsync(p => p.Id == project.Id);

            if (result != null)
            {
                result.Name = project.Name;
                result.CreatedBy = project.CreatedBy;

                await Context.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public async void DeleteProject(int projetcId)
        {
            var result = await Context.Project.FirstOrDefaultAsync(p => p.Id == projetcId);
            if (result != null)
            {
                Context.Project.Remove(result);
                await Context.SaveChangesAsync();
            }
        }
    }
}