using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMoveToAction : SSAction {
	private ISSActionCallback monitor = null;

    public Vector3 target;
    public float speed;

	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
		if (transform.position == target)
		{
			GameSceneController.GetInstance().setMoving(false);
			if (monitor != null) monitor.OnActionCompleted(this);
			Destroy(this);
		}
	}

    public void RunAction(Vector3 target, float speed, ISSActionCallback monitor)
    {
		this.monitor = monitor;
        this.target = target;
        this.speed = speed;
        
        GameSceneController.GetInstance().setMoving(true);
    }
		

}
