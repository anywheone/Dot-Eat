using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpead = 5f;
	public float rotationspeed = 360f;

	CharacterController characterController;
	Animator animator;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		animator = GetComponentInChildren<Animator> ();

		bool key = false;
		if(Input.GetKeyDown(KeyCode.UpArrow)) key = true;
		if(Input.GetKeyDown(KeyCode.DownArrow)) key = true;
		if(Input.GetKeyDown(KeyCode.RightArrow)) key = true;
		if(Input.GetKeyDown(KeyCode.LeftArrow)) key = true;
		if(key = true){
			animator.SetTrigger("transration");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),0,
			Input.GetAxis("Vertical"));
			if (direction.sqrMagnitude > 0.01f) {
				Vector3 forward = Vector3.Slerp(
					transform.forward,
					direction,
					rotationspeed * Time.deltaTime / Vector3.Angle
					(transform.forward, direction)
				);
				transform.LookAt(transform.position + forward);
			}
			characterController.Move(direction * moveSpead * Time.deltaTime);
			
		animator.SetFloat ("Speed", characterController.velocity.magnitude);

		float Length;

		if (GameObject.FindGameObjectsWithTag ("Dot").Length == 0) {
			Application.LoadLevel ("Win");
		}
	}
	//
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Dot") {
			Destroy (other.gameObject);
		}
		if (other.tag == "Enemy"){
			Application.LoadLevel ("Lose");
		}
	}
}
