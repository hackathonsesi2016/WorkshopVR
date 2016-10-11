using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyCodeCheck : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _text.text = "";
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            Debug.Log("Detected key code: " + e.keyCode);
            _text.text = "Detected key code: " + e.keyCode;
        }

    }
}
