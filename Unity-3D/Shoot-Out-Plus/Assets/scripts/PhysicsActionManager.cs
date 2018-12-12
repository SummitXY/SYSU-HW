using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsActionManager : SSActionManager, ActionManager, ISSActionCallback {

	public UFOFactory diskFactory;

	void Start() {
		diskFactory = UFOFactory.getInstance();
	}

	public new void Update() {

	}

	public new void FixedUpdate() {
		base.FixedUpdate ();
	}



	public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
		int intParam = 0, string strParam = null, Object objectParam = null){

	}

	public void singleRunAction (GameObject gameObject, int speedLevel) {
		this.RunAction (gameObject, UFOAction.GetSSAction (speedLevel), this);
	}


}