using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopSkillElement : MonoBehaviour
{
    [Header("Text Setting")]
    [SerializeField] private TextMeshProUGUI _elementNameText;
    [SerializeField] private TextMeshProUGUI _elementPriceText;

    [Header("Value")]
    [SerializeField] private string _elementName = "NaN";
    [SerializeField] private string _elementPrice = "NaN";
    [SerializeField] private Button _button;

    private GameManager _gameManager;

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

    public void AddListener(IShopElement e)
    {
        _button.onClick.AddListener(() => { e.BuyElement(); });
    }

    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    void Update()
    {
        _elementNameText.text = _elementName;
        _elementPriceText.text = _elementPrice;
    }
}
