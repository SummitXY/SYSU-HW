using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour
{
	private GameInterface gameInterface;
	private SceneController scene;

	private int round; 

	public Text mainText;   
    public Text scoreText;  
    public Text roundText; 

    public GameObject bullet;          
    public ParticleSystem explosion;    
    public float fireRate = .25f;      
    public float speed = 500f;
	private float nextFireTime;

    public bool isGameOver = false;
    

    public void Awake()
    {
		SceneController.getInstance().setUserInterface(this);
        
    }
    void Start()
    {
		gameInterface = SceneController.getInstance() as GameInterface;

		bullet = GameObject.Instantiate(bullet) as GameObject;

        explosion = GameObject.Instantiate(explosion) as ParticleSystem;
    }

    public void gameOver()
    {
        isGameOver = true;
        mainText.text = "For World Peace";
    }

    void Update()
    {
        if(Input.GetKeyDown("space") && isGameOver)
        {
            scene.setRound(0);
            scene.nextRound();
            isGameOver = false;
        }
        if (!isGameOver)
        {
            if (gameInterface.isCounting())
            { 
                //mainText.text = "Turn: " + (gameInterface.getTrial() + 1).ToString();
            }
            else
            {

                gameInterface.MakeEmissionDiskable();
                if (gameInterface.isShooting())
                {
                    mainText.text = "";
                }

                if (gameInterface.isShooting() && Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
                {
                    nextFireTime = Time.time + fireRate;

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;                  
                    bullet.transform.position = transform.position;
                    bullet.GetComponent<Rigidbody>().AddForce(ray.direction * speed, ForceMode.Impulse);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Disk")
                    {

                        explosion.transform.position = hit.collider.gameObject.transform.position;
                        explosion.GetComponent<Renderer>().material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                        explosion.Play();
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }

            roundText.text = "Round: " + gameInterface.getRound().ToString();
            scoreText.text = "Score: " + gameInterface.getScore().ToString();

            if (round != gameInterface.getRound())
            {
                round = gameInterface.getRound();
                mainText.text = "Round " + round.ToString() + " !";
            }
        }
    }
}