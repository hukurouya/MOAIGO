using UnityEngine;

/// <summary>
/// �G���J�E���g�C�x���g�̊��N���X
/// </summary>
public abstract class BaseEncountEvent : IEncountEvent
{
    /// <summary>
    /// [�v���p�e�B]�G���J�E���g�p�^�[��
    /// </summary>
    public EncountEventFactory.EncountKind encountKind { get; set; }

    public delegate void EventDelegate();
    public EventDelegate update { get; set; }

    /// <summary>
    /// �J�n
    /// </summary>
    public virtual void Enter()
    {
        
    }

    /// <summary>
    /// �X�V
    /// </summary>
    public virtual void Execute()
    {
        
    }

    /// <summary>
    /// �I��
    /// </summary>
    public virtual void Exit()
    {
        
    }
}
