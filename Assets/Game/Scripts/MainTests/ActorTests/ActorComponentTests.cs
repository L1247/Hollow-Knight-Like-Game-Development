using Main.ViewComponent;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace MainTests.ActorTests
{
    public class ActorComponentTests
    {
    #region Test Methods

        [Test]
        public void Should_Succeed_When_Call_SetText()
        {
            // arrange
            var gameObject     = new GameObject();
            var actorComponent = gameObject.AddComponent<ActorComponent>();
            var textComponent  = gameObject.AddComponent<Text>();
            var displayText    = "fdsjhjkfh";
            actorComponent.text_IdAndDataId = textComponent;
            // act
            actorComponent.SetText(displayText);
            // assert
            Assert.NotNull(actorComponent.text_IdAndDataId);
            Assert.AreEqual(displayText , actorComponent.text_IdAndDataId.text);
        }

        [Test]
        [TestCase(1 , -1)]
        [TestCase(0 , 1)]
        public void Should_Succeed_When_Call_SetDirection(int directionValue , int expectedScaleValue)
        {
            // arrange
            var gameObject        = new GameObject();
            var actorComponent    = gameObject.AddComponent<ActorComponent>();
            var rendererTransform = new GameObject("Renderer").transform;
            actorComponent.Rednerer = rendererTransform;
            // act
            actorComponent.SetDirection(directionValue);
            // assert
            Assert.AreEqual(expectedScaleValue , rendererTransform.localScale.x);
        }

        [Test]
        public void Should_Is_Jumping_True_When_Call_Jump()
        {
            // arrange
            var gameObject     = new GameObject();
            var actorComponent = gameObject.AddComponent<ActorComponent>();
            actorComponent.isOnGround = true;
            Assert.AreEqual(true , actorComponent.isOnGround);
            // act
            actorComponent.Jump();
            // assert
            Assert.AreEqual(false , actorComponent.isOnGround);
        }

    #endregion

        // [Test]
        // public void Should_Succeed_When_Call_SetSprite()
        // {
        //     // arrange
        //     var gameObject     = new GameObject();
        //     var actorComponent = gameObject.AddComponent<ActorComponent>();
        //     var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        //     actorComponent.spriteRenderer = spriteRenderer;
        //     var texture = new Texture2D(32 , 32);
        //     var sprite = Sprite.Create(texture , new Rect(0 , 0 , 32 , 32)
        //         , new Vector2(16 , 16));
        //     // act
        //     actorComponent.SetSprite(sprite);
        //     // assert
        //     Assert.NotNull(actorComponent.spriteRenderer);
        //     Assert.AreEqual(sprite , actorComponent.spriteRenderer.sprite);
        // }
    }
}