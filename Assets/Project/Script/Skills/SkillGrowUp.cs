using UnityEngine;

public class SkillGrowUp : BaseSkill
{
    public override SkillFactory.SkillKind skillKind
    {
        get { return SkillFactory.SkillKind.GrowUp; }
    }

    public SkillGrowUp() : base()
    {
        _skillName = "成長";
    }

    public override void Update()
    {
        Debug.Log("成長中だ！！");

        base.Update();
    }

    public override void BuyElement()
    {
        _skillLevel++;

        Debug.Log("成長したぞ！！");

        base.BuyElement();
    }
}
