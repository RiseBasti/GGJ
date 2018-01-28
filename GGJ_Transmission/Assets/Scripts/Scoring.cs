using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Zelle zelle;
    private Text Score;
    // Use this for initialization
    void Start () {
        Score = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        Score.text = "Score: " +zelle.score.ToString();
    }
}
