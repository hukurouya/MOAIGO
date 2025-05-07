using UnityEngine;

public class SkillBeautyUp : BaseSkill
{
    public override SkillFactory.SkillKind skillKind
    {
        get { return SkillFactory.SkillKind.BeautyUp; }
    }

    public SkillBeautyUp() : base()
    {
        _skillName = "イケメン度アップ";
    }

    public override void Update()
    {
        Debug.Log("私はイケメン！！");

        base.Update();
    }

    public override void BuyElement()
    {
        _skillLevel++;

        Debug.Log("イケメン度UP");

        base.BuyElement();
    }
}
