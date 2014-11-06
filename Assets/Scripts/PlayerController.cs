using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float moveHorizontal, moveVertical;
	private Vector3 movement;
	private int count;

	public  GameObject pickup;
	public int speed;
	public GUIText countText;
	public GUIText winText;
	
	void Start () {
		count = 0;
		displayCountText ();
	}

	void FixedUpdate () {

		applyMovement ();
	}

	void applyMovement () {

		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		
		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count++;
			displayCountText ();
		}
	}

	void displayCountText () {
		countText.text = "Count: " + count.ToString();
		winText.text = "";

		if (count == 8) {
			winText.text = "YOU WIN!";
		} 
	}
}
//