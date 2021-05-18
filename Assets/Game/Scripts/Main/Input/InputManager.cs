using Rewired;
using Zenject;

namespace Main.Input
{
    public class InputManager : IInitializable , ITickable
    {
    #region Private Variables

        private          bool   initialized;
        private readonly int    playerId = 0;
        private          Player player;

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
            var horizontalValue = player.GetAxisRaw("Move Horizontal");
        }

    #endregion
    }
}