using Main.Stub.Decoupling;
using Main.Decoupling.Stub;
using NSubstitute;
using NUnit.Framework;

namespace Tests.DecouplingTests
{
    public class StubTestsOfC
    {
        [Test]
        public void Get_Result()
        {
            var b = Substitute.For<I_B>();
            // BData bData = new BData();
            var bData = BDataBuilder
                        .NewInstance()
                        .SetBDataValue(2)
                        .Build();
            b.GetResult().Returns(bData);
            var c      = new C(b);
            var result = c.GetResult();
            Assert.AreEqual(1 , result.Value);
        }
    }
}