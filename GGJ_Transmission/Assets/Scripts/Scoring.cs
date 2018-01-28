using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
   // private GameObject ZelleO;
    private Zelle zelle;
    private Text Score;
    public int FinalScore;
    // Use this for initialization
    void Start () {
        Score = GetComponent<Text>();
        zelle = GameObject.FindGameObjectWithTag("Zelle").GetComponent<Zelle>();
       
    }

    // Update is called once per frame
    void Update() {

        
        Score.text = "Score: " + zelle.score.ToString();
      
        }
    
}
