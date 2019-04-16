using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        public Housekeeper _housekeeper;
        private DateTime _dateTime;

        private Mock<IStateGenerator> _stateGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _xtraMessageBox;
        private HousekeeperService _service;
        private string _statementFileName;

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper
            {
                Email = "a",
                FullName = "b",
                Oid = 3
            };
            _dateTime = new DateTime(2019, 4, 16);
            _statementFileName = "fileName";

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>())
                .Returns(new List<Housekeeper>
                {
                    _housekeeper
                }.AsQueryable());

            _stateGenerator = new Mock<IStateGenerator>();
            _stateGenerator.Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _dateTime))
                .Returns(() => _statementFileName);

            _emailSender = new Mock<IEmailSender>();

            _xtraMessageBox = new Mock<IXtraMessageBox>();

            _service = new HousekeeperService(
                unitOfWork.Object, _stateGenerator.Object, _emailSender.Object, _xtraMessageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCall_GenerateStatement()
        {
            _service.SendStatementEmails(_dateTime);

            _stateGenerator.Verify(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _dateTime));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_EmailIsNullOrWhiteSpace_CanNotPassThroughSaveStatement(string email)
        {
            _housekeeper.Email = email;

            _service.SendStatementEmails(_dateTime);

            _stateGenerator.Verify(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _dateTime),
                Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenStatementFileNameIsNotNull_ProcessThroughtTheEmailFile()
        {
            _service.SendStatementEmails(_dateTime);

            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void SendStatementEmails_StatementFileNameIsNullOrWhiteSpace_CantPassThroughTheEmailFile(string statementFileName)
        {
            _statementFileName = statementFileName;

            _service.SendStatementEmails(_dateTime);

            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void SendStatementEmails_FailsSendedEmailFile_ThrowException()
        {
            _emailSender.Setup(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()))
                .Throws<Exception>();

            _service.SendStatementEmails(_dateTime);

            _xtraMessageBox.Verify(mb => mb.Show(
                It.IsAny<string>(),
                It.IsAny<string>(),
                MessageBoxButtons.OK));
        }
    }
}
