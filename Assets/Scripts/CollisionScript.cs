using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

    public Sprite brokenSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision enter");
        gameObject.GetComponent<SpriteRenderer>().sprite = brokenSprite;
        gameObject.GetComponent<Rigidbody2D>().drag = 0;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        //Debug.Log("Collision Exit");

    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Trigger!");
    }
}
