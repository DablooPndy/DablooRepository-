using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutoMapper;
using BusinessLogic.LoanApplication;
using Database.LoanApplication.DataAccess.Repository;
using Database.LoanApplication.DataAccess.UnitOfWork;
using Moq;
using Database.LoanApplication.Entities;
using API.LoanApplication.Controllers;
using System.Collections.Generic;
using System.Web.Http;

namespace API.LoanApplication.Tests
{
    [TestClass]
    public class BrokerControllerTests
    {
        [TestMethod]
        public void GetAllLoanDetails_NoInput_ListofLaonCaes_Test()
        {
            Mock<IMapper> _mockMapper = new Mock<IMapper>();
            Mock<IBrokerLoanManager> _mockIBrokerLoanManager = new Mock<IBrokerLoanManager>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<API.LoanApplication.Mapping.ModelToContractProfile>());
            var mapper = config.CreateMapper();

            var result = mapper.Map<Contract.LoanApplication.LoanDetails>(GetAllLoandeatils().Find(x => x.Id==1));
         

            BrokerController _brokerController = new BrokerController(_mockIBrokerLoanManager.Object, _mockMapper.Object);

            var dd =  _brokerController.GetAllLoanDetails();

            // _brokerController.GetAllLoanDetails();
            // //var mock = new Mock<IGetDataRepository>();
            // //mock.Setup(p => p.GetNameById(1)).Returns("Jignesh");
            // //HomeController home = new HomeController(mock.Object);
            // //string result = home.GetNameById(1);
            // //Assert.AreEqual("Jignesh", result);

            // int LoanId = 10;
            //var obj = _loanAppBL.GetLoanDetailsByID(10);
            // //public GetLoanDetailsByID()
            //{

            //}
            //IUnitOfWork _unitOfWork;
            //IMapper _mapper;
            //// Arrange
            //var controller = new LoanAppBL(_unitOfWork, _mapper);
            //controller.Request = new HttpRequestMessage();
            //controller.Configuration = new HttpConfiguration();

            //// Act
            //var response = controller.Get(10);

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(1000, result.Amount);
            Assert.AreEqual("First",result.ChargeType);
        }
        private List<Model.LoanApplication.LoanDetails> GetAllLoandeatils()
        {
            var lsloanDetails = new List<Model.LoanApplication.LoanDetails>();
            lsloanDetails.Add(new Model.LoanApplication.LoanDetails { Id = 1, Amount = 1000,Valuation = 500,ChargeType = "First", FirstName = "Abcfn",LastName = "Abcln", Gender = "Male",Contact=9892804840,Postcode=421605 });
            lsloanDetails.Add(new Model.LoanApplication.LoanDetails { Id = 2, Amount = 3000, Valuation = 1500, ChargeType = "Second", FirstName = "Xyzfn", LastName = "Xyzln", Gender = "female", Contact = 9892123456, Postcode = 427894 });

            return lsloanDetails;
        }
        //private Model.LoanApplication.LoanDetails GetLoandeatils()
        //{
        //    var lsloanDetails = new List<Model.LoanApplication.LoanDetails>();
        //    lsloanDetails.Add(new Model.LoanApplication.LoanDetails { Id = 1, Amount = 1000, Valuation = 500, ChargeType = "First", FirstName = "Abcfn", LastName = "Abcln", Gender = "Male", Contact = 9892804840, Postcode = 421605 });
        //    lsloanDetails.Add(new Model.LoanApplication.LoanDetails { Id = 2, Amount = 3000, Valuation = 1500, ChargeType = "Second", FirstName = "Xyzfn", LastName = "Xyzln", Gender = "female", Contact = 9892123456, Postcode = 427894 });

        //    return lsloanDetails;
        //}
    }
    
}
