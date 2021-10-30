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

    #endregion

    #region Public Methods

        public void CreateStat(string actorId , string statName , int amount)
        {
            var input = new CreateStatInput();
            input.ActorId  = actorId;
            input.StatName = statName;
            input.Amount   = amount;
            createStatUseCase.Execute(input);
        }

        public void ModifyStatAmount(string actorId , string statName , int amount)
        {
            var input = new ModifyAmountInput();
            input.ActorId  = actorId;
            input.StatName = statName;
            input.Amount   = amount;
            modifyAmountUseCase.Execute(input);
        }

    #endregion
    }
}