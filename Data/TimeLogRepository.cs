
using Microsoft.EntityFrameworkCore;
using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.Data
{
    public class TimeLogRepository : ITimeLogRepository
    {
        protected SuperSimpleGraphQLTutorialContext Context { get; set; }
        public TimeLogRepository(SuperSimpleGraphQLTutorialContext context)
        {
            Context = context;
        }

        public List<TimeLog> GetProjectTimelogs(Project project)
        {
            return Context.TimeLog.Where(t => t.ProjectId == project.Id).ToList();
        }

        public async Task<TimeLog> AddProjectTimeLog(TimeLog timeLog)
        {
            Context.TimeLog.Add(timeLog);
            await Context.SaveChangesAsync();

            return timeLog;
        }
    }
}