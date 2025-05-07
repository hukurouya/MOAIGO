using UnityEngine;
using TMPro;
using System.Collections;


public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>
    /// �������
    /// </summary>
    public enum State
    {
        child = 1,
        adult = 2,
        parent = 3,

    }

    public State state; // ���

    public double MOAI; // ���A�C��
    public float ClickGainMOAI; // �N���b�N�œ������

    public float BeautifulPoint;    // �C�P�����x
    
    public float EncountTimer;


    private Animator _encAnim;      // �G���J�E���g�Ώۂ̃A�j���[�V����
    private bool _inGame;           // �Q�[���̃V�[���� true = �Q�[����(����ŃA�j���[�V���������ňꎞ�I�ɃQ�[�����~�߂�)
    
    [Header("�v�ݒ�")]
    public TextMeshProUGUI MOAIText;// ���A�C���\���p
    public Animator MOAIAnimator;   // ���A�C�̃A�j���[�V����
    public Animator MOAIGroupeAnimator; // ���A�C�����̃A�j���[�V����
    public GameObject EncPrefab;    // �G���J�E���g�p�̃v���n�u
    public GameObject ChildPrefab; // �q���̃v���n�u
    public GameObject MOAIGroupe;   // ���A�C�B�̐^�Ȃ�e

    private void Start()
    {
        
        _inGame = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickMOAI();
            // �Q�[�����Ȃ瓮��
            if (_inGame)
            {
                //RandomEncount();
                //StartCoroutine(GenerationalChange());

            }
        }
        //�@�\���̍X�V
        ViewMOAI();

    }

    /// <summary>
    /// �擾���A�C 
    /// </summary>
    /// <param name="moai">������</param>
    public void GainMOAI(float moai)
    {
        MOAI += moai;
    }

    /// <summary>
    /// ���A�C���N���b�N���ꂽ����
    /// </summary>
    public void ClickMOAI()
    {
        // �N���b�N���ɃA�j���[�V����
        MOAIGroupeAnimator.Play("MOAIGroupe_Click");
        
        // MOAI�̑���
        GainMOAI(ClickGainMOAI);

    
    }

    /// <summary>
    /// ���A�C�̃e�L�X�g�X�V
    /// </summary>
    public void ViewMOAI()
    {
        MOAIText.text = MOAI.ToReadableString() + "���A�C";
    }

    /// <summary>
    /// �o���
    /// </summary>
    public void RandomEncount()
    {
        float randomEnc = Random.Range(0,100); // �l�͓K��

        // �o���
        StartCoroutine(Meeting());
    }

    /// <summary>
    /// �o�����
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    public IEnumerator Meeting()
    {
        // �G���J�E���g�Ώۂ�����
        GameObject EncMOAI = Instantiate(EncPrefab);
        _encAnim = EncMOAI.GetComponent<Animator>();

        // �G���J�E���g�Ώۂ̃A�j���[�V�������J�n
        _encAnim.Play("EncMOAI_Move");
        
        yield return null;
        // �G���J�E���g�Ώۂ̃A�j���[�V�������Ԃ��擾
        var state = _encAnim.GetCurrentAnimatorStateInfo(0);
        // �A�j���[�V�����I���܂őҋ@
        yield return new WaitForSeconds(state.length);
       

        float randomLove = Random.Range(0, 100); // �l�͓K��
       
        // �e�ɂȂ�邩
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
    /// �e�ւ̈ȍ~(�A�j���[�V������t������)
    /// </summary>
    public IEnumerator LoveSuccess()
    {
        _encAnim.Play("EncMOAI_LoveSuccess");
        yield return null;
        // �G���J�E���g�Ώۂ̃A�j���[�V�������Ԃ��擾
        var state = _encAnim.GetCurrentAnimatorStateInfo(0);
        // �A�j���[�V�����I���܂őҋ@
        yield return new WaitForSeconds(state.length);
        Growth();
    }

    /// <summary>
    /// �ӂ�ꂽ(�A�j���[�V������t������)
    /// </summary>
    public IEnumerator LoveFailure()
    {

        _encAnim.Play("EncMOAI_LoveFailure");
        yield return null;
        // �G���J�E���g�Ώۂ̃A�j���[�V�������Ԃ��擾
        var state = _encAnim.GetCurrentAnimatorStateInfo(0);
        // �A�j���[�V�����I���܂őҋ@
        yield return new WaitForSeconds(state.length);
        
    }

    /// <summary>
    /// ���̒i�K�֐i��(�A�j���[�V������t������)
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
    /// ������
    /// </summary>
    public IEnumerator GenerationalChange()
    {
         GameObject childMOAI = Instantiate(ChildPrefab);
         _encAnim = childMOAI.GetComponent<Animator>();
         _encAnim.Play("EncMOAI_Move");
         yield return null;
         // �G���J�E���g�Ώۂ̃A�j���[�V�������Ԃ��擾
         var state = _encAnim.GetCurrentAnimatorStateInfo(0);
         // �A�j���[�V�����I���܂őҋ@
         yield return new WaitForSeconds(state.length);

         MOAIAnimator.Play("MOAI_GenerationalChange");
         yield return null;
         // �G���J�E���g�Ώۂ̃A�j���[�V�������Ԃ��擾
         state = MOAIAnimator.GetCurrentAnimatorStateInfo(0);
         // �A�j���[�V�����I���܂őҋ@
         yield return new WaitForSeconds(state.length);

         _encAnim.Play("EncMOAI_GenerationalChange");
       
        yield return null;
    }

}
