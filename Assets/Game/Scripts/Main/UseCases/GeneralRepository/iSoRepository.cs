using Main.ScriptableObjects;

namespace Main.UseCases.Repository
{
    public interface iSoRepository
    {
    #region Public Methods

        ActorData GetActorData(string actorDataId);

    #endregion
    }
}