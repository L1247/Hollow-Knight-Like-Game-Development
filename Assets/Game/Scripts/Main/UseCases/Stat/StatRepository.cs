#region

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
            var foundStat = entities.Find(stat => stat.ActorId == actorId && stat.Name == statName);
            return foundStat;
        }

    #endregion
    }
}