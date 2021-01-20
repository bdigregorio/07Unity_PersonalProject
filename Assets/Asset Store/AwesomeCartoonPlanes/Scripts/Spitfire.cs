using UnityEngine;
using System.Collections;

// PLEASE NOTE! THIS SCRIPT IS FOR DEMO PURPOSES ONLY :) //

public class Spitfire : MonoBehaviour {
	public GameObject prop;
	public GameObject propBlured;
	public GameObject LeftWheel;
	public GameObject RightWheel;

	public bool engenOn;
	public bool wheelsUp;

	void Update () 
	{
		if (engenOn) {
			prop.SetActive (false);
			propBlured.SetActive (true);
			propBlured.transform.Rotate (0, -1000 * Time.deltaTime, 0);
		} else {
			prop.SetActive (true);
			propBlured.SetActive (false);
		}
	}
}

// PLEASE NOTE! THIS SCRIPT IS FOR DEMO PURPOSES ONLY :) //