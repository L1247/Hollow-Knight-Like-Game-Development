using System.Collections.Generic;
using DDDCore.Model;

namespace DDDCore.Usecase
{
    public interface IRepository<T>
    {
    #region Public Methods

        List<T> FindAll();
        T       FindById(string id);
        void    Save(T          entity);

    #endregion
    }
}