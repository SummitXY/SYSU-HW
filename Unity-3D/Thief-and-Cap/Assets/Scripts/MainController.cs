using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Caps;

public class MainController : SSActionManager, ISSActionCallback {
	private SceneController scene;

	public GameObject sceneModelItem, canvasItem, CapItem, ThiefItem;
    private GameObject insThief, sceneModel, canvasAndText;
    private List<GameObject> CapSet;
    private List<int> lastDirOfCap;

	public float thiefSpeed = 0.1f;
	public float capNormalSpeed = 0.05f;
	public float capFastSpeed = 0.06f;
	private bool stop = false;

	protected new void Start () {
		scene = SceneController.getInstance();
		scene.setGameModel(this);

		makeThief();
		makeCaps();
		sceneModel = Instantiate(sceneModelItem);
		canvasAndText = Instantiate(canvasItem);
	}

    void Awake() {
        CapFactory.getInstance().initItem(CapItem);
    }

	protected new void Update() {
		base.Update();
	}

    

    //生产小偷
    void makeThief() {
        insThief = Instantiate(ThiefItem);
    }

    
	public void addStop(){
		stop = true;
	}
    //小偷移动动作
    public void thiefMove(int dir) {
		if (stop) {
			return;
		}
        insThief.transform.rotation = Quaternion.Euler(new Vector3(0, dir * 90, 0));
        switch (dir) {
            case Diretion.UP:
			insThief.transform.position += new Vector3(0, 0, thiefSpeed);
                break;
            case Diretion.DOWN:
			insThief.transform.position += new Vector3(0, 0, -thiefSpeed);
                break;
            case Diretion.LEFT:
			insThief.transform.position += new Vector3(-thiefSpeed, 0, 0);
                break;
            case Diretion.RIGHT:
			insThief.transform.position += new Vector3(thiefSpeed, 0, 0);
                break;
        }
    }

    //动作结束后
    public void SSActionEvent(SSAction source, SSActionEventType eventType = SSActionEventType.Completed, 
        SSActionTargetType intParam = SSActionTargetType.Normal, string strParam = null, object objParam = null) {
        if (intParam == SSActionTargetType.Normal)
            addRandomMovement(source.gameObject, true);
        else
            addDirectMovement(source.gameObject);
    }

    //isActive说明是否主动变向（动作结束）
    public void addRandomMovement(GameObject sourceObj, bool isActive) {
		if (stop) {
			return;
		}
        int index = getIndexOfObj(sourceObj);
        int randomDir = getRandomDirection(index, isActive);
        lastDirOfCap[index] = randomDir;

        sourceObj.transform.rotation = Quaternion.Euler(new Vector3(0, randomDir * 90, 0));
        Vector3 target = sourceObj.transform.position;
        switch (randomDir) {
            case Diretion.UP:
                target += new Vector3(0, 0, 1);
                break;
            case Diretion.DOWN:
                target += new Vector3(0, 0, -1);
                break;
            case Diretion.LEFT:
                target += new Vector3(-1, 0, 0);
                break;
            case Diretion.RIGHT:
                target += new Vector3(1, 0, 0);
                break;
        }
        addSingleMoving(sourceObj, target, capNormalSpeed, false);
    }

