using UnityEngine;

public class EncountMOAI : MonoBehaviour
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

    /// <summary>
    /// 待機アニメーション
    /// </summary>
    public void StayAnimation()
    {
        animator.Play("EncMOAI_Stay");
    }

    /// <summary>
    /// 移動アニメーション
    /// </summary>
    public void MoveAnimation()
    {
        animator.Play("EncMOAI_Move");
    }

    /// <summary>
    /// 世代交代アニメーション
    /// </summary>
    public void GenerationalChangeAnimation()
    {
        animator.Play("EncMOAI_GenerationalChange");
    }

    /// <summary>
    /// 出会い成功アニメーション
    /// </summary>
    public void LoveSuccessAnimation()
    {
        animator.Play("EncMOAI_LoveSuccess");
    }

    /// <summary>
    /// 出会い失敗アニメーション
    /// </summary>
    public void LoveFailureAnimation()
    {
        animator.Play("EncMOAI_LoveFailure");
    }

}
