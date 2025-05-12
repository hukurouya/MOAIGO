using UnityEditor.Rendering;
using UnityEngine;

public class EncountEventManager : MonoBehaviour
{
    public BaseEncountEvent currentEvent;

    private float _encountDelay;
    private float _encountTime;

    private void Start()
    {
        currentEvent = EncountEventFactory.Create(EncountEventFactory.EncountKind.Growup) as BaseEncountEvent;
    }

    private void Update()
    {
        _encountDelay += Time.deltaTime;
        if(_encountDelay >= _encountTime)
        {
            if(currentEvent == null)
                
            
            _encountDelay = 0;
        }

        if(currentEvent != null)
            if(currentEvent.update != null)
                currentEvent.update();
    }
}
