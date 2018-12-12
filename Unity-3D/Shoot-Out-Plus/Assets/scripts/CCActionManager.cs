using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ActionManager, ISSActionCallback {

	public UFOFactory diskFactory;

	void Start() {
		diskFactory = UFOFactory.getInstance();
	}

	public new void Update() {
		base.Update ();
	}

	public new void FixedUpdate() {
		
	}

	public void singleRunAction(GameObject gameObject, int speedLevel) {
		this.RunAction (gameObject, UFOAction.GetSSAction (speedLevel), this);
	}


	public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
		int intParam = 0, string strParam = null, Object objectParam = null){

	}

}