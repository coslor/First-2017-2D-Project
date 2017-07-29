using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

    private static Vector2 BOTTOM_MIDDLE = new Vector2(0f, -10f);

    public GameObject bulletPrefab;
    public int bulletVelocity = 1;

    public float speed = 2f;

    public GameObject paratrooperPrefab;

	// Use this for initialization
	void Start () {
        dropParatrooperWaitRepeat();

    }
	
    private void dropParatrooperWaitRepeat() {
        Debug.Log("Dropping paratrooper");

        GameObject paratrooper = Instantiate(paratrooperPrefab);
        paratrooper.transform.position = new Vector2(Random.Range(-10f, 10f), 6f);
        Invoke("dropParatrooperWaitRepeat", Random.Range(0f, 1 / speed));
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            fireBullet();
        }

    }

    private void fireBullet() {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.LogFormat("Clicked on world coordinate ({0},{1})", worldPoint.x, worldPoint.y);
        Vector3 heading = worldPoint - BOTTOM_MIDDLE;
        float distance = heading.magnitude;
        Vector2 direction = heading / distance;
        float directionInDegrees = Vector2.Angle(BOTTOM_MIDDLE, worldPoint);
        float degreesFromBottomLeft = Mathf.Atan2(worldPoint.y - BOTTOM_MIDDLE.y, BOTTOM_MIDDLE.x - worldPoint.x) * Mathf.Rad2Deg;
        //Debug.LogFormat("direction={0} degrees={1}", direction, direction.x*90);

        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.position = new Vector3(BOTTOM_MIDDLE.x, BOTTOM_MIDDLE.y, 0f);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(direction.x * bulletVelocity, direction.y * bulletVelocity, 0f);
        //Debug.Log("Bullet away!");
    }

    private void OnCollisionExit2D(Collision2D collision) {
        Debug.Log("Leaving collision with " + collision);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision enter");
    }

    private void OnCollisionExit2D(Collision collision) {
        Debug.Log("Collision 3d exit");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger!");
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Exit trigger - destroying wandering object");

        GameObject doomedObject = collision.gameObject;
        if (doomedObject.CompareTag("BulletCollider")) {
            Debug.Log("Found a bullet collider--finding bullet");
            doomedObject = doomedObject.transform.parent.gameObject;
        }
        GameObject.Destroy(doomedObject);
    }


}
