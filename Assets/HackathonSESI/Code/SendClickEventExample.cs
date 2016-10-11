using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SendClickEventExample : MonoBehaviour
{
    public Renderer Cube;

    public void DebugTest(string s)
    {
        Debug.Log(s);
        Cube.material.color = Random.ColorHSV();
    }

}
