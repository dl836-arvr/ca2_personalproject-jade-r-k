using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoKey : MonoBehaviour
{
    public static event Action<string> SendKeyValue = delegate { };

    public void KeyClicked()
    {
        SendKeyValue(name.Substring(0, name.IndexOf("_")));
    }
	
}
