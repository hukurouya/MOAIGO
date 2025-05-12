using UnityEngine;

/// <summary>
/// エンカウントイベントの基底クラス
/// </summary>
public abstract class BaseEncountEvent : IEncountEvent
{
    /// <summary>
    /// [プロパティ]エンカウントパターン
    /// </summary>
    public EncountEventFactory.EncountKind encountKind { get; set; }

    public delegate void EventDelegate();
    public EventDelegate update { get; set; }

    /// <summary>
    /// 開始
    /// </summary>
    public virtual void Enter()
    {
        
    }

    /// <summary>
    /// 更新
    /// </summary>
    public virtual void Execute()
    {
        
    }

    /// <summary>
    /// 終了
    /// </summary>
    public virtual void Exit()
    {
        
    }
}
