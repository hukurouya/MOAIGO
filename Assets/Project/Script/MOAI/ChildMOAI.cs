using JetBrains.Annotations;
using UnityEngine;

public class ChildMOAI : MonoBehaviour
{

    public Animator animator;

    /// <summary>
    /// アニメーションを指定して実行
    /// </summary>
    /// <param name="animationName">アニメーション名</param>
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void StayAnimation()
    {
        animator.Play("EncMOAI_Stay");
    }

}
