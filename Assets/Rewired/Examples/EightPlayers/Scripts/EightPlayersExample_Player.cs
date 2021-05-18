// Copyright (c) 2014 Augie R. Maddox, Guavaman Enterprises. All rights reserved.

using System;
using UnityEngine;

namespace Rewired.Demos
{
    [AddComponentMenu("")]
    [RequireComponent(typeof(CharacterController))]
    public class EightPlayersExample_Player : MonoBehaviour
    {
    #region Public Variables

        public float bulletSpeed = 15.0f;

        public float      moveSpeed = 3.0f;
        public GameObject bulletPrefab;
        public int        playerId; // The Rewired player id of this character

    #endregion

    #region Private Variables

        private bool fire;

        [NonSerialized] // Don't serialize this so the value is lost on an editor script recompile.
        private bool initialized;

        private CharacterController cc;

        private Player  player; // The Rewired Player
        private Vector3 moveVector;

    #endregion

    #region Private Methods

        private void Awake()
        {
            // Get the character controller
            cc = GetComponent<CharacterController>();
        }

        private void GetInput()
        {
            // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
            // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

            moveVector.x = player.GetAxis("Move Horizontal"); // get input by name or action id
            moveVector.y = player.GetAxis("Move Vertical");
            fire         = player.GetButtonDown("Fire");
        }

        private void Initialize()
        {
            // Get the Rewired Player object for this player.
            player = ReInput.players.GetPlayer(playerId);

            initialized = true;
        }

        private void ProcessInput()
        {
            // Process movement
            if (moveVector.x != 0.0f || moveVector.y != 0.0f) cc.Move(moveVector * moveSpeed * Time.deltaTime);

            // Process fire
            if (fire)
            {
                var bullet = Instantiate(bulletPrefab , transform.position + transform.right ,
                    transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.right * bulletSpeed , ForceMode.VelocityChange);
            }
        }

        private void Update()
        {
            if (!ReInput.isReady)
                return; // Exit if Rewired isn't ready. This would only happen during a script recompile in the editor.
            if (!initialized) Initialize(); // Reinitialize after a recompile in the editor

            GetInput();
            ProcessInput();
        }

    #endregion
    }
}