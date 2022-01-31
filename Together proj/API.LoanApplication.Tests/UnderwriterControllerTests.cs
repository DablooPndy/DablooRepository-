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
    public class UnderwriterControllerTests
    {
        Mock<IUnderwriterLoanManager> _mockIUnderwriterLoanManager = new Mock<IUnderwriterLoanManager>();
        [TestMethod]
        public void GetAllLoanDetails_NoInput_ListofLaonCaes_Test()
        {
            //Arrange
            _mockIUnderwriterLoanManager.Setup(l => l.GetAllLoanDetails()).Returns(GetAllLoandeatils());

            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping.ModelToContractProfile>());
            var mapper = config.CreateMapper();

            // Act
            UnderwriterController _underwriterLoanManager = new UnderwriterController(_mockIUnderwriterLoanManager.Object, mapper);
            var response = _underwriterLoanManager.GetAllLoanDetails();
            var contentResponse = response as OkNegotiatedContentResult<List<Contract.LoanApplication.LoanDetails>>;

            //// Assert
            Assert.AreEqual(2, contentResponse.Content.Count);
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
            _mockIUnderwriterLoanManager.Setup(x => x.GetLoanDetailsByID(Loanid)).Returns(GetAllLoandeatils().Find(x => x.Id == Loanid));

            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping.ModelToContractProfile>());
            var mapper = config.CreateMapper();

            // Act
            UnderwriterController _underwriterLoanManager = new UnderwriterController(_mockIUnderwriterLoanManager.Object, mapper);
            var response = _underwriterLoanManager.GetLoanDetailsByID(Loanid);
            var contentResponse = response as OkNegotiatedContentResult<Contract.LoanApplication.LoanDetails>;

            //// Assert
            Assert.IsNotNull(contentResponse.Content);
            Assert.AreEqual(3000, contentResponse.Content.Amount);
            Assert.AreEqual("Second", contentResponse.Content.ChargeType);
            Assert.AreEqual("Female", contentResponse.Content.Gender);
            Assert.AreEqual("Xyzfn", contentResponse.Content.FirstName);
        }

        [TestMethod]
        public void UpdateLoanDetails_ObjLoanDetails_IsUpdated_Test()
        {
            //Arrange
            _mockIUnderwriterLoanManager.Setup(x => x.UpdateLoanDetails(It.IsAny<Model.LoanApplication.LoanDetails>())).Returns(true);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<Mapping.ModelToContractProfile>());
            var mapper = config.CreateMapper();

            // Act
            UnderwriterController _underwriterLoanManager = new UnderwriterController(_mockIUnderwriterLoanManager.Object, mapper);
            IHttpActionResult httpActionResult = _underwriterLoanManager.UpdateLoanDetails(It.IsAny<Contract.LoanApplication.LoanDetails>());

            var contentResponse = httpActionResult as OkNegotiatedContentResult<bool>;

            //// Assert
            Assert.IsNotNull(contentResponse.Content);
            Assert.AreEqual(true, contentResponse.Content);
            Assert.IsInstanceOfType(httpActionResult, typeof(OkNegotiatedContentResult<bool>));
        }
        private List<Model.LoanApplication.LoanDetails> GetAllLoandeatils()
        {
            var lsloanDetails = new List<Model.LoanApplication.LoanDetails>();
            lsloanDetails.Add(new Model.LoanApplication.LoanDetails { Id = 1, Amount = 1000, Valuation = 500, ChargeType = "First", FirstName = "Abcfn", LastName = "Abcln", Gender = "Male", Contact = 9892804840, Postcode = 421605 });
            lsloanDetails.Add(new Model.LoanApplication.LoanDetails { Id = 2, Amount = 3000, Valuation = 1500, ChargeType = "Second", FirstName = "Xyzfn", LastName = "Xyzln", Gender = "Female", Contact = 9892123456, Postcode = 427894 });

            return lsloanDetails;
        }
    }
}
