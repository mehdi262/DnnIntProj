using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DnnInterProj.EntityModel.Model;

namespace DnnInterProj.DataAccess
{
    public class PersonInitalizeDB : DropCreateDatabaseAlways<PersonContext>

    {
        /// <summary>
        /// this method is used to create seed data in the database while databse initialization and generating process
        /// </summary>
        /// <param name="context"> a PersonContext type input, the given context is our database repository</param>
        protected override void Seed(PersonContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();


            SetSeedData(context);


        }
        /// <summary>
        /// The method is public method to insert the generated sample seed data into database
        /// <seealso cref="GetPersons">this methood is used to generate sample data</seealso>
        /// </summary>
        /// <param name="context">a PersonContext type, that the data should be inserted in</param>
        public void SetSeedData(PersonContext context)
        {

            GetPersons().ForEach(p => context.Persons.Add(p));
            context.SaveChanges();
        }
        /// <summary>
        /// The method generate ta consistant list of 4 sample persons
        /// </summary>
        /// <returns>List of 4 persons data</returns>
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


