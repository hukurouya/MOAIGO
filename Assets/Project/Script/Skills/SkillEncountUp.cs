using UnityEngine;

public class SkillEncountUp : BaseSkill
{
    public override SkillFactory.SkillKind skillKind
    {
        get { return SkillFactory.SkillKind.EncountUp; }
    }

    public SkillEncountUp() : base()
    {
        _skillName = "�G���J�E���g�A�b�v";
    }

    public override void Update()
    {
        Debug.Log("�G���J�E���g���[�[�I�I");

        base.Update();
    }

    public override void BuyElement()
    {
        _skillLevel++;

        Debug.Log("�G���J�E���gUP");

        base.BuyElement();
    }
}
