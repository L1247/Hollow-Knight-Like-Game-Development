#region

using System;
using DDDCore.Usecase;
using Main.Entity;

#endregion

namespace Main.UseCases.Stat
{
    public class StatRepository : AbstractRepository<IStat> , IStatRepository
    {
    #region Public Methods

        public IStat FindStat(string actorId , string statName)
        {
            throw new NotImplementedException();
        }

    #endregion
    }
}