using UnityEngine;

public class SkillShopScene : MonoBehaviour
{
    public ShopSkill shopSkill;
    public MoaiStat moai;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopSkill = new ShopSkill();
        moai = new MoaiStat();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(shopSkill == null) return;
            
            shopSkill.Open();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (shopSkill == null) return;
            
            shopSkill.Close();
        }

        if(moai == null) return;
        moai.UpdateSkill();
    }
}
