using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba1.Models;

namespace IlyaMatlashKt_42_21.Tests
{
    public class ProfessorTests
    {
        [Fact]
        public void IsValidFirstName_Иван_Test()
        {
            var testProfessor = new Professor
            {
                LastName = "Петров",
                FirstName = "Иван",
                MiddleName = "Михайлович"
            };
            var resultLastName = testProfessor.isValidLastName();
            var resultFirstName = testProfessor.isValidFirstName();
            var resultMiddleName = testProfessor.isValidMiddleName();
            Assert.True(resultLastName);
            Assert.True(resultFirstName);
            Assert.True(resultMiddleName);
        }
    }
}
