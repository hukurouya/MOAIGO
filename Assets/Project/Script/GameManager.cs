using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public double MOAI; // モアイ数

    public float ClickGainMOAI; // クリックで得られる量

    public TextMeshProUGUI MOAIText;

    private void Update()
    {
        ViewMOAI();    
    }

    public void GainMOAI(float moai)
    {
        MOAI += moai;
    }

    public void ClickMOAI()
    {
        MOAI += ClickGainMOAI;
    }

    public void ViewMOAI()
    {
        MOAIText.text = MOAI.ToReadableString() + "モアイ";
    }

}
