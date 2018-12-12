using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Caps;

//----------------------------------
// 描述警察行为
//----------------------------------

public class CapBehaviour : MonoBehaviour {
	private IGameStatusOp gameStatusOp;
	private IAddAction addAction;
    
	//是否加速追捕
	public bool isCatching;
	//观察半径
	private float CATCH_RADIUS = 3.0f;

    public int ownIndex;
   

    void Start () {
        addAction = SceneController.getInstance() as IAddAction;
        gameStatusOp = SceneController.getInstance() as IGameStatusOp;

        ownIndex = getOwnIndex();
        isCatching = false;
    }

	void Update () {
		checkIfByThief();
	}

	int getOwnIndex() {
		string name = this.gameObject.name;
		char cindex = name[name.Length - 1];
		int result = cindex - '0';
		return result;
	}
	
	void OnCollisionStay(Collision e) {
		//碰到围栏，选择下一个方向移动
		if (e.gameObject.name.Contains("Cap") || e.gameObject.name.Contains("fence")
			|| e.gameObject.tag.Contains("FenceAround")) {
			isCatching = false;
			addAction.addRandomMovement(this.gameObject, false);
		}

		//抓到小偷，游戏结束
		if (e.gameObject.name.Contains("Thief")) {
			gameStatusOp.capGetThief();
			addAction.addStop ();
		}
	}


    //检测到小偷进入自己管辖区域
    void checkIfByThief () {
        if (gameStatusOp.nowThiefPosition() == ownIndex) {    
            if (!isCatching) {
                isCatching = true;
                addAction.addDirectMovement(this.gameObject);
            }
        }
        else {
            if (isCatching) {    
                gameStatusOp.thiefEscapeFromCap();
                isCatching = false;
                addAction.addRandomMovement(this.gameObject, false);
            }
        }
    }

    
}
