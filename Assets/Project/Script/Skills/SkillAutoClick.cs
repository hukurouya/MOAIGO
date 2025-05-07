using UnityEngine;

public class SkillAutoClick : BaseSkill
{
    public override SkillFactory.SkillKind skillKind
    {
        get { return SkillFactory.SkillKind.AutoClick; }
    }

    public SkillAutoClick(GameManager manager) : base()
    {
        _manager = manager;
        _skillName = "�I�[�g�N���b�N";

        Initialize();
    }


    public void Initialize()
    {
        _skillLevel = 0;
        shopPrice = 100;
    }


    public override void Update()
    {
        if(_manager != null)
        {
            _manager.MOAI += _skillLevel;
        }
        
        Debug.Log("�����N���b�N");

        base.Update();
    }


    public override void BuyElement()
    {
        _skillLevel++;

        Debug.Log("�����N���b�N...���x���A�b�v");

        base.BuyElement();
    }
}
