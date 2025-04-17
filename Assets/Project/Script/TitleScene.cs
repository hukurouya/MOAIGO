using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(FadeManager.IsPlay) return;

            FadeManager.Begin();
            FadeManager.FadeImage(GetComponent<Image>(), 1, 1, () => { 
                SceneManager.LoadScene("GameScene");
                FadeManager.FadeImage(GetComponent<Image>(), 0, 1, () => { 
                    FadeManager.Finish(); 
                });
            });
        }
    }
}
