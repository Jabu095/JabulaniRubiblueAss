using JabulaniRubiblueAss.Service.Student;
using JabulaniRubiblueAss.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Web.Tests
{
    public class StudentControllerTests
    {
        private Mock<IStudentService> StudentServiceMock = new Mock<IStudentService>();
        private StudentsController StudentsController;

        [SetUp]
        public void Initialize()
        {
            StudentsController = new StudentsController(StudentServiceMock.Object);
        }
    }
}
