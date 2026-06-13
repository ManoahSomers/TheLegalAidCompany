using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TLA.DomainModel;
using TLA.DomainModel.Request;
using TLA.ServiceAdapter.Cases;
using TLA.ServiceAdapter.CRM;
#pragma warning disable CS8618

namespace TLA.DomainAPI.UnitTests
{
    [TestClass]
    public class CaseDomainTests
    {
        private IDomain _domain;
        private Mock<ICaseProvider> _providerMock;
        private Mock<IRelationProvider> _relationProviderMock;
        private Mock<IPolicyProvider> _policyProviderMock;

        [TestInitialize]
        public void Initialize()
        {
            _providerMock = new Mock<ICaseProvider>(MockBehavior.Strict);
            _relationProviderMock = new Mock<IRelationProvider>(MockBehavior.Strict);
            _policyProviderMock = new Mock<IPolicyProvider>(MockBehavior.Strict);
            _domain = new Domain(_providerMock.Object, _relationProviderMock.Object, _policyProviderMock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _providerMock.VerifyAll();
            _relationProviderMock.VerifyAll();
            _policyProviderMock.VerifyAll();
        }

        [TestMethod]
        public void GetCases()
        {
            // Arrange
            var request = new GetCasesRequest { CustomerPpid = 1 };
            var getCasesResponse = new List<LegalCase>
            {
                new FamilyLawCase
                {
                    Name = "Divorce Settlement Smit",
                    Description = "Contested divorce with division of assets",
                    FilingDate = new DateTime(1993, 10, 13),
                    CaseFee = 50m,
                    CaseReference = "FAM-1993-0013",
                    NumberOfHearings = 3
                }
            };

            _providerMock.Setup(x => x.GetCases(1)).Returns(getCasesResponse);

            var expectedResponse = new List<LegalCase>
            {
                new FamilyLawCase
                {
                    Name = "Divorce Settlement Smit",
                    Description = "Contested divorce with division of assets",
                    FilingDate = new DateTime(1993, 10, 13),
                    CaseFee = 50m,
                    CaseReference = "FAM-1993-0013",
                    NumberOfHearings = 3
                }
            };

            // Act
            var actual = _domain.GetCases(request);

            // Assert
            actual.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
