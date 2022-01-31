using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutoMapper;
using BusinessLogic.LoanApplication;
using Moq;
using API.LoanApplication.Controllers;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using System.Web.Http;

namespace API.LoanApplication.Tests
{
    [TestClass]
    public class BrokerControllerTests
    {
        Mock<IBrokerLoanManager> _mockIBrokerLoanManager = new Mock<IBrokerLoanManager>();

        [TestMethod]
        public void GetAllLoanDetails_NoInput_ListofLaonCaes_Test()
        {
            //Arrange
            
            _mockIBrokerLoanManager.Setup(l => l.GetAllLoanDetails()).Returns(GetAllLoandeatils());

            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping.ModelToContractProfile>());
            var mapper = config.CreateMapper();

            // Act
            BrokerController _brokerController = new BrokerController(_mockIBrokerLoanManager.Object, mapper);
            var response =  _brokerController.GetAllLoanDetails();
            var contentResponse = response as OkNegotiatedContentResult<List<Contract.LoanApplication.LoanDetails>>;

            //// Assert
            Assert.AreEqual(2,contentResponse.Content.Count);
            Assert.AreEqual(1000, contentResponse.Content[0].Amount);
            Assert.AreEqual("First", contentResponse.Content[0].ChargeType);
            Assert.AreEqual("Male", contentResponse.Content[0].Gender);
            Assert.AreEqual("Abcfn", contentResponse.Content[0].FirstName);
        }

        [TestMethod]
        public void GetLoanDetailsByID_LoanId_LaonCaes_Test()
        {
            //Arrange
            int Loanid = 2;
            Mock<IBrokerLoanManager> _mockIBrokerLoanManager = new Mock<IBrokerLoanManager>();
            _mockIBrokerLoanManager.Setup(x => x.GetLoanDetailsByID(Loanid)).Returns(GetAllLoandeatils().Find(x => x.Id == Loanid));

            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping.ModelToContractProfile>());
            var mapper = config.CreateMapper();

            // Act
            BrokerController _brokerController = new BrokerController(_mockIBrokerLoanManager.Object, mapper);
            var response = _brokerController.GetLoanDetailsByID(Loanid);
            var contentResponse = response as OkNegotiatedContentResult<Contract.LoanApplication.LoanDetails>;

            //// Assert
            Assert.IsNotNull(contentResponse.Content);
            Assert.AreEqual(3000, contentResponse.Content.Amount);
            Assert.AreEqual("First", contentResponse.Content.ChargeType);
            Assert.AreEqual("Female", contentResponse.Content.Gender);
            Assert.AreEqual("Xyzfn", contentResponse.Content.FirstName);
        }

        [TestMethod]
        public void InsertLoanDetails_ObjLoanDetails_Isinserted_Test()
        {
            //Arrange
            Mock<IBrokerLoanManager> _mockIBrokerLoanManager = new Mock<IBrokerLoanManager>();
            _mockIBrokerLoanManager.Setup(x => x.InsertLoanDetails(It.IsAny<Model.LoanApplication.LoanDetails>())).Returns(true);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping.ModelToContractProfile>());
            var mapper = config.CreateMapper();

            // Act
            BrokerController _brokerController = new BrokerController(_mockIBrokerLoanManager.Object, mapper);
            IHttpActionResult httpActionResult = _brokerController.InsertLoanDetails(It.IsAny<Contract.LoanApplication.LoanDetails>());

            var contentResponse = httpActionResult as OkNegotiatedContentResult<bool>;

            //// Assert
            Assert.IsNotNull(contentResponse.Content);
            Assert.AreEqual(true, contentResponse.Content);
            Assert.IsInstanceOfType(httpActionResult, typeof(OkNegotiatedContentResult<bool>));
        }



        private List<Model.LoanApplication.LoanDetails> GetAllLoandeatils()
        {
            var lsloanDetails = new List<Model.LoanApplication.LoanDetails>();
            lsloanDetails.Add(new Model.LoanApplication.LoanDetails { Id = 1, Amount = 1000,Valuation = 500,ChargeType = "First", FirstName = "Abcfn",LastName = "Abcln", Gender = "Male",Contact=9892804840,Postcode=421605 });
            lsloanDetails.Add(new Model.LoanApplication.LoanDetails { Id = 2, Amount = 3000, Valuation = 1500, ChargeType = "Second", FirstName = "Xyzfn", LastName = "Xyzln", Gender = "Female", Contact = 9892123456, Postcode = 427894 });

            return lsloanDetails;
        }
        private Contract.LoanApplication.LoanDetails LoanDetails()
        {
            return new Contract.LoanApplication.LoanDetails { Id = 1, Amount = 1000, Valuation = 500, ChargeType = "First", FirstName = "Abcfn", LastName = "Abcln", Gender = "Male", Contact = 9892804840, Postcode = 421605 };
 
        }
    } 
}
