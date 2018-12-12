using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ActionMode { KINEMATIC, PHYSIC }

public class GameController : MonoBehaviour, ISceneController, IUserAction
{
	public int trial = 10;
	public Text ScoreText;
	public Text RoundText;
	public Text GameText;
	public Text ModeText;

	public ActionMode mode = ActionMode.KINEMATIC;
	public ActionManager actionManager;

	private bool play = false;
	private int num = 0;
	private float heartbeat;

	public ScoreController scorekeeper;
	public UFOFactory DF;
    private int round = 0;
	public int totalRound = 3;

	GameObject disk;
	GameObject explosion;
    
	public Color[] TotalColor = {Color.white,Color.magenta,Color.black,Color.blue,Color.cyan,Color.green,Color.grey,Color.red,Color.yellow,Color.yellow };
    
    
    void Awake() {
        
        DF = UFOFactory.getInstance();
        DF.sceneControler = this;

		SSDirector director = SSDirector.getInstance();
        director.setFPS(60);
        director.currentScenceController = this;
        director.currentScenceController.LoadResources();

		scorekeeper = ScoreController.getInstance ();
		actionManager = gameObject.GetComponent<CCActionManager>();
    }
    void Start() {
        round = 1;
		heartbeat = 0;
    }
    
	public void StartGame() {
		num = 0;
		play = true;
		scorekeeper.reset ();
	}

	public void ReStart() {
		heartbeat = 0;
		round = 1;
		play = true;
		num = 0;
		DF.hideAll ();
		scorekeeper.reset ();
		GameText.text = "";

	}

    void Update() {
		if (play) {
			if (heartbeat >= 1) {
				heartbeat = 0;
				launchDisk ();

			}
			heartbeat += Time.deltaTime;
		}

		if (Input.GetButtonDown ("Fire1") && play) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameText.text = "";
				if (hit.transform.tag == "Disk") {
					explosion.transform.position = hit.collider.gameObject.transform.position;
					explosion.GetComponent<ParticleSystem> ().Play ();
					hit.collider.gameObject.SetActive (false);
					scorekeeper.record (hit.collider.gameObject);
				}
			}
		}
		updateStatus ();
    }

	public void LoadResources() {
		explosion = Instantiate(Resources.Load("prefabs/Explosion"), new Vector3(-40, 0, 0), Quaternion.identity) as GameObject;

	}


	private void launchDisk() {
		GameObject newDisk = DF.getDisk (mode);
		if (!newDisk.GetComponent<UFO> ())
			newDisk.AddComponent<UFO> ();
		newDisk.GetComponent<UFO> ().score = round;
		int index=Random.Range(0, 9);
		newDisk.GetComponent<Renderer> ().material.color =TotalColor[index];

		float size = (float)(1.0f - 0.2 * round);
		newDisk.transform.localScale = new Vector3(4*size, size/5, 4*size);
		num++;
		actionManager.singleRunAction (newDisk, round);
	}



	public ActionMode GetMode() {
		return mode;
	}

	public void SwitchMode() {
		if(mode == ActionMode.KINEMATIC) {
			mode=ActionMode.PHYSIC;
			actionManager = gameObject.GetComponent<PhysicsActionManager>();
			//GameText.text = "";
			ModeText.text = "物理运动模式";
		}
		else {
			mode = ActionMode.KINEMATIC;
			actionManager = gameObject.GetComponent<CCActionManager>();
			//GameText.text = "运动学模式";
			ModeText.text="运动学模式";
		}
	}

	private void updateStatus() {
		ScoreText.text = "分数:" + scorekeeper.score.ToString();
		RoundText.text = "局数:" + round.ToString();
		if (scorekeeper.score >= 6) {
			++round;
			GameText.text = "Round " + round.ToString();
			scorekeeper.reset ();
			num = 0;
		}
		if (round > totalRound) {
			play = false;
			GameText.text = "恭喜你，维护了世界和平";
		}
		if (num >= trial) {
			play = false;
			GameText.text = "很遗憾，请再接再厉";
		}
	}
}