﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using FluentAssert;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using SummitLog.Services.Exceptions;
using SummitLog.Services.Model;
using SummitLog.Services.Persistence;
using SummitLog.Services.Services;
using SummitLog.Services.Services.Impl;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SummitLog.Services.Test.ServiceTests
{
    [TestFixture]
    public class CountryServiceTest
    {
        [Test]
        public void TestGetAll()
        {
            Mock<ICountryDao> countryDaoMock = new Mock<ICountryDao>();
            countryDaoMock.Setup(x => x.GetAll()).Returns(new List<Country> {new Country {Name = "D"}});

            ICountryService countryService = new CountryService(countryDaoMock.Object);
            IList<Country> result = countryService.GetAll();
            Assert.AreEqual(1, result.Count);
            countryDaoMock.Verify(x=>x.GetAll(), Times.Once);
        }

        [Test]
        public void TestCreate()
        {
            Mock<ICountryDao> countryDaoMock = new Mock<ICountryDao>();
            countryDaoMock.Setup(x => x.Create(It.IsAny<Country>()));

            string countryName = "D";

            ICountryService countryService = new CountryService(countryDaoMock.Object);
            countryService.Create(countryName);

            countryDaoMock.Verify(x=>x.Create(It.Is<Country>(y=>y.Name == countryName)));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        [TestCase(null)]
        public void TestMissingName(string name)
        {
            Action act = ()=>new CountryService(null).Create(name);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TestIsInUse()
        {
            Mock<ICountryDao> countryDaoMock = new Mock<ICountryDao>();
            countryDaoMock.Setup(x => x.IsInUse(It.IsAny<Country>())).Returns(true);

            Country country = new Country();

            ICountryService countryService = new CountryService(countryDaoMock.Object);
            bool isInUse = countryService.IsInUse(country);

            Assert.IsTrue(isInUse);
            countryDaoMock.Verify(x=>x.IsInUse(country), Times.Once);
        }

        [TestCase(false)]
        [TestCase(true, ExpectedException = typeof(NodeInUseException))]
        public void TestDelete(bool isInUse)
        {
            Mock<ICountryDao> countryDaoMock = new Mock<ICountryDao>();
            countryDaoMock.Setup(x => x.IsInUse(It.IsAny<Country>())).Returns(isInUse);
            countryDaoMock.Setup(x => x.Delete(It.IsAny<Country>()));

            Country country = new Country();

            ICountryService countryService = new CountryService(countryDaoMock.Object);
            countryService.Delete(country);

            countryDaoMock.Verify(x => x.IsInUse(country), Times.Once);
            countryDaoMock.Verify(x => x.Delete(country), Times.Once);
        }

        [Test]
        public void TestSave()
        {
            Mock<ICountryDao> countryDaoMock = new Mock<ICountryDao>();
            countryDaoMock.Setup(x => x.Save(It.IsAny<Country>()));

            Country country = new Country();

            ICountryService countryService = new CountryService(countryDaoMock.Object);
            countryService.Save(country);

            countryDaoMock.Verify(x=>x.Save(country), Times.Once);

        }

        [Test]
        public void TestSaveNull()
        {
            ICountryService countryService = new CountryService(null);
            NUnit.Framework.Assert.Throws<ArgumentNullException>(()=>countryService.Save(null));
        }
    }
}