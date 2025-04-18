using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopSkill shopSkill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopSkill = new ShopSkill();
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
    }
}
