using UnityEngine;
using System.Collections;

public class Tr : MonoBehaviour {

	// Use this for initialization
	float time = 2.0f;
	float timeCounter = 0.0f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if (timeCounter > time){
			Debug.Log("Change Scene");
			Application.LoadLevel("Main");
		}
	}
}
