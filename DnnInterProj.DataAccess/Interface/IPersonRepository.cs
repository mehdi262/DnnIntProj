using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnnInterProj.EntityModel.Model;


namespace DnnInterProj.DataAccess

{

    /// <summary>
    ///  The IPersonRepository interface aims to interoduce the basic functions for CRUD 
    ///  This interface inherite from the generic IRepository interface 
    ///  to add work with Person type object and add two new method to it.
    ///  </summary>
    ///

    public interface IPersonRepository : IRepository<Person>

    {

        /// <summary>
        /// Repersent the signiture of the function which retrieves all persons with the similar name to the given name
        /// </summary>
        /// <param name="name"> a string, that contains the name of the customer to be searched</param>
        /// <returns>The return is a List of all persons with the similar Name to the given name as parameter or null if not exist </returns>
        List<Person> GetByNameLike(string name);

        /// <summary>
        /// Repersent the signiture of the function which  retrieves The person with the exact username to the given username
        /// </summary>
        /// <param name="userName">a string, that contains the username of the customer to be searched</param>
        /// <returns>a person type object, with the exact username as the given username or null if not exist</returns>
        Person GetByUserName(string userName);

        /// <summary>
        /// Repersent the signiture of the function indicate that exact given username is exist in repository
        /// </summary>
        /// <param name="userName">a string, that contains the username of the customer to be searched</param>
        /// <returns>Boolean, True if the given username exist in the repository or False if not</returns>
        bool CheckUserNameExistance(string userName);
    }
}
