using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFactory : System.Object {
	
    private static UFOFactory _instance;
    public GameController sceneControler { get; set; }
    public List<GameObject> used;
    public List<GameObject> free;

    public static UFOFactory getInstance(){
        if (_instance == null) {
            _instance = new UFOFactory();
            _instance.used = new List<GameObject>();
            _instance.free = new List<GameObject>();
        }
        return _instance;
    }

    public GameObject getDisk(ActionMode mode) {

        GameObject newDisk;
        if (free.Count == 0)
            newDisk = GameObject.Instantiate(Resources.Load("prefabs/Disk")) as GameObject;
        else {
            newDisk = free[0];
            free.Remove(free[0]);
        }
		newDisk.SetActive(true);
        used.Add(newDisk);
		if (mode == ActionMode.PHYSIC && !newDisk.GetComponent<Rigidbody> ()) {
			newDisk.AddComponent<Rigidbody> ();  
		}
        return newDisk;
    }

	public void hideAll() {
		for (int i = 0; i < used.Count; i++)
			used [i].SetActive (false);
		for (int i = 0; i < free.Count; i++)
			free [i].SetActive (false);
	}

    public void freeDisk(GameObject g) {
        for (int i = 0; i < used.Count; i++) {
            if (used[i] == g) {
                used.Remove(g);
                g.SetActive(false);
                free.Add(g);
            }
        }
    }


}