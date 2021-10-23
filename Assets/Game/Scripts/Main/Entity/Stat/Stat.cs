#region

using DDDCore.Model;

#endregion

namespace Main.Entity.Stat
{
    public class Stat : AggregateRoot
    {
    #region Constructor

        public Stat(string id) : base(id) { }

    #endregion
    }
}