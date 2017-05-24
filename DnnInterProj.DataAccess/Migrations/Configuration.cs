namespace DnnInterProj.DataAccess.Migrations
{
    using EntityModel.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DnnInterProj.DataAccess.PersonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DnnInterProj.DataAccess.PersonContext";
        }

        protected override void Seed(DnnInterProj.DataAccess.PersonContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
          //  GetPersons().ForEach(p => context.Persons.Add(p));

        }
        private static List<Person> GetPersons()
        {


            var persons = new List<Person> {
                new Person
                {

                    UserName = "George",
                    Name="George",
                    LastName="Doe",
                    Email="george.deo@email.com",
                    JoinedDate=DateTime.Now,
                    picture=null

               },
                 new Person
                {

                    UserName = "ash",
                    Name="ash",
                    LastName="prasad",
                    Email="ash.prasad@email.com",
                    JoinedDate=DateTime.Now,
                    picture=null

               },
                  new Person
                {

                    UserName = "com3773",
                    Name="Content Manager",
                    LastName="3773",
                    Email="com3773@test.com",
                    JoinedDate=DateTime.Now,
                    picture=null

               },
                   new Person
                {

                    UserName = "admin3773",
                    Name="Administrator",
                    LastName="3773",
                    Email="admin3773@change.com",
                    JoinedDate=DateTime.Now,
                    picture=null

               }
            };

            return persons;
        }
    }
}
