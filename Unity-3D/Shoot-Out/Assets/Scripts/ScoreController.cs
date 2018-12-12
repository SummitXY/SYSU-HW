using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
	private SceneController scene;

    private int oneDiskScore = 15;
    private int oneDiskFail = 10;

    void Awake()
    {
        scene = SceneController.getInstance();
        scene.setScoreController(this);
    }
    

    public void hitDisk()
    {
        scene.setScore(scene.getScore() + oneDiskScore);
    }

    public void hitGround(int input)
    {
        scene.setScore(scene.getScore() - oneDiskFail * input * input);
    }
}