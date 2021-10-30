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

    #endregion
    }
}