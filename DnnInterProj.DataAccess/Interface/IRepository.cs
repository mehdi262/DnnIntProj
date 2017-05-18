using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnnInterProj.EntityModel.Model;

namespace DnnInterProj.DataAccess
{
    /// <summary>
    ///  The generic IRepository interface. 
    ///  The IRepository interface will be used to introduce the basic CRUD repositories methods
    /// </summary>
    /// <typeparam name="T"> generic type of T</typeparam>
    public interface IRepository<T> where T : EntityBase

    {
        /// <summary>
        /// Repersent the signiture of the function which return all existing instances in Repository
        /// </summary>
        /// <returns>The return is a List of all instancesor null if not exist any</returns>
        List<T> GetAll();

        /// <summary>
        /// Repersent the signiture of the function which return a specific instance with the givin id
        /// </summary>
        /// <param name="id"> a long type named id, contains the id of a specific object to be retrieved </param>
        /// <returns>a T type object, with the equal id as the given id or null if not exist</returns>
        T GetById(Int64? id);

        /// <summary>
        /// Repersent the signiture of the function which Create a t type entity and connect to repository  to insert it to the existing repository
        /// </summary>        
        /// <param name="entity"> a T type object, which is created and inserted into repository or null if it could not act</param>
        /// <returns>an integer as the execution status code </returns>
        int Create(T entity);

        /// <summary>
        /// Repersent the signiture of the function which  delete the specified object with the given id from the repository
        /// </summary>
        /// <param name="entity">a long type named id, contains the id of a specific object to be deleted</param>
        /// <returns>an integer as the execution status code</returns>
        int Delete(Int64 entity);

        /// <summary>
        /// Repersent the signiture of the function which Update an existing object in repository.
        /// This method  only updates Name, LastName ,Email, and picture 
        /// of exisiting user based on given id
        /// the UserName and Joined date cannot be update
        /// </summary>
        /// <param name="id">a long type named id, contains the id of a specific object to be deleted</param>
        /// <param name="person">an object that used its field during the update data</param>
        /// <returns>an integer as the execution status code </returns>
        int Update(Int64 id, T entity);
    }
}
