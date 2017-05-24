using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DnnInterProj.EntityModel.Model;
using AutoMapper;
using DnnInterProj.EntityModel.Dtos;
using DnnInterProj.Biz;
using DnnInterProj.DataAccess;

namespace DnnInterProj.Controllers.api
{

    public class PersonsController : ApiController
    {
        private IPersonRepository Repo;
        public PersonsController()
        {
            Repo = new PersonRepository();
        }
        public PersonsController(IPersonRepository repo)
        {
            Repo = repo;
        }

        // GET: api/Persons

        public IHttpActionResult GetAllPerson()
        {
            return Ok(Repo.GetAll());
        }


        // GET: api/Persons(5)

        public IHttpActionResult GetPerson( long id)
        {
            return Ok(Repo.GetById(id));
        }

        // GET: api/Persons("tommy")
        public IHttpActionResult SearchUsername(string userName)
        {
            return Ok(Repo.GetByUserName(userName));
        }
        // GET: api/Persons("tommy123")
        public IHttpActionResult SearchName(string name)
        {
            return Ok(Repo.GetByNameLike(name));
        }
        // PUT: api/Persons(5,personToUpdate)
        [HttpPut]
        public IHttpActionResult Update( long id, PersonDto personDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Person personReceived = new Person();
                if(!ValidateModel.IsAgeFormat(personDto.Age))
                    return BadRequest("Age can only be between 00 to 99 Format is incorrect");

                Mapper.Map<PersonDto, Person>(personDto, personReceived);
//                personReceived.Age = int.Parse(personDto.Age);
                int res = Repo.Update(id, personReceived);
                switch (res)
                {
                    case ReturnCodeReference.Updated_SuccessFully:
                        return Ok(personDto);
                    case ReturnCodeReference.NotUpdated_EmailDormatProblem:
                        return BadRequest("Email Format is incorrect");
                    case ReturnCodeReference.NotUpdated_IdNotExist:
                        return NotFound();
                    case ReturnCodeReference.NotUpdated_UsernameExist:
                        return BadRequest("UserName can not be changed");
                    default:
                        throw new Exception("Cannot Add new user at this moment: code 12000");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/Persons
        [HttpPost]
        public IHttpActionResult Post(PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                Person personReceived = new Person();
                Mapper.Map<PersonDto, Person>(personDto, personReceived);

                int res = Repo.Create(personReceived);

                switch (res)
                {
                    case ReturnCodeReference.Created_SuccessFully:
                        return Created<Person>(Request.RequestUri + "/" + personReceived.Id, personReceived);
                    case ReturnCodeReference.NotCreated_EmailFormatProblem:
                        return BadRequest("Email Format is not correct");
                    case ReturnCodeReference.NotCreated_UsernameExist:
                        return BadRequest("The Given UserName is taken");
                    default:
                        throw new Exception("Cannot Add new user at this moment: code 12000");

                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        // DELETE: api/Persons(5)
        public IHttpActionResult Delete(long id)
        {
            try
            {
                int res = Repo.Delete(id);
                switch (res)
                {
                    case ReturnCodeReference.Deleted_SuccessFully:
                        return Ok();
                    case ReturnCodeReference.NotDeleted_IdNotExist:
                        return BadRequest("The given Id does not exist");

                    default:
                        throw new Exception(" Cannot delete users at this moment");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }


    }
}
