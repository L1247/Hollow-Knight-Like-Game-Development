using System.Collections;
using Main.ViewComponent;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MainTests.ActorTests
{
    public class UnityComponentTests
    {
    #region Test Methods

        [Test]
        public void Should_Velocity_Is_Correct_When_Jump()
        {
            // arrange
            var gameObject     = new GameObject();
            var rigidbody2D    = gameObject.AddComponent<Rigidbody2D>();
            var unityComponent = new UnityComponent(null , rigidbody2D);
            // act
            var upForce = Vector2.up * 1234;
            Assert.AreEqual(Vector2.zero , rigidbody2D.velocity);
            unityComponent.AddForce(upForce);
            // Assert
            Assert.AreEqual(upForce , rigidbody2D.velocity);
        }

    #endregion

    #region Public Methods

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator UnityComponentTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }

    #endregion
    }
}