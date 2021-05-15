using System.Collections.Generic;
using Main.ViewComponent;

namespace Main.Presenters
{
    public class ActorMapper
    {
    #region Private Variables

        private readonly List<ActorViewData> actorViewDatas = new List<ActorViewData>();

    #endregion

    #region Public Methods

        public void CreateActorViewData(string actorId , string actorDataId , ActorComponent actorComponent)
        {
            var actorViewData = new ActorViewData(actorId , actorDataId , actorComponent);
            actorViewDatas.Add(actorViewData);
        }

    #endregion
    }

    public class ActorViewData
    {
    #region Public Variables

        public ActorComponent ActorComponent { get; }
        public string         ActorDataId    { get; }
        public string         ActorId        { get; }

    #endregion

    #region Constructor

        public ActorViewData(string actorId , string actorDataId , ActorComponent actorComponent)
        {
            ActorId        = actorId;
            ActorDataId    = actorDataId;
            ActorComponent = actorComponent;
        }

    #endregion
    }
}