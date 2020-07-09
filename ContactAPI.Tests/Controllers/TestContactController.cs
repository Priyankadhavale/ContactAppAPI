
using ContactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactAPI.Controllers;

namespace ContactAPI.Tests.Controllers
{
    [TestClass]
    public class TestContactController
    {
        private ContactDetailsController _controller;

        public TestContactController()
        {
            _controller = new ContactDetailsController();
        }

        [TestMethod]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            var controller = new ContactDetailsController();

            var result = _controller.GetContactDetails();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetContactById_ShouldReturnContact()
        {
            var controller = new ContactDetailsController();

            var result = await _controller.GetContactDetail(4);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task AddEmployee_ShouldAddEmployee()
        {
            ContactDetail cd = new ContactDetail
            {
                FirstName = "Demo1",
                LastName = "DemoLast1",
                Email = "abc@abc.com",
                PhoneNumber = "9876543210",
                Status = true
            };

            var result = await _controller.PostContactDetail(cd);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task UpdateEmployee_ShouldUpdateEmployee()
        {
            ContactDetail cd = new ContactDetail
            {
                ID = 4,
                FirstName = "Demo4",
                LastName = "DemoLast4",
                Email = "demolast4@abc.com",
                PhoneNumber = "84375687435",
                Status = true
            };

            var result = await _controller.PutContactDetail(cd);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteEmployee_ShouldDeleteEmployee()
        {
            var result = await _controller.DeleteContactDetail(4);
            Assert.IsNotNull(result);
        }
    }
}
