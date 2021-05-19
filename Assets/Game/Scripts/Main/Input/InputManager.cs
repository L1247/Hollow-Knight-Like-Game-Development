using Rewired;
using Zenject;

namespace Main.Input
{
    public class InputManager : IInitializable , ITickable
    {
    #region Private Variables

        private bool initialized;

        private          float  lastHorzonTalValue = -999;
        private readonly int    playerId           = 0;
        private          Player player;

        [Inject]
        private SignalBus signalBus;

    #endregion

    #region Public Methods

        public void Initialize()
        {
            // Get the Rewired Player object for this player.
            player = ReInput.players.GetPlayer(playerId);

            initialized = true;
        }

        public void Tick()
        {
            if (!ReInput.isReady)
                return; // Exit if Rewired isn't ready. This would only happen during a script recompile in the editor.
            if (!initialized) Initialize(); // Reinitialize after a recompile in the editor

            GetInputValue();
        }

    #endregion

    #region Private Methods

        private void GetInputValue()
        {
            // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
            // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.
            // get input by name or action id
            // -1 : left , 0 : no press , 1 : right
            var horizontalValue = player.GetAxisRaw("Move Horizontal");
            if (lastHorzonTalValue != horizontalValue)
                signalBus.Fire(new Input_Horizontal((int)horizontalValue));
            lastHorzonTalValue = horizontalValue;
            var buttonDown_Jump = player.GetButtonDown("Jump");
            if (buttonDown_Jump)
                signalBus.Fire(new ButtonDownJump());
        }

    #endregion
    }

    public class ButtonDownJump { }

    public class Input_Horizontal
    {
    #region Public Variables

        public int HorizontalValue { get; }

    #endregion

    #region Constructor

        public Input_Horizontal(int horizontalValue)
        {
            HorizontalValue = horizontalValue;
        }

    #endregion
    }
}