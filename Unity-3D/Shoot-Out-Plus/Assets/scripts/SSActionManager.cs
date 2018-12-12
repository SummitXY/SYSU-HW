﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ActionManager{
	void singleRunAction (GameObject gameObject, int speedLevel);
}

public class SSActionManager : MonoBehaviour
{
	private List<int> waitingDelete = new List<int>();
	private List<SSAction> waitingAdd = new List<SSAction>();
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();
    
    
    void Start() {

    }


    
    protected void Update() {
        foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        foreach (KeyValuePair<int, SSAction> kv in actions) {
            SSAction ac = kv.Value;
            if (ac.destroy)
                waitingDelete.Add(ac.GetInstanceID());
            else if (ac.enable)
                ac.Update();
        }

		foreach (int key in waitingDelete) {
			SSAction ac = actions [key];
			actions.Remove (key);
			DestroyObject (ac);
		}
        waitingDelete.Clear();
    }


	protected void FixedUpdate() {
		foreach (SSAction ac in waitingAdd) actions[ac.GetInstanceID()] = ac;
		waitingAdd.Clear();

		foreach (KeyValuePair<int, SSAction> kv in actions) {
			SSAction ac = kv.Value;
			if (ac.destroy)
				waitingDelete.Add(ac.GetInstanceID());
			else if (ac.enable)
				ac.FixedUpdate();
		}

		foreach (int key in waitingDelete) {
			SSAction ac = actions [key];
			actions.Remove (key);
			DestroyObject (ac);
		}
		waitingDelete.Clear();
	}

	public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager) {
		action.gameobject = gameobject;
		action.transform = gameobject.transform;
		action.callback = manager;
		waitingAdd.Add(action);
		action.Start();
	}
    
}