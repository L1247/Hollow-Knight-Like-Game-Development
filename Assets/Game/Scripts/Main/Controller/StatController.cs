#region

using Main.UseCases.Stat;
using Zenject;

#endregion

namespace Main.Controller
{
    public class StatController
    {
    #region Private Variables

        [Inject]
        private CreateStatUseCase createStatUseCase;

        [Inject]
        private ModifyAmountUseCase modifyAmountUseCase;

        private readonly ModifyAmountInput modifyAmountInput;
        private readonly CreateStatInput   createStatInput;

    #endregion

    #region Constructor

        public StatController()
        {
            modifyAmountInput = new ModifyAmountInput();
            createStatInput   = new CreateStatInput();
        }

    #endregion

    #region Public Methods

        public void CreateStat(string actorId , string statName , int amount)
        {
            createStatInput.ActorId  = actorId;
            createStatInput.StatName = statName;
            createStatInput.Amount   = amount;
            createStatUseCase.Execute(createStatInput);
        }

        public void ModifyStatAmount(string actorId , string statName , int amount)
        {
            modifyAmountInput.ActorId  = actorId;
            modifyAmountInput.StatName = statName;
            modifyAmountInput.Amount   = amount;
            modifyAmountUseCase.Execute(modifyAmountInput);
        }

    #endregion
    }
}