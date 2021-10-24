#region

using System;
using DDDCore.Usecase;

#endregion

namespace Main.UseCases.Stat
{
    public class StatRepository : AbstractRepository<Entity.Stat> , IStatRepository
    {
    #region Public Methods

        public Entity.Stat FindStat(string actorId , string statName)
        {
            throw new NotImplementedException();
        }

    #endregion
    }
}