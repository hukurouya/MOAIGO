using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public double MOAI; // ���A�C��

    public float ClickGainMOAI; // �N���b�N�œ������

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
        MOAIText.text = MOAI.ToReadableString() + "���A�C";
    }

}
