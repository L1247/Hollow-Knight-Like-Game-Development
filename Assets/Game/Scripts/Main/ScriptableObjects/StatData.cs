#region

using System;
using Main.DomainData;
using UnityEngine;

#endregion

namespace Main.GameDataStructure
{
    [Serializable]
    public class StatData : IStatData
    {
    #region Public Variables

        public int Amount => amount;

        public string StatName => statName;

    #endregion

    #region Private Variables

        [SerializeField]
        private string statName;

        [SerializeField]
        private int amount;

    #endregion
    }
}