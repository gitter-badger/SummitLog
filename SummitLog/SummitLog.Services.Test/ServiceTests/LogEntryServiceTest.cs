﻿using System;
using System.Collections.Generic;
using FluentAssertions;

using Moq;
using NUnit.Framework;
using SummitLog.Services.Model;
using SummitLog.Services.Persistence;
using SummitLog.Services.Persistence.Impl;
using SummitLog.Services.Services;
using SummitLog.Services.Services.Impl;

namespace SummitLog.Services.Test.ServiceTests
{
    [TestFixture]
    public class LogEntryServiceTest
    {
        [Test]
        public void TestGetAll()
        {
            Mock<ILogEntryDao> logDaoMock = new Mock<ILogEntryDao>();
            logDaoMock.Setup(x => x.GetAllIn(It.IsAny<Variation>())).Returns(new List<LogEntry> {new LogEntry()});

            Variation fakeVariation = new Variation();

            ILogEntryService logService = new LogEntryService(logDaoMock.Object);
            IList<LogEntry> logsInVariation = logService.GetAllIn(fakeVariation);
            Assert.AreEqual(1, logsInVariation.Count);

            logDaoMock.Verify(x=>x.GetAllIn(fakeVariation), Times.Once);
        }

        [Test]
        public void TestCreate()
        {
            Mock<ILogEntryDao> logDaoMock = new Mock<ILogEntryDao>();
            logDaoMock.Setup(x => x.Create(It.IsAny<Variation>(), It.IsAny<LogEntry>()));

            Variation fakeVariation = new Variation();

            ILogEntryService logService = new LogEntryService(logDaoMock.Object);
            logService.Create(fakeVariation, DateTime.Today, "freeclimb");

            logDaoMock.Verify(x=>x.Create(fakeVariation, It.Is<LogEntry>(y=>y.Memo == "freeclimb" && y.DateTime == DateTime.Today)), Times.Once);
        }

        [TestCase(true,"")]
        [TestCase(true, " ")]
        [TestCase(true, "    ")]
        [TestCase(true, null)]
        [TestCase(false, "freeclimb", ExpectedException = typeof(ArgumentNullException))]
        public void TestCreateWithSomeMissing(bool useVariation, string name)
        {
            Variation fakeVariation = null;
            if (useVariation)
            {
                fakeVariation = new Variation();
            }
            Mock<ILogEntryDao> logEntryDaoMock = new Mock<ILogEntryDao>();
            new LogEntryService(logEntryDaoMock.Object).Create(fakeVariation, DateTime.Today, name);
        }

        [Test]
        public void TestGetAllWithoutVariation()
        {
            Action act = ()=> new LogEntryService(null).GetAllIn(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TestDeleteNull()
        {
            Action act = ()=> new LogEntryService(null).Delete(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void TestDelete()
        {
            Mock<ILogEntryDao> logEntryDaoMock = new Mock<ILogEntryDao>();
            logEntryDaoMock.Setup(x => x.Delete(It.IsAny<LogEntry>()));

            LogEntry logEntry = new LogEntry();

            ILogEntryService logEntryService = new LogEntryService(logEntryDaoMock.Object);

            logEntryService.Delete(logEntry);
            
            logEntryDaoMock.Verify(x=>x.Delete(logEntry), Times.Once);
        }

        [Test]
        public void TestSave()
        {
            Mock<ILogEntryDao> logEntryDaoMock = new Mock<ILogEntryDao>();
            logEntryDaoMock.Setup(x => x.Save(It.IsAny<LogEntry>()));

            LogEntry logEntry = new LogEntry();

            ILogEntryService logEntryService = new LogEntryService(logEntryDaoMock.Object);
            logEntryService.Save(logEntry);

            logEntryDaoMock.Verify(x=>x.Save(logEntry), Times.Once);
        }

        [Test]
        public void TestSaveNull()
        {
            Action action = ()=> new LogEntryService(null).Save(null);
            action.ShouldThrow<ArgumentNullException>();
        }
    }
}