#region

using Main.Entity;
using Main.Entity.Event;
using MainTests.ExtenjectTestFramework;
using NUnit.Framework;

#endregion

namespace Tests.EntityTests
{
    public class StatTests : SimpleTest
    {
    #region Test Methods

        [Test]
        public void Publish_ModifiedAmount()
        {
            var actorId  = GetGuid();
            var statName = GetGuid();
            var amount   = 999;
            var stat = StatBuilder.NewInstance()
                                  .SetActorId(actorId)
                                  .SetStatName(statName)
                                  .SetAmount(amount)
                                  .Build();
            var newAmount = 1003;
            stat.SetAmount(newAmount);
            var amountModified = stat.FindDomainEvent<AmountModified>();
            Assert.NotNull(amountModified , "amountModified is null");
            Assert.AreEqual(actorId ,   amountModified.ActorId ,  "ActorId is not equal");
            Assert.AreEqual(statName ,  amountModified.StatName , "StatName is not equal");
            Assert.AreEqual(newAmount , amountModified.Amount ,   "Amount is not equal");
        }

        [Test]
        public void Publish_StatCreated()
        {
            var actorId  = GetGuid();
            var statName = GetGuid();
            var amount   = 999;
            var stat     = new Stat(null , actorId , statName , amount);
            stat.Create();
            var statCreated = stat.FindDomainEvent<StatCreated>();
            Assert.NotNull(statCreated , "statCreated is null");
            Assert.AreEqual(actorId ,  statCreated.ActorId ,  "actorId is not equal");
            Assert.AreEqual(statName , statCreated.StatName , "StatName is not equal");
            Assert.AreEqual(amount ,   statCreated.Amount ,   "Amount is not equal");
        }

    #endregion
    }
}