#region

using System.Collections.Generic;

#endregion

namespace DDDCore.Usecase
{
    public interface IRepository<T>
    {
    #region Public Methods

        bool ContainsId(string id);

        void    DeleteById(string id);
        List<T> FindAll();
        T       FindById(string id);
        void    Save(T          entity);

    #endregion
    }
}