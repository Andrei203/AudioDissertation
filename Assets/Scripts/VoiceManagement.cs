using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;

public class VoiceManagement : MonoBehaviour
{
    [Serializable]
    public struct Keyword
    {
        public string phrase;
        public UnityEvent function;
    }

    public Keyword[] Keywords = new Keyword[0];
    private KeywordRecognizer KeywordRecognizer;
    //private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private Dictionary<string, UnityEvent> events = new Dictionary<string, UnityEvent>();
    private DoorBehaviour door;
    private ChestBehaviour chest;
    private Rigidbody pushable;
    public NPCBehaviour npc;
    //im trying to make a reference to the enemy script 
    void Start()
    {
        string[] phrases = new string[Keywords.Length];
        int i = 0;
        foreach (Keyword keyword in Keywords)
        {
            phrases[i++] = keyword.phrase;
            events.Add(keyword.phrase,keyword.function);
        }

        KeywordRecognizer = new KeywordRecognizer(phrases);
        KeywordRecognizer.OnPhraseRecognized += voiceRecognised;
        KeywordRecognizer.Start();
        /*
        actions.Add("Forward", Forward);
        actions.Add("up", Up);
        actions.Add("left", Left);
        actions.Add("right", Right);
        actions.Add("down", Down);
        actions.Add("back", Back);
        actions.Add("open", Open);
        actions.Add("close", Close);
        actions.Add("hit", Hit);
        actions.Add("ChestOpen", OpenChest);
        actions.Add("ChestClose", CloseChest);
        KeywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        KeywordRecognizer.OnPhraseRecognized += voiceRecognised;
        KeywordRecognizer.Start();*/
    }

    private void voiceRecognised(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        events[speech.text].Invoke();
        //actions[speech.text].Invoke();
    }

    public void Forward()
    {
        transform.Translate(0, 0, 1.25f);
        
    }
    public void Up()
    {
        transform.Translate(0, 1, 0);
        
    }
    public void Left()
    {
        transform.Translate(-1.25f, 0, 0);
    }

    public void rotateLeft()
    {
        transform.Rotate(0,-90,0);
    }   
    public void rotateRight()
    {
        transform.Rotate(0.0f,90,0);
    }
    
    public void Dodge()
    {
        transform.Translate(0, 0, -2.00f);
    }
    public void Right()
    {
        transform.Translate(1.25f, 0, 0);
    }
    public void Down()
    {
        transform.Translate(0, -1, 0);
        
    } 
    public void Back()
    {
        transform.Translate(0, 0, -1.25f);
        
    }
    
    
    public void Open()
    {
        if (door == null) return;
        door.OpenDoor();
    }
    public void Close()
    {
        if (door == null) return;
        door.CloseDoor();
    }
    public void OpenChest()
    {
        if (chest == null) return;
        chest.ChestOpen();
    }
    public void CloseChest()
    {
        if (chest == null) return;
        chest.ChestClosed();
    }

    public void Push()
    {
        if (pushable == null) return;
        pushable.AddForce(new Vector3(300.0f, 0.0f), ForceMode.Impulse);
    }
    public void Hit()
    {
        //if (pushable == null) return;
       // pushable.AddForce(new Vector3(5.0f, 0.0f), ForceMode.Impulse);
       
        npc.enemyHealth -= npc.takeDamage; 
        Debug.Log(npc.enemyHealth);
       if (npc.enemyHealth <= 0)
       {
            
            Destroy(npc.gameObject); 
       }
    }

    public void HeavyHit()
    {
        npc.enemyHealth -= npc.heavyDamage;
        Debug.Log(npc.enemyHealth);
        if (npc.enemyHealth <= 0)
        {
            Destroy(npc.gameObject);
        }
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
