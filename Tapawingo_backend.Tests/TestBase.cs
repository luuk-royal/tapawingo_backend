﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapawingo_backend.Data;
using Tapawingo_backend.Models;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Tapawingo_backend.Tests
{
    [CollectionDefinition("Database collection")]
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            // Create the database once before running all tests
            Context = CreateDbContext();
        }

        public DataContext Context { get; private set; }

        private DataContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseMySQL("server=localhost;database=TapawingoDB_Test;user=root;password=mysql");

            var context = new DataContext(options.Options);
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            SeedData(context);
            return context;
        }

        private void SeedData(DataContext context)
        {
            // Clear existing data
            context.Users.RemoveRange(context.Users);
            context.Organisations.RemoveRange(context.Organisations);
            context.UserOrganisations.RemoveRange(context.UserOrganisations);
            context.Events.RemoveRange(context.Events);
            context.UserEvents.RemoveRange(context.UserEvents);
            context.Routes.RemoveRange(context.Routes);
            context.Editions.RemoveRange(context.Editions);
            context.Locationlogs.RemoveRange(context.Locationlogs);
            context.Teams.RemoveRange(context.Teams);
            context.Routeparts.RemoveRange(context.Routeparts);
            context.TeamRouteparts.RemoveRange(context.TeamRouteparts);
            context.Destinations.RemoveRange(context.Destinations);
            context.Files.RemoveRange(context.Files);
            context.SaveChanges();

            //Create test data
            //////destinations
            //////editions
            //////events
            //////files
            //////locationlogs
            //////organisations
            var organisation1 = new Organisation { Name = "TestOrganisation1" };
            var organisation2 = new Organisation { Name = "TestOrganisation2" };
            //////routeparts
            //////routes
            //////teamrouteparts
            //////teams
            //////userevents
            //////userorganisations

            // Insert test data
            //////destinations
            //////events
            //////files
            //////locationlogs
            //////organisations
            context.Organisations.Add(organisation1);
            context.Organisations.Add(organisation2);
            //////routeparts
            //////routes
            //////teamrouteparts
            //////teams
            //////userevents
            //////userorganisations


            //Save Data
            context.SaveChanges();
        }

        public void Dispose()
        {
            // Dispose of the database after all tests have finished
            Context.Dispose();
        }
    }

    public class TestBase : IClassFixture<DatabaseFixture>
    {
        protected DataContext Context => Fixture.Context;

        protected TestBase(DatabaseFixture fixture)
        {
            Fixture = fixture;
        }

        protected DatabaseFixture Fixture { get; }
    }
}
