using SuperSimpleGraphQLTutorial.Models;

namespace SuperSimpleGraphQLTutorial.ViewModels
{
    public class ProjectList
    {
        public readonly List<Project> _projects;
        public ProjectList(List<Project> projects)
        {
            _projects = projects;
        }

        public readonly string NameLabel = "Name";

        public readonly string IdLabel = "Id";
        public readonly string CreatedByLabel = "Crated by";

    }
}
