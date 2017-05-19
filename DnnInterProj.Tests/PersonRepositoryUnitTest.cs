using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnnInterProj.EntityModel;
using DnnInterProj.EntityModel.Model;
using DnnInterProj.Biz;
using DnnInterProj.DataAccess;


namespace DnnInterProj.Tests
{
    /// <summary>
    /// Summary description for PersonRepositoryUnitTest
    /// </summary>
    [TestClass]
    public class PersonRepositoryUnitTest
    {
        PersonRepository Repo;
        [TestInitialize]
        public void TestSetup()
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            PersonInitalizeDB db = new PersonInitalizeDB();
            Database.SetInitializer(db);

            Repo = new PersonRepository();
        }
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData()
        {
            //Arrange & Act
            var result = Repo.GetAll();

            var numberOfRecords = result.Count;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, numberOfRecords);
        }
        [TestMethod]
        public void IsRepositoryGetByUserNameWorks()
        {
            //Arrange
            var personToSearch = new Person
            {

                UserName = "George",
                Name = "George",
                LastName = "Doe",
                Email = "george.deo@email.com",
                picture = null

            };
            //Act
            var personInDb = Repo.GetByUserName(personToSearch.UserName);
            //assert
            Assert.AreEqual(personToSearch.UserName, personInDb.UserName);
            Assert.AreEqual(personToSearch.Name, personInDb.Name);
            Assert.AreEqual(personToSearch.LastName, personInDb.LastName);
            Assert.AreEqual(personToSearch.Email, personInDb.Email);
            Assert.AreEqual(personToSearch.picture, personInDb.picture);

        }

        [TestMethod]
        public void IsRepositoryGetByIdWorks()
        {
            //Arrange
            Person personToGet = new Person
            {

                UserName = "George",
                Name = "George",
                LastName = "Doe",
                Email = "george.deo@email.com",
                picture = null


            };
            //Act
            
            var result = Repo.GetById(1);
            //Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(personToGet.Name, result.Name);
            Assert.AreEqual(personToGet.LastName, result.LastName);
            Assert.AreEqual(personToGet.Email, result.Email);
            Assert.AreEqual(personToGet.UserName, result.UserName);
            Assert.AreEqual(personToGet.picture, result.picture);

        }
        [TestMethod]
        public void IsRepositoryCreatePerson()
        {
            //Arrange
            int count = Repo.GetAll().Count;
            Person personToInsert = new Person
            {

                UserName = "MehdiNik",
                Name = "Mehdi",
                LastName = "Nik",
                Email = "MehdiNik@gmail.com",
                JoinedDate = DateTime.Now,
                picture = null

            };

            //Act

            Repo.Create(personToInsert);
            //Assert
            var result = Repo.GetAll();
            var numberOfRecords = result.Count;
            Assert.AreEqual(count + 1
                , numberOfRecords);
        }
        [TestMethod]
        public void IsRepositoryCreatePersonWithExistingUsername()
        {
            //Arrange
            int count = Repo.GetAll().Count;
            Person personToInsert = new Person
            {

                UserName = "MehdiNik",
                Name = "Mehdi",
                LastName = "Nik",
                Email = "MehdiNik@gmail.com",
                JoinedDate = DateTime.Now,
                picture = null

            };

            //Act

            Repo.Create(personToInsert);
            
            //Assert
            var result = Repo.GetAll();
            var numberOfRecords = result.Count;
            Assert.AreEqual(count
                , numberOfRecords);
        }
        [TestMethod]
        public void IsRepositoryCreatePersonWithWrongFormatEmail()
        {
            //Arrange
            Person personToInsert = new Person
            {

                UserName = "MehdiNikkkkkk",
                Name = "Mehdi",
                LastName = "Nik",
                Email = "MehdiNik",
                JoinedDate = DateTime.Now,
                picture = null

            };

            //Act

            int statusCode = Repo.Create(personToInsert);

            Assert.AreEqual(statusCode, ReturnCodeReference.NotCreated_EmailFormatProblem);
        }
        [TestMethod]
        public void IsRepoeitoryCheckUserNameWorks()
        {
            //Arrange
            var userName = "George";
            //Act
            Boolean result = Repo.CheckUserNameExistance(userName);
            //Assert
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void IsRepoeitoryCheckUserNameWorksForEmptyInput()
        {
            //Arrange
            var userName = "";
            //Act
            Boolean result = Repo.CheckUserNameExistance(userName);
            //Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void IsRepoeitoryCheckUserNameWorksForNullInput()
        {
            //Arrange
            string userName = null;
            //Act
            Boolean result = Repo.CheckUserNameExistance(userName);
            //Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void IsRepoeitoryCheckUserNameWorksForWhiteSpaceInput()
        {
            //Arrange
            string userName = "   ";
            //Act
            Boolean result = Repo.CheckUserNameExistance(userName);
            //Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void IsRepoeitoryUpdateWOrksForCorrectDate()
        {
            //Arrange
            int count = Repo.GetAll().Count;
            Person personToUpdate = new Person
            {

                UserName = "MehdiNik",
                Name = "Mehdi",
                LastName = "Nikkhah",
                Email = "MehdiNik@gmail.com",
                picture = null

            };


            //Act

            Repo.Update(count, personToUpdate);
            //Assert
            var result = Repo.GetAll();
            var numberOfRecords = result.Count;
            Assert.AreEqual(count
                , numberOfRecords);
            var UpdatedInDb = Repo.GetById(count);
            Assert.AreEqual(personToUpdate.Name, UpdatedInDb.Name);
            Assert.AreEqual(personToUpdate.LastName, UpdatedInDb.LastName);
            Assert.AreEqual(personToUpdate.Email, UpdatedInDb.Email);
            Assert.AreEqual(personToUpdate.UserName, UpdatedInDb.UserName);
            Assert.AreEqual(personToUpdate.picture, UpdatedInDb.picture);

        }
        [TestMethod]
        public void IsRepoeitoryUpdateDoesntUpdateUsernameAndJoinedDate()
        {
            //Arrange
            int count = Repo.GetAll().Count;
            Person personToUpdate = new Person
            {

                UserName = "MehdiNikkk",
                Name = "Mehdi",
                LastName = "Nik",
                Email = "MehdiNikkhah@gmail.com",
                JoinedDate = DateTime.Now,
                picture = null

            };


            //Act

            Repo.Update(count, personToUpdate);
            //Assert
            var result = Repo.GetAll();
            var numberOfRecords = result.Count;
            Assert.AreEqual(count
                , numberOfRecords);
            var UpdatedInDb = Repo.GetById(count);
            Assert.AreEqual(personToUpdate.Name, UpdatedInDb.Name);
            Assert.AreEqual(personToUpdate.LastName, UpdatedInDb.LastName);
            Assert.AreEqual(personToUpdate.Email, UpdatedInDb.Email);
            Assert.AreNotEqual(personToUpdate.UserName, UpdatedInDb.UserName);
            Assert.AreEqual(personToUpdate.picture, UpdatedInDb.picture);
            Assert.AreNotEqual(personToUpdate.JoinedDate, UpdatedInDb.JoinedDate);

        }

        [TestMethod]
        public void IsRepoeitoryUpdateDoesntUpdateInvalidEmail()
        {
            //Arrange
            int count = Repo.GetAll().Count;
            Person personToUpdate = new Person
            {

                UserName = "MehdiNikkk",
                Name = "Mehdi",
                LastName = "Nik",
                Email = "MehdiNikkhah",
                JoinedDate = DateTime.Now,
                picture = null

            };


            //Act

            Repo.Update(count, personToUpdate);
            //Assert
            var result = Repo.GetAll();
            var numberOfRecords = result.Count;
            Assert.AreEqual(count
                , numberOfRecords);
            var UpdatedInDb = Repo.GetById(count);
            Assert.AreEqual(personToUpdate.Name, UpdatedInDb.Name);
            Assert.AreEqual(personToUpdate.LastName, UpdatedInDb.LastName);
            Assert.AreNotEqual(personToUpdate.Email, UpdatedInDb.Email);
            

        }

    }
}
