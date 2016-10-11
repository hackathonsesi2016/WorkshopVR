using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActiveEventAfterLook : MonoBehaviour
{
    [SerializeField]
    protected float _activeDelay = 2;

    private bool _looking = false;
    private bool _canFire = true;
    private float _currentTime = 0;
    private EventTrigger _eventTrigger;

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
        if (_currentTime >= _activeDelay)
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
        OnTriggerLook();
    }

    public virtual void OnTriggerLook()
    {
        Debug.Log("Active Object with Look. " + gameObject.name);
    }

    public void OnLookObject(BaseEventData e)
    {
        //Debug.Log("Look object: " + gameObject.name);
        _looking = true;
    }

    public void OnUnLookObject(BaseEventData e)
    {
        //Debug.Log("UnLook object: " + gameObject.name);
        _looking = false;
        _canFire = true;
        _currentTime = 0;
    }


}
