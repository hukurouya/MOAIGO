using UnityEngine;

public class EncountMOAI : MonoBehaviour
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

    /// <summary>
    /// �ҋ@�A�j���[�V����
    /// </summary>
    public void StayAnimation()
    {
        animator.Play("EncMOAI_Stay");
    }

    /// <summary>
    /// �ړ��A�j���[�V����
    /// </summary>
    public void MoveAnimation()
    {
        animator.Play("EncMOAI_Move");
    }

    /// <summary>
    /// ������A�j���[�V����
    /// </summary>
    public void GenerationalChangeAnimation()
    {
        animator.Play("EncMOAI_GenerationalChange");
    }

    /// <summary>
    /// �o������A�j���[�V����
    /// </summary>
    public void LoveSuccessAnimation()
    {
        animator.Play("EncMOAI_LoveSuccess");
    }

    /// <summary>
    /// �o����s�A�j���[�V����
    /// </summary>
    public void LoveFailureAnimation()
    {
        animator.Play("EncMOAI_LoveFailure");
    }

}
