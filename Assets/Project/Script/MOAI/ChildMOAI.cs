using JetBrains.Annotations;
using UnityEngine;

public class ChildMOAI : MonoBehaviour
{

    public Animator animator;

    /// <summary>
    /// �A�j���[�V�������w�肵�Ď��s
    /// </summary>
    /// <param name="animationName">�A�j���[�V������</param>
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void StayAnimation()
    {
        animator.Play("EncMOAI_Stay");
    }

}
