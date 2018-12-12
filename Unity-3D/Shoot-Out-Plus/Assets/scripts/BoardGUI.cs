using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IUserAction{
	ActionMode GetMode();
	void SwitchMode();
	void StartGame();
	void ReStart();

}

public class BoardGUI : MonoBehaviour{

	private IUserAction action;

	void Start() {
		action = SSDirector.getInstance ().currentScenceController as IUserAction;
	}

	void OnGUI() {
		if (GUI.Button(new Rect(Screen.width/2-136, 70, 76, 30), "点我开始"))
			action.ReStart();
		if (action.GetMode () == ActionMode.KINEMATIC) {
			if(GUI.Button(new Rect(Screen.width/2+37, 70, 76, 30), "模式切换"))
				action.SwitchMode();
		}
		if (action.GetMode () == ActionMode.PHYSIC) {
			if(GUI.Button(new Rect(Screen.width/2+37, 70, 76, 30), "模式切换"))
				action.SwitchMode();
		}
	}
}