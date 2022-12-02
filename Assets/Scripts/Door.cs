using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private string correctSequence, currentSequence;
    public AudioSource Right;
    public AudioSource Wrong;

    // Start is called before the first frame update
    void Start()
    {
        PianoKey.SendKeyValue += AddValueAndCheckSequence;
        correctSequence = "3764152";
        currentSequence = "";
    }

    private void AddValueAndCheckSequence(string pianoKey)
    {
        switch(pianoKey)
        {
            case "c":
                currentSequence += 1;
                break;
            case "d":
                currentSequence += 2;
                break;
            case "e":
                currentSequence += 3;
                break;
            case "f":
                currentSequence += 4;
                break;
            case "g":
                currentSequence += 5;
                break;
            case "a":
                currentSequence += 6;
                break;
            case "b":
                currentSequence += 7;
                break;
        }

        if (currentSequence != correctSequence.Substring(0, currentSequence.Length))
        {
            Wrong.Play();
            currentSequence = "";
        }
        else if (currentSequence == correctSequence)
        {
            Right.Play();
            currentSequence = "";
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        PianoKey.SendKeyValue -= AddValueAndCheckSequence;
    }
}
