﻿namespace Flight_Planner_Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Flight_Planner_Data.FlightPlannerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false; //never true
        }

        protected override void Seed(Flight_Planner_Data.FlightPlannerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
