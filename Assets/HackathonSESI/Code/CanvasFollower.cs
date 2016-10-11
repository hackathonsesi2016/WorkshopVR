using UnityEngine;
using System.Collections;

public class CanvasFollower : MonoBehaviour
{
    [SerializeField]
    protected Transform _target;

    private Vector3 _offSet;


    protected void Awake()
    {
        if (_target == null)
            return;
        _offSet = this.transform.position - _target.position;
    }

    protected void LateUpdate()
    {
        if (_target == null)
            return;
        this.transform.position = _target.position + _offSet;
    }

}
