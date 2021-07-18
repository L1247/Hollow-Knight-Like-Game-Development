using Entity.Builder;
using Entity.Events;
using NUnit.Framework;

public class ActorEventTests
{
#region Test Methods

    [Test]
    public void Should_Publish_Actor_Created_When_Create_Actor()
    {
        var actorId     = "1234";
        var actorDataId = "Pokemon";
        var actor = ActorBuilder.NewInstance()
                                .SetActorId(actorId)
                                .SetActorDataId(actorDataId)
                                .Build();
        var domainEvents = actor.GetDomainEvents();
        Assert.AreEqual(1 , domainEvents.Count);
        var actorCreated = domainEvents[0] as ActorCreated;
        Assert.AreEqual(actorId ,     actorCreated.ActorId);
        Assert.AreEqual(actorDataId , actorCreated.ActorDataId);
        Assert.AreEqual(1 ,           actorCreated.Direction);
    }

    [Test]
    public void Should_Publish_Direction_Changed_When_Change_Direction()
    {
        var actorId   = "1234";
        var direction = 123789127;
        var actor = ActorBuilder.NewInstance()
                                .SetActorId(actorId)
                                .Build();
        actor.ChangeDirection(direction);
        var domainEvents = actor.GetDomainEvents();
        Assert.AreEqual(2 , domainEvents.Count);
        var directionChanged = domainEvents[1] as DirectionChanged;
        Assert.AreEqual(actorId ,   directionChanged.ActorId);
        Assert.AreEqual(direction , directionChanged.Direction);
    }

    [Test]
    public void Should_Not_Publish_Direction_Changed_When_Change_Direction_With_IsDead_True()
    {
        var actorId   = "1234";
        var direction = 123789127;
        var actor = ActorBuilder.NewInstance()
                                .SetActorId(actorId)
                                .Build();
        actor.MakeDie();
        actor.ChangeDirection(direction);
        Assert.AreEqual( true , actor.IsDead );
        var domainEvents = actor.GetDomainEvents();
        Assert.AreEqual(2 , domainEvents.Count);
    }


    [Test]
    public void Should_Publish_Damage_Dealt_When_Deal_Damage()
    {
        var actorId = "1234";
        var health  = 99;
        var damage  = 87;
        var actor = ActorBuilder.NewInstance()
                                .SetActorId(actorId)
                                .SetHealth(health)
                                .Build();
        actor.DealDamage(damage);
        var domainEvents = actor.GetDomainEvents();
        Assert.AreEqual(2 , domainEvents.Count);
        var damageDealt = domainEvents[1] as DamageDealt;
        Assert.AreEqual(actorId ,         damageDealt.ActorId);
        Assert.AreEqual(health - damage , damageDealt.CurrentHealth);
    }

    [Test]
    public void Should_Publish_Actor_Dead_When_Make_Die()
    {
        var actorId = "1234";
        var actor = ActorBuilder.NewInstance()
                                .SetActorId(actorId)
                                .Build();
        actor.MakeDie();
        var domainEvents = actor.GetDomainEvents();
        Assert.AreEqual(2 , domainEvents.Count);
        var actorDead = domainEvents[1] as ActorDead;
        Assert.AreEqual(actorId , actorDead.ActorId);
    }

#endregion
}