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
    private DoorBehaviour door;
    private ChestBehaviour chest;
    private Rigidbody pushable;
    void Start()
    {
        actions.Add("Forward", Forward);
        actions.Add("up", Up);
        actions.Add("left", Left);
        actions.Add("right", Right);
        actions.Add("down", Down);
        actions.Add("back", Back);
        actions.Add("open", Open);
        actions.Add("close", Close);
        actions.Add("hit", Hit);
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
    private void Left()
    {
        transform.Translate(-1, 0, 0);
    } 
    private void Right()
    {
        transform.Translate(1, 0, 0);
    }
    private void Down()
    {
        transform.Translate(0, -1, 0);
        
    } 
    private void Back()
    {
        transform.Translate(0, 0, -1);
        
    }
    private void Open()
    {
        if (door == null) return;
        door.OpenDoor();
    }
    private void Close()
    {
        if (door == null) return;
        door.CloseDoor();
    }


    private void Hit()
    {
        if (pushable == null) return;
        pushable.AddForce(new Vector3(1000.0f, 0.0f), ForceMode.Impulse); 
    }


    private void OnTriggerEnter(Collider other)
    {
        door = other.GetComponent<DoorBehaviour>();
        if(other.CompareTag("Pushable"))
        {
            pushable = other.transform.parent.GetComponent<Rigidbody>();

        }

        chest = other.GetComponent<ChestBehaviour>();
    }
}
