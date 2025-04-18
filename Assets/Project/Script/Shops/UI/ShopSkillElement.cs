using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSkillElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _elementNameText;
    [SerializeField] private TextMeshProUGUI _elementPriceText;

    [SerializeField] private string _elementName = "NaN";
    [SerializeField] private string _elementPrice = "NaN";

    public string elementName
    {
        get { return _elementName; }
        set { _elementName = value; }
    }

    public string elementPrice
    {
        get { return _elementPrice; }
        set { _elementPrice = value; }
    }

    void Update()
    {
        _elementNameText.text = _elementName;
        _elementPriceText.text = _elementPrice;
    }
}
