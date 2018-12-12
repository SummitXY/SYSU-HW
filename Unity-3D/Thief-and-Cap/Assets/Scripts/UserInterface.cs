using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Caps;

public class UserInterface : MonoBehaviour {
    private IUserAction action;

    void Start () {
        action = SceneController.getInstance() as IUserAction;
    }
	
	void Update () {
        detectKeyInput();
    }
	//wasd控制小偷上下左右移动
    void detectKeyInput() {
        if (Input.GetKey(KeyCode.W)) {
            action.thiefMove(Diretion.UP);
        }
        if (Input.GetKey(KeyCode.S)) {
            action.thiefMove(Diretion.DOWN);
        }
        if (Input.GetKey(KeyCode.A)) {
            action.thiefMove(Diretion.LEFT);
        }
        if (Input.GetKey(KeyCode.D)) {
            action.thiefMove(Diretion.RIGHT);
        }
    }
}
