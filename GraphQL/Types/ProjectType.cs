using SuperSimpleGraphQLTutorial.Models;
using SuperSimpleGraphQLTutorial.GraphQL.Resolvers;

namespace SuperSimpleGraphQLTutorial.GraphQL.Types
{
    public class ProjectType : ObjectType<Project>
    {
        protected override void Configure(IObjectTypeDescriptor<Project> descriptor)
        {
            descriptor
                .Field("AdditionalField")
                .Resolve(context =>
                {
                    return context.Parent<Project>().Name + "asdasd";
                });
            descriptor
                .Field("logs")
                .ResolveWith<ProjectLogsResolver>(r => r.GetLogs(default!, default!));
        }
    }
}
