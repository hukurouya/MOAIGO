using UnityEngine;

public interface IShopElement
{
    public int shopPrice 
    { 
        get; 
        set; 
    }

    public void BuyElement();
}
