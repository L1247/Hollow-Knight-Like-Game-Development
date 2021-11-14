#region

using System;

#endregion

namespace DDDCore.Model
{
    public class DomainEvent
    {
    #region Public Variables

        public Type Type { get; }

    #endregion

    #region Constructor

        protected DomainEvent()
        {
            Type = GetType();
        }

    #endregion
    }
}