using System;

namespace Main.UseCases.Repository
{
    public interface iDataRepository
    {
    #region Public Methods

    #endregion
        ActorDomainData GetActorDomainData(string actorDataId);
    }

    [Serializable]
    public class ActorDomainData
    {
        public int Health;
    }
}