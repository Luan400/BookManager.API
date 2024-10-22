using BookManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UnitTests.Core.Entities
{
    public class LoansTest
    {
        [Fact]

        public void TestIfLoansWork()
        {
            var loans = new Loans(5, 4, new DateTime(2024, 04, 03));

            Assert.NotNull(loans);


        }
    }
}
