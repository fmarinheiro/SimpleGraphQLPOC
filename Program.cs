var builder = WebApplication.CreateBuilder(args);
SuperSimpleGraphQLTutorial.AppConfiguration.ConfigureServices(builder);

var app = builder.Build();

SuperSimpleGraphQLTutorial.AppConfiguration.ConfigureRequestPipeline(app);

app.Run();
