using UnityEngine;

public class SkillGrowUp : BaseSkill
{
    public override SkillFactory.SkillKind skillKind
    {
        get { return SkillFactory.SkillKind.GrowUp; }
    }

    public SkillGrowUp() : base()
    {
        _skillName = "����";
    }

    public override void Update()
    {
        Debug.Log("���������I�I");

        base.Update();
    }

    public override void BuyElement()
    {
        _skillLevel++;

        Debug.Log("�����������I�I");

        base.BuyElement();
    }
}
