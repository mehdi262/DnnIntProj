using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnnInterProj.EntityModel.Model;
using DnnInterProj.Biz;
using DnnInterProj.DataAccess;

namespace DnnInterProj.DataAccess
{
    /// <summary>
    /// the concrete class to implement IPersonRepository Methods
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// The _context contain PersonContext which used to do CRUD operation on Table Person of Database
        /// </summary>
        PersonContext _context= new PersonContext();

        

        /// <summary>
        /// Implement the function which returns all existing instances in Repository
        /// </summary>
        /// <returns>The return is a List of all persons or null if not exists any</returns>
        public List<Person> GetAll()
        {
            List<Person>result= _context.Persons.ToList();
            _context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            return result;
           
            ;

        }

        /// <summary>
        /// Implement the function to returns a specific instance with the givin id
        /// </summary>
        /// <param name="id"> a long type named id, contains the id of a specific object to be retrieved </param>
        /// <returns>a Person type object, with the equal id as the given id or null if not exists any</returns>
        public Person GetById(long? id)
        {
            try
            {
                if (id == null)
                    return null;
                var personInDb = _context.Persons.SingleOrDefault(p => p.Id == id);
                if (personInDb == null)
                    return null;
                return personInDb;

            }
            catch (Exception)
            {

                throw;
            }


        }


        /// <summary>
        /// Implement the function which  retrieves The person with the exact username to the given username
        /// </summary>
        /// <seealso  cref="IPersonRepository"/>
        /// <param name="userName">a string, that contains the username of the customer to be searched</param>
        /// <returns>a person type object, with the exact username as the given username or null if not exist</returns>
        public Person GetByUserName(String UserName)
        {
            try
            {
                Person personByUserName =
                                _context.Persons.SingleOrDefault
                                (p => p.UserName == UserName);
                return personByUserName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //change SingleOrDefault to First to avoid any exception on redundant Username
            
        }

        /// <summary>
        /// Implement of the function which retrieves all persons with the similar name to the given name
        /// </summary>
        /// <seealso cref="IPersonRepository"/>
        /// <param name="name"> a string, that contains the name of the customer to be searched</param>
        /// <returns>The return is a List of all persons with the similar Name to the given name as parameter or null if not exist </returns>
        public List<Person> GetByNameLike(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implement the function which creates and inserts a new instance of type <T> to the existing repository
        /// </summary>        
        /// <param name="entity"> a person type object, which is created and inserted into repository or null if it could not act</param>
        /// <returns>an integer as the execution status code </returns>

        public int Create(Person person)
        {
            try
            {
                if (!ValidateModel.IsValidEmail(person.Email))
                    return ReturnCodeReference.NotCreated_EmailFormatProblem;

                if (CheckUserNameExistance(person.UserName))
                    return ReturnCodeReference.NotCreated_UsernameExist;

                Person newPerson = GetByUserName(person.UserName);
                if (newPerson == null)
                {
                    _context.Persons.Add(person);
                    _context.SaveChanges();
                    
                }

                else
                    return ReturnCodeReference.NotCreated_UnknownReason;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ReturnCodeReference.NotCreated_UnknownReason;
            }

            return ReturnCodeReference.Created_SuccessFully;


        }

        /// <summary>
        /// Repersent the signiture of the function indicate that exact given username is exist in repository
        /// </summary>
        /// <param name="userName">a string, that contains the username of the customer to be searched</param>
        /// <returns>Boolean, True if the given username exist in the repository or False if not</returns>
        public bool CheckUserNameExistance(string userName)
        {
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
                    return false;
                Person personInDb = GetByUserName(userName);
                if (personInDb == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw new DnnException("error ocurred during check Username Existance method"+ ex.Message);
            }

        }

        /// <summary>
        /// Implement the function to  delete the specified object with the given id from the repository
        /// </summary>
        /// <param name="entity">a long type named id, contains the id of a specific object to be deleted</param>
        /// <returns>an integer as the execution status code </returns>
        public int Delete(long id)
        {
            try
            {
                var personInDb = GetById(id);
                if (personInDb == null)
                    return ReturnCodeReference.NotDeleted_IdNotExist;
                _context.Persons.Remove(personInDb);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return ReturnCodeReference.NotDeleted_UnknownReason;
            }
            return ReturnCodeReference.Deleted_SuccessFully;

        }



        /// <summary>
        /// Immplement the function to Update an existing object in repository.
        /// This method  only updates Name, LastName ,Email, and picture 
        /// of exisiting user based on given id
        /// the UserName and Joined date cannot be update
        /// </summary>
        /// <param name="id">a long type named id, contains the id of a specific object to be deleted</param>
        /// <param name="person">an object that used its field during the update data</param>
        /// <returns>an integer as the execution status code </returns>

        public int Update(long id, Person person)
        {
            try
            {
                var personInDb = GetById(id);
                if (personInDb == null)
                    return ReturnCodeReference.NotUpdated_IdNotExist;
                personInDb.Name = person.Name;
                personInDb.LastName = person.LastName;
                if (!ValidateModel.IsAgeFormat(person.Age.ToString()))
                    personInDb.Age = person.Age;
                if (ValidateModel.IsValidEmail(person.Email))
                    personInDb.Email = person.Email;
                personInDb.picture = person.picture;

                _context.SaveChanges();

            }

            catch (Exception)
            {

                return ReturnCodeReference.NotUpdated_UnknownReason;
            }

            return ReturnCodeReference.Updated_SuccessFully;

        }





    }
}
