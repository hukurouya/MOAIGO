using UnityEngine;

public abstract class BaseSkill : IShopElement
{
    protected GameObject _target;
    protected string _skillName;
    protected int _skillLevel;
    protected GameManager _manager;

    public BaseSkill()
    {
        _skillLevel = 0;
    }

    public abstract SkillFactory.SkillKind skillKind {  get; }

    public GameObject target
    {
        get { return _target; }
    }

    public string skillName
    {
        get { return _skillName; }
    }

    public int skillLevel
    {
        get { return _skillLevel; }
    }

    public int shopPrice 
    { 
        get; 
        set;
    }

    public virtual void BuyElement()
    {
        
    }

    public virtual void Update()
    {
        
    }
}
