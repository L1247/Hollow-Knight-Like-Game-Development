#region

using DDDCore.Usecase;

#endregion

namespace Main.UseCases.Stat
{
    public interface IStatRepository : IRepository<Entity.Stat>
    {
    #region Public Methods

        Entity.Stat FindStat(string actorId , string statName);

    #endregion
    }
}