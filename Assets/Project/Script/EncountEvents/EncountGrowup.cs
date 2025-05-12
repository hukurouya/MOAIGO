using DG.Tweening;
using UnityEngine;

public class EncountGrowup : BaseEncountEvent
{
    public GameObject moai;

    public EncountGrowup()
    {
        encountKind = EncountEventFactory.EncountKind.Growup;
        update = new EventDelegate(Enter);

        GameObject prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Project/Prefabs/MOAI/encountMOAI.prefab");
        Debug.Log(prefab);
        moai = GameObject.Instantiate(prefab);

        Debug.Log("start");
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("enter");
        update = Execute;

        Sequence sequence = DOTween.Sequence().OnStart(() =>
            {
                moai.transform.DOMoveX(0, 1, false);
            })
            .JoinCallback( () =>
            {
                if(Random.Range(0, 100) > 10)
                {
                    Debug.Log("Event Success");
                }
                else
                {
                    Debug.Log("Event Failuer");
                }
            })
            .AppendCallback(() =>
            {
                
            })
            .AppendCallback(() => 
            {
                update = Exit;
            });

        sequence.Play();
    }

    public override void Execute()
    {
        

        base.Execute();
    }

    public override void Exit()
    {
        Debug.Log("hoge");
        moai.transform.DOMoveX(-10, 1, false);
        update = null;

        base.Exit();
    }
}
