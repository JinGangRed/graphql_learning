using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using LearnGraphQL.Movies.Schema;
using LearnGraphQL.Movies.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LearnGraphQL.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IMovieService, MovieService>();
            services.AddSingleton<IActorService, ActorService>();

            services.AddSingleton<MovieType>();
            services.AddSingleton<ActorType>();
            services.AddSingleton<MovieRatingEnum>();
            services.AddSingleton<MoviesQuery>();
            services.AddSingleton<MovieSchema>();
            services.AddSingleton<MovieInputType>();
            services.AddSingleton<MoviesMutation>();

            services.AddSingleton<MovieEventType>();
            services.AddSingleton<IMovieEventService, MovieEventService>();
            services.AddSingleton<MoviesSubscription>();

            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));


            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
            .AddWebSockets()
            .AddDataLoader();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseGraphQLWebSockets<MovieSchema>("/graphql");
            app.UseGraphQL<MovieSchema>("/graphql");

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            // use voyager middleware at default url /ui/voyager
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions());
            // use graphiQL middleware at default url /graphiql
            app.UseGraphiQLServer(new GraphiQLOptions());

        }
    }
}
