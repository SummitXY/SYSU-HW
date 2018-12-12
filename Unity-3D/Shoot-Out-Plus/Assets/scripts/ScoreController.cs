using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController {
	public int score;

	private static ScoreController _instance;

	public static ScoreController getInstance(){
		if (_instance == null)
			_instance = new ScoreController();
		return _instance;
	}


	public void record(GameObject hit) {
		score += hit.GetComponent<UFO> ().score;
	}

	public void reset(){
		score = 0;
	}
}