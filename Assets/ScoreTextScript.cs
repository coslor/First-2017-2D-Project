using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour {
    public string scoreTemplate = "Score: {0}";

    private GameControlScript controller;
    Text guiTextObject;


	// Use this for initialization
	void Awake () {
        controller = GameObject.Find("GameController").GetComponent<GameControlScript>();
        guiTextObject =  GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        int currentScore = controller.gameScore;
        string finalString = string.Format(scoreTemplate, currentScore);
        guiTextObject.text = finalString;
	}
}
