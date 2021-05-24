using System.Collections;
using AutoBot.Scripts.Utilities;
using Main.ViewComponent;
using NUnit.Framework;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.TestTools;

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
    public IEnumerator Should_Play_Animation_Via_Animator_When_Call_PlayAnimation()
    {
        // results
        var animators          = CustomEditorUtility.GetAssets("sword_man");
        var animatorController = animators.Find(obj => obj is AnimatorController) as RuntimeAnimatorController;
        var gameObject         = new GameObject();
        var animator           = gameObject.AddComponent<Animator>();
        animator.runtimeAnimatorController = animatorController;
        var unityComponent = new UnityComponent(animator , null);
        var isJump         = animator.GetCurrentAnimatorStateInfo(0).IsName("Jump");
        Assert.AreEqual(false , isJump);

        var isIdle = animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        Assert.AreEqual(true , isIdle);
        // act
        unityComponent.PlayAnimation("Jump");
        yield return null;
        // assert
        isJump = animator.GetCurrentAnimatorStateInfo(0).IsName("Jump");
        Assert.AreEqual(true , isJump);
    }

#endregion
}