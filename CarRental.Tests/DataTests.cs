using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CarRental.Data.Classes;
using CarRental.Data.Interfaces;

namespace CarRental.Tests
{
    public class DataTests
    {
        [Fact]
        public void CanCreateDataInstance()
        {
            IData dataSource = new CollectionData();

            Assert.NotNull(dataSource);
        }
    }
}
