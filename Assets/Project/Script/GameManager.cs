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
    
    public float EncountTimer;


    private Animator _encAnim;      // エンカウント対象のアニメーション
    private bool _inGame;           // ゲームのシーンか true = ゲーム中(これでアニメーション中等で一時的にゲームを止める)
    
    [Header("要設定")]
    public TextMeshProUGUI MOAIText;// モアイ数表示用
    public Animator MOAIAnimator;   // モアイのアニメーション
    public Animator MOAIGroupeAnimator; // モアイたちのアニメーション
    public GameObject EncPrefab;    // エンカウント用のプレハブ
    public GameObject ChildPrefab; // 子供のプレハブ
    public GameObject MOAIGroupe;   // モアイ達の真なる親

    private void Start()
    {
        
        _inGame = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickMOAI();
            // ゲーム中なら動く
            if (_inGame)
            {
                //RandomEncount();
                //StartCoroutine(GenerationalChange());

            }
        }
        //　表示の更新
        ViewMOAI();

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
        MOAIGroupeAnimator.Play("MOAIGroupe_Click");
        
        // MOAIの増加
        GainMOAI(ClickGainMOAI);

    
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
        StartCoroutine(Meeting());
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
        _encAnim = EncMOAI.GetComponent<Animator>();

        // エンカウント対象のアニメーションを開始
        _encAnim.Play("EncMOAI_Move");
        
        yield return null;
        // エンカウント対象のアニメーション時間を取得
        var state = _encAnim.GetCurrentAnimatorStateInfo(0);
        // アニメーション終了まで待機
        yield return new WaitForSeconds(state.length);
       

        float randomLove = Random.Range(0, 100); // 値は適当
       
        // 親になれるか
        if (BeautifulPoint > randomLove)
        {
            StartCoroutine(LoveSuccess());
        }
        else
        {
            StartCoroutine(LoveFailure());
        }

    }

    /// <summary>
    /// 親への以降(アニメーションを付けたい)
    /// </summary>
    public IEnumerator LoveSuccess()
    {
        _encAnim.Play("EncMOAI_LoveSuccess");
        yield return null;
        // エンカウント対象のアニメーション時間を取得
        var state = _encAnim.GetCurrentAnimatorStateInfo(0);
        // アニメーション終了まで待機
        yield return new WaitForSeconds(state.length);
        Growth();
    }

    /// <summary>
    /// ふられた(アニメーションを付けたい)
    /// </summary>
    public IEnumerator LoveFailure()
    {

        _encAnim.Play("EncMOAI_LoveFailure");
        yield return null;
        // エンカウント対象のアニメーション時間を取得
        var state = _encAnim.GetCurrentAnimatorStateInfo(0);
        // アニメーション終了まで待機
        yield return new WaitForSeconds(state.length);
        
    }

    /// <summary>
    /// 次の段階へ進む(アニメーションを付けたい)
    /// </summary>
    public void Growth()
    {
        if (state == State.parent)
        {
            StartCoroutine(GenerationalChange());
            return;
        }    
        state += 1;
        
    }

    /// <summary>
    /// 世代交代
    /// </summary>
    public IEnumerator GenerationalChange()
    {
         GameObject childMOAI = Instantiate(ChildPrefab);
         _encAnim = childMOAI.GetComponent<Animator>();
         _encAnim.Play("EncMOAI_Move");
         yield return null;
         // エンカウント対象のアニメーション時間を取得
         var state = _encAnim.GetCurrentAnimatorStateInfo(0);
         // アニメーション終了まで待機
         yield return new WaitForSeconds(state.length);

         MOAIAnimator.Play("MOAI_GenerationalChange");
         yield return null;
         // エンカウント対象のアニメーション時間を取得
         state = MOAIAnimator.GetCurrentAnimatorStateInfo(0);
         // アニメーション終了まで待機
         yield return new WaitForSeconds(state.length);

         _encAnim.Play("EncMOAI_GenerationalChange");
       
        yield return null;
    }

}
