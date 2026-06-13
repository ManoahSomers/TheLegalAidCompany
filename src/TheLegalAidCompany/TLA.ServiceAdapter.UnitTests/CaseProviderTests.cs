using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLA.ServiceAdapter.Cases;

namespace TLA.ServiceAdapter.UnitTests
{
    [TestClass]
    public class CaseProviderTests
    {
        private readonly ICaseProvider _provider = new CaseProvider();

        [TestMethod]
        public void GetCases_ReturnsCases()
        {
            var cases = _provider.GetCases(1);

            cases.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void AddCase_AddsACase()
        {
            var countBefore = _provider.GetCases(0).Count();

            _provider.AddCase(new TLA.DomainModel.LaborLawCase());

            var countAfter = _provider.GetCases(0).Count();
            countAfter.Should().Be(countBefore + 1);
        }
    }
}
