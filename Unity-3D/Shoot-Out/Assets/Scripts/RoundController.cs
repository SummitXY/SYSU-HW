using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundController : MonoBehaviour
{
	void Start()
	{
		scene.nextRound();
	}

	public int trial = 0;
	private SceneController scene;
    private Color color;
	private float speed;

	private Vector3 emissionDiretion;
    private Vector3 emissionPositon;
    
    
    void Awake()
    {
        SceneController.getInstance().setRoundController(this);
        scene = SceneController.getInstance();
    }
		
    public void loadRoundData(int round)
    {
        trial = 0;
        switch (round)
        {
            case 1:    
				color = Color.blue;
                emissionPositon = new Vector3(-2.5f, 0.2f, -5f);
                emissionDiretion = new Vector3(24.5f, 40.0f, 67f);
                speed = 2;
                SceneController.getInstance().getFirstController().setting(1, color, emissionPositon, emissionDiretion.normalized, speed, 1);
                break;
            case 2:    
                color = Color.green;
                emissionPositon = new Vector3(2.5f, 0.2f, -5f);
                emissionDiretion = new Vector3(-24.5f, 35.0f, 67f);
                speed = 4;
                SceneController.getInstance().getFirstController().setting(1, color, emissionPositon, emissionDiretion.normalized, speed, 2);
                break;
            case 3:
                color = Color.red;
                emissionPositon = new Vector3(2.5f, 0.2f, -5f);
                emissionDiretion = new Vector3(-24.5f, 35.0f, 67f);
                speed = 6;
                SceneController.getInstance().getFirstController().setting(1, color, emissionPositon, emissionDiretion.normalized, speed, 3);
                break;
        }
    }
}