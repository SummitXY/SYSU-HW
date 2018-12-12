using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Com.Caps;

//----------------------------------
// 游戏信息界面
//----------------------------------
public class GUIText : MonoBehaviour {
	
    private int times = 0;
    private int textType;  //0为计数，1为游戏结束
	private bool isOver=false;


    void distinguishText() {
        if (gameObject.name.Contains("Times"))
            textType = 0;
        else
            textType = 1;
    }

	void Start () {
		distinguishText();
	}

	void Update () {

	}

    void OnEnable() {
        GameEventManager.myGameScoreAction += gameScore;
        GameEventManager.myGameOverAction += gameOver;
    }

    void OnDisable() {
        GameEventManager.myGameScoreAction -= gameScore;
        GameEventManager.myGameOverAction -= gameOver;
    }

    void gameScore() {
		if (textType == 0) {
            times++;
			this.gameObject.GetComponent<Text>().text = "成功脱逃次数: " + times;

        }
    } 

    void gameOver() {
		if (textType == 1) {
			this.gameObject.GetComponent<Text>().text = "你被逮捕了!";

		}
            
    }
}
