using UnityEngine;

public abstract class BaseSkill : IShopElement
{
    protected GameObject _target;
    protected string _skillName;
    protected int _skillLevel;

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


    public void BuyElement()
    {
        
    }
}