    int getIndexOfObj(GameObject sourceObj) {
        string name = sourceObj.name;
        char cindex = name[name.Length - 1];
        int result = cindex - '0';
        return result;
    }
    int getRandomDirection(int index, bool isActive) {
        int randomDir = Random.Range(-1, 3);
        if (!isActive) {    
			//当碰撞时，不走同方向
            while (lastDirOfCap[index] == randomDir || ThiefEscapeArea(index, randomDir)) {
                randomDir = Random.Range(-1, 3);
            }
        }
        else {              
			//当非碰撞时，不走反方向
            while (lastDirOfCap[index] == 0 && randomDir == 2 
                || lastDirOfCap[index] == 2 && randomDir == 0
                || lastDirOfCap[index] == 1 && randomDir == -1
                || lastDirOfCap[index] == -1 && randomDir == 1
                || ThiefEscapeArea(index, randomDir)) {
                randomDir = Random.Range(-1, 3);
            }
        }
        return randomDir;
    }
    //确定小偷是否逃到下一个区域
    bool ThiefEscapeArea(int index, int randomDir) {
        Vector3 patrolPos = CapSet[index].transform.position;
        float posX = patrolPos.x;
        float posZ = patrolPos.z;
        switch (index) {
            case 0:
                if (randomDir == 1 && posX + 1 > FenchLocation.FenchVertLeft
                    || randomDir == 2 && posZ - 1 < FenchLocation.FenchHori)
                    return true;
                break;
            case 1:
                if (randomDir == 1 && posX + 1 > FenchLocation.FenchVertRight
                    || randomDir == -1 && posX - 1 < FenchLocation.FenchVertLeft
                    || randomDir == 2 && posZ - 1 < FenchLocation.FenchHori)
                    return true;
                break;
            case 2:
                if (randomDir == -1 && posX - 1 < FenchLocation.FenchVertRight
                    || randomDir == 2 && posZ - 1 < FenchLocation.FenchHori)
                    return true;
                break;
            case 3:
                if (randomDir == 1 && posX + 1 > FenchLocation.FenchVertLeft
                    || randomDir == 0 && posZ + 1 > FenchLocation.FenchHori)
                    return true;
                break;
            case 4:
                if (randomDir == 1 && posX + 1 > FenchLocation.FenchVertRight
                    || randomDir == -1 && posX - 1 < FenchLocation.FenchVertLeft
                    || randomDir == 0 && posZ + 1 > FenchLocation.FenchHori)
                    return true;
                break;
            case 5:
                if (randomDir == -1 && posX - 1 < FenchLocation.FenchVertRight
                    || randomDir == 0 && posZ + 1 > FenchLocation.FenchHori)
                    return true;
                break;
        }
        return false;
    }


	//生产警察
	void makeCaps() {
		CapSet = new List<GameObject>(6);
		lastDirOfCap = new List<int>(6);
		Vector3[] posSet = CapFactory.getInstance().getPosSet();
		for (int i = 0; i < 6; i++) {
			GameObject newPatrol = CapFactory.getInstance().getCap();
			newPatrol.transform.position = posSet[i];
			newPatrol.name = "Cap" + i;
			lastDirOfCap.Add(-2);
			CapSet.Add(newPatrol);
			addRandomMovement(newPatrol, true);
		}
	}

	//获得小偷所在区域
	public int nowThiefPosition() {
		return insThief.GetComponent<ThiefStatus>().standOnArea;
	}

    //追捕小偷
    public void addDirectMovement(GameObject sourceObj) {
		if (stop) {
			return;
		}
        int index = getIndexOfObj(sourceObj);
        lastDirOfCap[index] = -2;

        sourceObj.transform.LookAt(sourceObj.transform);
        Vector3 oriTarget = insThief.transform.position - sourceObj.transform.position;
        Vector3 target = new Vector3(oriTarget.x / 4.0f, 0, oriTarget.z / 4.0f);
        target += sourceObj.transform.position;
        addSingleMoving(sourceObj, target, capFastSpeed, true);
    }

    void addSingleMoving(GameObject sourceObj, Vector3 target, float speed, bool isCatching) {
        this.runAction(sourceObj, CCMoveToAction.CreateSSAction(target, speed, isCatching), this);
    }

    void addCombinedMoving(GameObject sourceObj, Vector3[] target, float[] speed, bool isCatching) {
        List<SSAction> acList = new List<SSAction>();
        for (int i = 0; i < target.Length; i++) {
            acList.Add(CCMoveToAction.CreateSSAction(target[i], speed[i], isCatching));
        }
        CCSequeneActions MoveSeq = CCSequeneActions.CreateSSAction(acList);
        this.runAction(sourceObj, MoveSeq, this);
    }

    
}
