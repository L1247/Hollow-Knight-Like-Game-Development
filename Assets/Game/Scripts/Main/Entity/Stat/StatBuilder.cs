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

    #endregion

    #region Public Methods

        public override Stat Build()
        {
            statId = statId == null ? Guid.NewGuid().ToString() : statId;
            var stat = new Stat(statId);
            return stat;
        }

        public StatBuilder SetStatId(string id)
        {
            statId = id;
            return this;
        }

    #endregion
    }
}