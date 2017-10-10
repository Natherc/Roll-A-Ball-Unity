using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public Text countText;
	public Text winText;
	public float speed;
	private int count;

	void Start(){
		//Si ce script est relié à un objet rigide alors celui-ci sera obtenu dans la variable
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);


		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("PickUp")){
			
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count :" + count.ToString ();
		if (count >= 10) {
			winText.text = "You WIN";
		}
	}
}
