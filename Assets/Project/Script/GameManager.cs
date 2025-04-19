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
    public float EncChance;         // �G���J�E���g�m��

    private Animator _encAnim;      // �G���J�E���g�Ώۂ̃A�j���[�V����
    private bool _inGame;           // �Q�[���̃V�[���� true = �Q�[����(����ŃA�j���[�V���������ňꎞ�I�ɃQ�[�����~�߂�)
    
    [Header("�v�ݒ�")]
    public TextMeshProUGUI MOAIText;// ���A�C���\���p
    public Animator MOAIAnimator;   // ���A�C�̃A�j���[�V����
    public GameObject EncPrefab;    // �G���J�E���g�p�̃v���n�u

    private void Start()
    {
 
        _inGame = true;
    }

    private void Update()
    {
        // �Q�[�����Ȃ瓮��
        if (_inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickMOAI();
                RandomEncount(); // ��U�N���b�N���Ƀ����_���ɃG���J�E���g
            }

        }

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
        MOAIAnimator.Play("MOAIClick");
        
        // MOAI�̑���
        GainMOAI(ClickGainMOAI);

        //�@�\���̍X�V
        ViewMOAI();
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
        if (EncChance >= randomEnc)
        {
            StartCoroutine(Meeting());
        }
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
        Animator EncAnim = EncMOAI.GetComponent<Animator>();

        // �G���J�E���g�Ώۂ̃A�j���[�V�������J�n
        EncAnim.Play("EncMOAI_Move");
        _inGame = false;
        
        yield return null;
        // �G���J�E���g�Ώۂ̃A�j���[�V�������Ԃ��擾
        var state = EncAnim.GetCurrentAnimatorStateInfo(0);
        // �A�j���[�V�����I���܂őҋ@
        yield return new WaitForSeconds(state.length);
       
        _inGame = true;

        float randomLove = Random.Range(0, 100); // �l�͓K��
       
        // �e�ɂȂ�邩
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
    /// �e�ւ̈ȍ~(�A�j���[�V������t������)
    /// </summary>
    public void LoveSuccess()
    {
        Growth();
    }

    /// <summary>
    /// �ӂ�ꂽ(�A�j���[�V������t������)
    /// </summary>
    public void LoveFailure()
    {

    }

    /// <summary>
    /// ���̒i�K�֐i��(�A�j���[�V������t������)
    /// </summary>
    public void Growth()
    {
        state += 1;
    }

}
