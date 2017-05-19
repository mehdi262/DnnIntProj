using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DnnInterProj.EntityModel.Model;
using DnnInterProj.DataAccess;

namespace DnnMehdiNikkhah01.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository Repo;
        public PersonController(IPersonRepository repo)
        {
            Repo = repo;
        }
        public PersonController()
        {
            Repo = new PersonRepository();
        }

        // GET: Person
        public ActionResult Index()
        {

            return View(Repo.GetAll());
        }


        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}


