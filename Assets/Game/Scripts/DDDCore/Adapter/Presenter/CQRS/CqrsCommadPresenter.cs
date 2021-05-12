using DDDCore.Usecase;
using DDDCore.Usecase.CQRS;

namespace DDDCore.Adapter.Presenter.CQRS
{
    public class CqrsCommandPresenter : Result , CqrsCommandOutput
    {
    #region Private Variables

        private string id;

    #endregion

    #region Public Methods

        public string GetId()
        {
            return id;
        }

        public CqrsCommandOutput SetId(string id)
        {
            this.id = id;
            return this;
        }

    #endregion
    }
}