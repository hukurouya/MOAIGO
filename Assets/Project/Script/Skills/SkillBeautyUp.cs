using UnityEngine;

public class SkillBeautyUp : BaseSkill
{
    public override SkillFactory.SkillKind skillKind
    {
        get { return SkillFactory.SkillKind.BeautyUp; }
    }

    public SkillBeautyUp() : base()
    {
        _skillName = "�C�P�����x�A�b�v";
    }

    public override void Update()
    {
        Debug.Log("���̓C�P�����I�I");

        base.Update();
    }

    public override void BuyElement()
    {
        _skillLevel++;

        Debug.Log("�C�P�����xUP");

        base.BuyElement();
    }
}
