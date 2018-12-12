using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {
	public GameObject camera0;
	public GameObject camera1;
	public GameObject camera2;
	public GameObject camera4;
	private void CloseCameras(){
		camera0.SetActive (false);
		camera1.SetActive (false);
		camera2.SetActive (false);
		camera4.SetActive (false);

	}
	// Use this for initialization
	void Start () {
		CloseCameras ();
		camera0.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()  
	{  
		if (GUI.Button(new Rect(0,0,50,50),"All 1"))  
		{  
			camera0.SetActive(true);  
			camera1.SetActive(false);  
			camera2.SetActive(false); 
			camera4.SetActive(false);
		}  
		if (GUI.Button(new Rect(0, 60, 50, 50), "All2"))  
		{  
			camera0.SetActive(false);  
			camera1.SetActive(false);  
			camera2.SetActive(false); 
			camera4.SetActive(true); 
		}  
		if (GUI.Button(new Rect(0, 120, 50, 50), "Earth"))  
		{  
			camera0.SetActive(false);  
			camera1.SetActive(true);  
			camera2.SetActive(false); 
			camera4.SetActive(false);  
		}  
		if (GUI.Button(new Rect(0, 180, 50, 50), "Moon"))  
		{  
			camera0.SetActive(false);  
			camera1.SetActive(false);  
			camera2.SetActive(true); 
			camera4.SetActive(false); 
		}  
	}  
}
