using UnityEngine;

public class MOAI : MonoBehaviour
{
    public MoaiStat stat;
    public Animator animator;

    private void Start()
    {
        stat = new MoaiStat();
    }
    private void Update()
    {
        if (stat == null) return;
        stat.UpdateSkill();
    }
    /// <summary>
    /// アニメーションを指定して実行
    /// </summary>
    /// <param name="animationName">アニメーション名</param>
    public void PlayAnimation(string animationName)
    {

        animator.Play(animationName);   
    }

    public void ClickAnimation()
    {
        animator.Play("MOAI_Click");
    }

    public void StayAnimation()
    {
        animator.Play("MOAI_Stay");
    }

    public void GenerationalChangeAnimation()
    {
        animator.Play("MOAI_GenerationalChange");
    }
    
}
