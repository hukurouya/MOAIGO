using UnityEngine;

public interface IEncountEvent
{
    public EncountEventFactory.EncountKind encountKind { get; set; }
    public void Enter();
    public void Execute();
    public void Exit();
}
