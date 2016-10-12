using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActiveEventAfterAim : MonoBehaviour
{

    public float TimeToTrigger = 2;
    private bool _looking = false;
    private bool _canFire = true;
    private float _currentTime = 0;
    private EventTrigger _eventTrigger;

    public AimEvent OnAim;
    public AimEvent OnUnAim;
    public AimTriggerEvent OnTriggerAim;

    protected void Awake()
    {
        _eventTrigger = GetComponent<EventTrigger>();
        if (!_eventTrigger)
        {
            _eventTrigger = gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry onPointerEnter = new EventTrigger.Entry();
            onPointerEnter.eventID = EventTriggerType.PointerEnter;
            onPointerEnter.callback.AddListener(OnLookObject);
            _eventTrigger.triggers.Add(onPointerEnter);

            EventTrigger.Entry onPointerExit = new EventTrigger.Entry();
            onPointerExit.eventID = EventTriggerType.PointerExit;
            onPointerExit.callback.AddListener(OnUnLookObject);
            _eventTrigger.triggers.Add(onPointerExit);
        }
    }

    public void Update()
    {
        if (!_looking)
            return;
        _currentTime += Time.deltaTime;
        if (_currentTime >= TimeToTrigger)
        {
            InternalTriggerLook();
        }
    }

    private void InternalTriggerLook()
    {
        if (!_canFire)
            return;
        _canFire = false;
        _currentTime = 0;
        OnTriggerAim.Invoke(this.gameObject);
    }

    private void OnLookObject(BaseEventData e)
    {
        _looking = true;
        OnAim.Invoke(e);
    }

    private void OnUnLookObject(BaseEventData e)
    {
        _looking = false;
        _canFire = true;
        _currentTime = 0;
        OnUnAim.Invoke(e);
    }

    [System.Serializable]
    public class AimEvent : UnityEvent<BaseEventData>
    {

    }

    [System.Serializable]
    public class AimTriggerEvent : UnityEvent<GameObject>
    {

    }

}
