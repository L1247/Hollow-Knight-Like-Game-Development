#region

using System.Collections.Generic;

#endregion

namespace Main.DomainData
{
    public interface IActorData
    {
    #region Public Variables

        List<IStatData> StatDatas   { get; }
        string          ActorDataId { get; }

    #endregion
    }
}