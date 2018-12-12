using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Caps;

public class GameEventManager : MonoBehaviour {

    public delegate void GameScoreAction();
    public static event GameScoreAction myGameScoreAction;

    public delegate void GameOverAction();
    public static event GameOverAction myGameOverAction;

    private SceneController scene;

    void Start () {
        scene = SceneController.getInstance();
        scene.setGameEventManager(this);
    }
	
	void Update () {
		
	}

    //小偷逃脱追捕，加1分
    public void thiefEscapeFromCap() {
        if (myGameScoreAction != null)
            myGameScoreAction();
    }

    //警察捕获小偷，游戏结束
    public void capGetThief() {
        if (myGameOverAction != null)
            myGameOverAction();
    }
}
