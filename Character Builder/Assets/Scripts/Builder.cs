using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

	int TypePick;
	public GameObject[] Body;
	public GameObject[] Hat;
	public GameObject[] Nose;
	public GameObject[] Wing;
	public GameObject[] Engine;
	int[] Parts = {0, 0, 0, 0, 0};
	int PartLength;

	int PartShow;

	void Start () {
		TypePick = 0;
		PartLength = Body.Length;
		PartShow = 0;
	}
	

	void Update () {
		foreach (GameObject G in GameObject.FindGameObjectsWithTag("Body")) {
			if (G.name == "Body (" + Parts[0] + ")") {
				G.transform.position = transform.position;
				G.transform.rotation = transform.rotation;
			} else {
				G.transform.position = new Vector3 (0, -100, 0);
			}
		}
		foreach (GameObject G in GameObject.FindGameObjectsWithTag("Hat")) {
			if (G.name == "Hat (" + Parts[1] + ")") {
				G.transform.position = GameObject.Find("Body (" + Parts[0] + ")/HatPos").transform.position;
				G.transform.rotation = GameObject.Find("Body (" + Parts[0] + ")/HatPos").transform.rotation;
			} else {
				G.transform.position = new Vector3 (0, -100, 0);
			}
		}
		foreach (GameObject G in GameObject.FindGameObjectsWithTag("Nose")) {
			if (G.name == "Nose (" + Parts[2] + ")") {
				G.transform.position = GameObject.Find("Body (" + Parts[0] + ")/NosePos").transform.position;
				G.transform.rotation = GameObject.Find("Body (" + Parts[0] + ")/NosePos").transform.rotation;
			} else {
				G.transform.position = new Vector3 (0, -100, 0);
			}
		}
		foreach (GameObject G in GameObject.FindGameObjectsWithTag("Wing")) {
			if (G.name == "Wing (" + Parts[3] + ")") {
				G.transform.position = GameObject.Find("Body (" + Parts[0] + ")").transform.position;
				G.transform.rotation = GameObject.Find("Body (" + Parts[0] + ")").transform.rotation;
			} else {
				G.transform.position = new Vector3 (0, -100, 0);
			}
		}
		foreach (GameObject G in GameObject.FindGameObjectsWithTag("Engine")) {
			if (G.name == "Engine (" + Parts[4] + ")") {
				G.transform.position = GameObject.Find("Body (" + Parts[0] + ")").transform.position;
				G.transform.rotation = GameObject.Find("Body (" + Parts[0] + ")").transform.rotation;
			} else {
				G.transform.position = new Vector3 (0, -100, 0);
			}
		}
	
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * 50);
		transform.position += transform.up * Mathf.Sin (Time.time * 3) * 0.02f;
	}
	public void BodyBtn() {
		TypePick = 0;
		PartLength = Body.Length;
	}
	public void HatBtn() {
		TypePick = 1;
		PartLength = Hat.Length;
	}
	public void NoseBtn() {
		TypePick = 2;
		PartLength = Nose.Length;
	}
	public void WingBtn() {
		TypePick = 3;
		PartLength = Wing.Length;
	}
	public void EngineBtn() {
		TypePick = 4;
		PartLength = Engine.Length;
	}
	public void Right() {
		PartShow++;
		if (PartShow + 1 > PartLength) {
			PartShow -= PartLength;
		}
		Parts[TypePick] = PartShow;
	}
	public void Left() {
		PartShow--;
		if (PartShow < 0) {
			PartShow = PartLength - 1;
		}
		Parts[TypePick] = PartShow;
	}

	public void StartBtn() {

	}
}