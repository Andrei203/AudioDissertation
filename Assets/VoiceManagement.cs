using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceManagement : MonoBehaviour
{
    private KeywordRecognizer KeywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("Forward", Forward);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("back", Back);

        KeywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        KeywordRecognizer.OnPhraseRecognized += voiceRecognised;
        KeywordRecognizer.Start();
    }

    private void voiceRecognised(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward()
    {
        transform.Translate(0, 0, 1);
        
    }
    private void Up()
    {
        transform.Translate(0, 1, 0);
        
    }
    private void Down()
    {
        transform.Translate(0, -1, 0);
        
    } 
    private void Back()
    {
        transform.Translate(-1, 0, 0);
        
    }
}
