using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DnnInterProj.EntityModel.Model;

namespace DnnInterProj.DataAccess
{
    public class PersonContext : DbContext
    {
        public PersonContext()
            : base("name=DnnInterProjDB")
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
