using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkill : BaseShop
{
    private ShopSkillCanvas _canvasPrefab;
    private ShopSkillCanvas _canvas;
    private bool _isOpen;

    public void Open()
    {
        if( _isOpen ) return;

        ShopSkillCanvas prefab = AssetDatabase.LoadAssetAtPath<ShopSkillCanvas>("Assets/Project/Prefabs/UI/SkillShop/SkillShopCanvas.prefab");
        _canvas = GameObject.Instantiate(prefab); 
        Debug.Log($"Open SkillShop... { _canvas }" );

        CreateElement();

        _isOpen = true;
    }

    public void Close()
    {
        GameObject.Destroy( _canvas.gameObject );
        Debug.Log($"Close SkillShop...");

        _isOpen = false;
    }

    private ShopSkillElement _skillElement;

    private void CreateElement()
    {
        _shopElements = new List<IShopElement>();
        _shopElements.Add(SkillManager.GetSkills()[0]);
        _shopElements.Add(SkillManager.GetSkills()[1]);
        _shopElements.Add(SkillManager.GetSkills()[2]);
        _shopElements.Add(SkillManager.GetSkills()[3]);

        ShopSkillElement prefab = AssetDatabase.LoadAssetAtPath<ShopSkillElement>("Assets/Project/Prefabs/UI/SkillShop/SkillShopElement.prefab");
        for(int i = 0; i < _shopElements.Count; i++)
        {
            _skillElement = GameObject.Instantiate(prefab, _canvas.transform.Find("SkillShopGroup/ElementListView/Viewport/Content"));
            _skillElement.elementName = (_shopElements[i] as BaseSkill).skillName;
            _skillElement.elementPrice = (_shopElements[i] as BaseSkill).shopPrice.ToString();
            _skillElement.AddListener(_shopElements[i]);


            Debug.Log(_skillElement.transform.parent);
        }
    }
}
