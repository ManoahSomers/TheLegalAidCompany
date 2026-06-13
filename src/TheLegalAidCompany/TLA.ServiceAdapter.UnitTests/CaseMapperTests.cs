using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLA.ServiceAdapter.Cases.Mappers;
using TLA.ServiceAdapter.Cases.Models;

namespace TLA.ServiceAdapter.UnitTests
{
    [TestClass]
    public class CaseMapperTests
    {
        [TestMethod]
        public void Map_ContractDisputeCase_MapsToDomainContractDisputeCase()
        {
            var source = new ContractDisputeCase
            {
                Name = "Test Dispute",
                Description = "A contract dispute",
                CaseFee = 100,
                ClaimAmount = 5000,
                Jurisdictions = new List<Jurisdiction> { new() { Code = "NL", Name = "Netherlands" } }
            };

            var result = source.Map();

            result.Should().BeOfType<TLA.DomainModel.ContractDisputeCase>();
            var mapped = (TLA.DomainModel.ContractDisputeCase)result;
            mapped.Name.Should().Be("Test Dispute");
            mapped.Description.Should().Be("A contract dispute");
            mapped.CaseFee.Should().Be(100);
            mapped.ClaimAmount.Should().Be(5000);
            mapped.Jurisdictions.Should().ContainSingle(j => j.Code == "NL");
        }

        [TestMethod]
        public void Map_LaborLawCase_MapsToDomainLaborLawCase()
        {
            var source = new LaborLawCase
            {
                Name = "Test Labor",
                Description = "A labor dispute",
                CaseFee = 80,
                ClaimAmount = 25000,
                Settled = true,
                SettlementAmount = 500
            };

            var result = source.Map();

            result.Should().BeOfType<TLA.DomainModel.LaborLawCase>();
            var mapped = (TLA.DomainModel.LaborLawCase)result;
            mapped.Name.Should().Be("Test Labor");
            mapped.ClaimAmount.Should().Be(25000);
            mapped.Settled.Should().BeTrue();
            mapped.SettlementAmount.Should().Be(500);
        }
    }
}
