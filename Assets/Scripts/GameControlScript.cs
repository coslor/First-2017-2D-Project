using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour {

    private int score;

    public int gameScore {
        get {
            return score;
        }
    }

    private int landings = 0;

    public int gameEnemiesLanded {
        get {
            return landings;
        }
    }

    public int enemyPointValue = 1;
    public int maxEnemyLandings = 4;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void enemyDied() {
        score += enemyPointValue;
    }

    public void enemyLanded() {
        if (++landings > maxEnemyLandings) {
            gameOver();
        }

    }

    private void gameOver() {

    }
}
