using UnityEngine;

public class SkillEncountUp : BaseSkill
{
    public override SkillFactory.SkillKind skillKind
    {
        get { return SkillFactory.SkillKind.EncountUp; }
    }

    public SkillEncountUp() : base()
    {
        _skillName = "エンカウントアップ";
    }

    public override void Update()
    {
        Debug.Log("エンカウントだーー！！");

        base.Update();
    }

    public override void BuyElement()
    {
        _skillLevel++;

        Debug.Log("エンカウントUP");

        base.BuyElement();
    }
}
