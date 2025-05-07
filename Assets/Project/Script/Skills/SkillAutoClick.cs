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
        _skillName = "オートクリック";

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
        
        Debug.Log("自動クリック");

        base.Update();
    }


    public override void BuyElement()
    {
        _skillLevel++;

        Debug.Log("自動クリック...レベルアップ");

        base.BuyElement();
    }
}
