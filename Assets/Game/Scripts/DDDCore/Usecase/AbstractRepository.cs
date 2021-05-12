using System.Collections.Generic;
using DDDCore.Model;

namespace DDDCore.Usecase
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : AggregateRoot
    {
    #region Protected Variables

        protected List<T> entities = new List<T>();

    #endregion

    #region Public Methods

        public virtual void DeleteById(string id)
        {
            entities.Remove(FindById(id));
        }

        public virtual List<T> FindAll()
        {
            return entities;
        }

        public virtual T FindById(string id)
        {
            return entities.Find(_ => _.GetId() == id);
        }

        public virtual void Save(T entity)
        {
            entities.Add(entity);
        }

    #endregion
    }
}