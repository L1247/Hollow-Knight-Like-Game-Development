#region

using System;
using DDDCore.Model;

#endregion

namespace Main.Entity
{
    public class StatBuilder : AbstractBuilder<StatBuilder , Stat>
    {
    #region Private Variables

        private string statId;
        private string actorId;
        private string statName;
        private int    amount;

    #endregion

    #region Public Methods

        public override Stat Build()
        {
            statId = statId == null ? Guid.NewGuid().ToString() : statId;
            var stat = new Stat(statId , actorId , statName , amount);
            stat.Create();
            return stat;
        }

        public StatBuilder SetActorId(string actorId)
        {
            this.actorId = actorId;
            return this;
        }

        public StatBuilder SetAmount(int amount)
        {
            this.amount = amount;
            return this;
        }

        public StatBuilder SetStatId(string id)
        {
            statId = id;
            return this;
        }

        public StatBuilder SetStatName(string statName)
        {
            this.statName = statName;
            return this;
        }

    #endregion
    }
}