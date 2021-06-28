using System;
using UnityEngine;

namespace Main.Decoupling
{
    [Serializable]
    public class ActorData
    {
    #region Public Variables

        public int Atk;
        public int Hp;

    #endregion

    #region Constructor

        public ActorData(int hp , int atk)
        {
            Hp  = hp;
            Atk = atk;
        }

    #endregion
    }

    public interface IDataBaseService
    {
    #region Public Methods

        ActorData GetActorData(int actorDataId);

    #endregion
    }

    public class FakeDataBaseService : IDataBaseService
    {
    #region Public Methods

        public ActorData GetActorData(int actorDataId)
        {
            if (actorDataId == 1)
            {
                var actorData = new ActorData(100 , 10);
                return actorData;
            }

            if (actorDataId == 2)
            {
                var actorData = new ActorData(200 , 50);
                return actorData;
            }

            return null;
        }

    #endregion
    }

    public class DataBaseServer
    {
    #region Public Methods

        public string GetActorData(int actorDataId)
        {
            var json = string.Empty;
            if (actorDataId == 1)
            {
                var actorData = new ActorData(100 , 10);
                json = JsonUtility.ToJson(actorData);
            }

            if (actorDataId == 2)
            {
                var actorData = new ActorData(200 , 50);
                json = JsonUtility.ToJson(actorData);
            }

            return json;
        }

    #endregion
    }

    public class DataBaseService : IDataBaseService
    {
    #region Private Variables

        private readonly DataBaseServer dataBaseServer;

    #endregion

    #region Constructor

        public DataBaseService(DataBaseServer dataBaseServer)
        {
            this.dataBaseServer = dataBaseServer;
        }

    #endregion

    #region Public Methods

        public ActorData GetActorData(int actorDataId)
        {
            var jsonString = dataBaseServer.GetActorData(actorDataId);
            var actorData  = JsonUtility.FromJson<ActorData>(jsonString);
            return actorData;
        }

    #endregion
    }
}