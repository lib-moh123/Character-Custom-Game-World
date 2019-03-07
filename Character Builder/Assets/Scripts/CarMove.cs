using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {

	public float Speed;

	void Start () {
		transform.position = new Vector3 (0, 1f, 0);
		transform.eulerAngles = new Vector3 (0, 0, 0);
		foreach (WheelCollider G in GetComponentsInChildren<WheelCollider>()) {
			G.enabled = true;
		}
		GetComponent <Rigidbody>().useGravity = true;
	}
	
	void Update () {
		foreach (WheelCollider Wheel in GetComponentsInChildren<WheelCollider>()) {
			Wheel.radius += Mathf.Sin (Time.time * 3) * Time.deltaTime * 0.25f;
			Wheel.motorTorque = Input.GetAxisRaw("Vertical") * Speed;
			/*if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0) {
				Wheel.brakeTorque = 5;
			} else {
				Wheel.brakeTorque = 0;
			}*/
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			transform.RotateAround(transform.position, transform.up * Input.GetAxisRaw("Horizontal"), Time.deltaTime * 75);
			//GetComponent<Rigidbody>().AddRelativeTorque (transform.up * Input.GetAxisRaw("Horizontal") * Time.deltaTime * 75);
		}
	}
}