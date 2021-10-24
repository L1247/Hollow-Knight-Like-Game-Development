#region

using DDDCore.Usecase;
using Main.Entity;

#endregion

namespace Main.UseCases.Stat
{
    public interface IStatRepository : IRepository<IStat>
    {
    #region Public Methods

        IStat FindStat(string actorId , string statName);

    #endregion
    }
}