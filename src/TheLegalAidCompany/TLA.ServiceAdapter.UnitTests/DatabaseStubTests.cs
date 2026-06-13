using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLA.ServiceAdapter.Cases.Models;
using TLA.ServiceAdapter.Cases.Stubs;

namespace TLA.ServiceAdapter.UnitTests
{
    [TestClass]
    public class DatabaseStubTests
    {
        [TestMethod]
        public void GetAllCases_ReturnsSeededCases()
        {
            var cases = DatabaseStub.GetAllCases();

            cases.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Add_AddsACase()
        {
            // Only verifies the count grows by one. The store is a shared static, so
            // the assertion is relative (before/after) to stay independent of test order.
            var countBefore = DatabaseStub.GetAllCases().Count();

            DatabaseStub.Add(new LaborLawCase());

            DatabaseStub.GetAllCases().Count().Should().Be(countBefore + 1);
        }
    }
}
