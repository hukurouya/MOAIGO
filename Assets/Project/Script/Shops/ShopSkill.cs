using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
        shopElements = new List<IShopElement>();

        BaseSkill skill_autoClick = new SkillAutoClick();
        BaseSkill skill_growUp = new SkillGrowUp();
        BaseSkill skill_BeautyUp = new SkillBeautyUp();
        BaseSkill skill_encountUp = new SkillEncountUp();

        shopElements.Add(skill_autoClick);
        shopElements.Add(skill_growUp);
        shopElements.Add(skill_BeautyUp);
        shopElements.Add(skill_encountUp);

        ShopSkillElement prefab = AssetDatabase.LoadAssetAtPath<ShopSkillElement>("Assets/Project/Prefabs/UI/SkillShop/SkillShopElement.prefab");
        for(int i = 0; i < shopElements.Count; i++)
        {
            _skillElement = GameObject.Instantiate(prefab, _canvas.transform.Find("SkillShopGroup/ElementListView/Viewport/Content"));
            _skillElement.elementName = (shopElements[i] as BaseSkill).skillName;
            _skillElement.elementPrice = (shopElements[i] as BaseSkill).shopPrice.ToString();

            Debug.Log(_skillElement.transform.parent);
        }
    }
}
