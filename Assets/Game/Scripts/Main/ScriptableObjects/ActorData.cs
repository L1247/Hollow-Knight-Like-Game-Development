#region

using System.Collections.Generic;
using System.Linq;
using Main.DomainData;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace Main.GameDataStructure
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "HK/CreateActorData" , order = 0)]
    public class ActorData : ScriptableObject , IActorData
    {
    #region Public Variables

        public int             Atk         => atk;
        public int             Health      => health;
        public List<IStatData> StatDatas   => statDatas.Cast<IStatData>().ToList();
        public string          ActorDataId => actorDataId;

        public GameObject ActorPrefab;

    #endregion

    #region Private Variables

        [SerializeField]
        [Required]
        [ValidateInput("@atk>0")]
        private int atk;

        [SerializeField]
        [ValidateInput("@health>0")]
        private int health;

        [SerializeField]
        [Required]
        private string actorDataId;

        [SerializeField]
        [BoxGroup("數值資料")]
        [HideLabel]
        private List<StatData> statDatas;

    #endregion
    }
}