using JabulaniRubiblueAss.Repository.Data;
using JabulaniRubiblueAss.Repository.Student;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Repository.Tests
{
    public class StudentRepositoryTests
    {
        private StudentRepostory StudentRepostory;
        private ApplicationDbContext _context;

        [SetUp]
        public void Initialize()
        {
            StudentRepostory = new StudentRepostory(_context);
        }

    }
}
