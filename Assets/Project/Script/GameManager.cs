using UnityEngine;
using TMPro;
using System.Collections;


public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>
    /// 成長状態
    /// </summary>
    public enum State
    {
        child = 1,
        adult = 2,
        parent = 3,

    }

    public State state; // 状態

    public double MOAI; // モアイ数
    public float ClickGainMOAI; // クリックで得られる量

    public float BeautifulPoint;    // イケメン度
    public float EncChance;         // エンカウント確率

    private Animator _encAnim;      // エンカウント対象のアニメーション
    private bool _inGame;           // ゲームのシーンか true = ゲーム中(これでアニメーション中等で一時的にゲームを止める)
    
    [Header("要設定")]
    public TextMeshProUGUI MOAIText;// モアイ数表示用
    public Animator MOAIAnimator;   // モアイのアニメーション
    public GameObject EncPrefab;    // エンカウント用のプレハブ

    private void Start()
    {
 
        _inGame = true;
    }

    private void Update()
    {
        // ゲーム中なら動く
        if (_inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickMOAI();
                RandomEncount(); // 一旦クリック時にランダムにエンカウント
            }

        }

    }

    /// <summary>
    /// 取得モアイ 
    /// </summary>
    /// <param name="moai">増加量</param>
    public void GainMOAI(float moai)
    {
        MOAI += moai;
    }

    /// <summary>
    /// モアイがクリックされた処理
    /// </summary>
    public void ClickMOAI()
    {
        // クリック時にアニメーション
        MOAIAnimator.Play("MOAIClick");
        
        // MOAIの増加
        GainMOAI(ClickGainMOAI);

        //　表示の更新
        ViewMOAI();
    }

    /// <summary>
    /// モアイのテキスト更新
    /// </summary>
    public void ViewMOAI()
    {
        MOAIText.text = MOAI.ToReadableString() + "モアイ";
    }

    /// <summary>
    /// 出会うか
    /// </summary>
    public void RandomEncount()
    {
        float randomEnc = Random.Range(0,100); // 値は適当

        // 出会うか
        if (EncChance >= randomEnc)
        {
            StartCoroutine(Meeting());
        }
    }

    /// <summary>
    /// 出会った
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    public IEnumerator Meeting()
    {
        // エンカウント対象を召喚
        GameObject EncMOAI = Instantiate(EncPrefab);
        Animator EncAnim = EncMOAI.GetComponent<Animator>();

        // エンカウント対象のアニメーションを開始
        EncAnim.Play("EncMOAI_Move");
        _inGame = false;
        
        yield return null;
        // エンカウント対象のアニメーション時間を取得
        var state = EncAnim.GetCurrentAnimatorStateInfo(0);
        // アニメーション終了まで待機
        yield return new WaitForSeconds(state.length);
       
        _inGame = true;

        float randomLove = Random.Range(0, 100); // 値は適当
       
        // 親になれるか
        if (BeautifulPoint > randomLove)
        {
            LoveSuccess();
        }
        else
        {
            LoveFailure();
        }

    }

    /// <summary>
    /// 親への以降(アニメーションを付けたい)
    /// </summary>
    public void LoveSuccess()
    {
        Growth();
    }

    /// <summary>
    /// ふられた(アニメーションを付けたい)
    /// </summary>
    public void LoveFailure()
    {

    }

    /// <summary>
    /// 次の段階へ進む(アニメーションを付けたい)
    /// </summary>
    public void Growth()
    {
        state += 1;
    }

}
