using UnityEngine;
using System.Collections;


public class Curve {
	private float x = 0.0f;
	private float y = 0.0f;

	public float angle;

	public Curve(float angle) {
		this.angle = angle;
	}

	public float getX() {
		return x;
	}

	public float getY() {
		return y;
	}

	public void Draw() {
		float t = angle / 180.0f * Mathf.PI;
		float a=0.5f;
		float[] randomArr={0.4f,0.5f,0.6f,0.7f};
		a= randomArr[Random.Range(0, randomArr.Length)];
		x=a*(16*Mathf.Pow(Mathf.Sin(t),3));
		y=a*(13*Mathf.Cos(t)-5*Mathf.Cos(2*t)-2*Mathf.Cos(3*t)-Mathf.Cos(4*t));
	}

}

public class ParticleHeart : MonoBehaviour {

	private ParticleSystem particleSystem;
	//粒子数组
	private ParticleSystem.Particle[] particleArray;
	//粒子坐标集合
	private Curve[] particles;

	//粒子速度
	public float speed;
	//粒子个数
	public int count;
	//粒子大小
	public float size;
	//控制主方向是顺时针还是逆时针
	public bool clockwise ;


	private void Init() {
		int i;
		for (i = 0; i < count; i++) {
			float angle = Random.Range(0.0f, 360.0f);
			particles[i] = new Curve(angle);
			particles[i].Draw();
			particleArray[i].position = new Vector3(particles[i].getX(), particles[i].getY(), 0f);
		}

		particleSystem.SetParticles(particleArray, particleArray.Length);
	}
	// Use this for initialization
	void Start () {
		particleSystem = this.GetComponent<ParticleSystem>();
		particleArray = new ParticleSystem.Particle[count];
		particles = new Curve[count];
		particleSystem.startSpeed = 0;
		particleSystem.startSize = size;
		particleSystem.maxParticles = count;
		particleSystem.Emit(count);
		particleSystem.GetParticles(particleArray);
	
		Init();
	}

	// Update is called once per frame
	void Update () {
		int i;
		int level = 2; 
		for (i = 0; i < count; i++) {
			//外层粒子顺时针旋转
			if (i % level > 0)
			{
				particles[i].angle -= (i % level + 1) * speed;

			} else {
				//内层逆时针旋转
				particles[i].angle += (i % level + 1) * speed;
			}

			particles[i].angle = (particles[i].angle + 360.0f) % 360.0f;
			particles[i].Draw();
			particleArray[i].position = new Vector3(particles[i].getX(), particles[i].getY(), 0.0f);
		}
		particleSystem.SetParticles(particleArray, particleArray.Length);
	}
}