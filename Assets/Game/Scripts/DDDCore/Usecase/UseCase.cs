using DDDCore.Model;
using Zenject;

namespace DDDCore.Usecase
{
    /// <summary>
    /// </summary>
    /// <typeparam name="I">Input</typeparam>
    /// <typeparam name="R">Repository</typeparam>
    public abstract class UseCase<I ,  R> where I : Input
    {
    #region Protected Variables

        protected readonly DomainEventBus domainEventBus;

        protected R repository;

    #endregion

    #region Public Methods

        public abstract void Execute(I input);

    #endregion

        [Inject]
        public UseCase(DomainEventBus domainEventBus , R repository)
        {
            this.domainEventBus = domainEventBus;
            this.repository     = repository;
        }
    }
}