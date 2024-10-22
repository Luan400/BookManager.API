using BookManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UnitTests.Core.Entities
{
    
    public class DevolutionTest
    {
        [Fact]

        public void TestIfDevolutionWork()
        {
            var devolution = new Devolution(new DateTime(2024, 3, 3)); 

            Assert.NotNull(devolution);


        }
    }
}
