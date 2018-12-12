using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor.VersionControl;


// 游戏场景控制器
public class GameSceneController : System.Object, UserActions, QueryGameStatus
{
    private static GameSceneController _instance;
    private GenGameObject _gen_game_obj;

	private string message = "";
    private bool moving = false;
    
	public string gameRule ="";
    public static GameSceneController GetInstance()
    {
        if (null == _instance) _instance = new GameSceneController();
        return _instance;
    }

    public IEnumerator nextmove()
    {
        yield return _gen_game_obj.nextMove();
    }
		
    public GenGameObject getGenGameObject() { return _gen_game_obj; }
    internal void setGenGameObject(GenGameObject ggo) { if (null == _gen_game_obj) _gen_game_obj = ggo; }

	public void priestSOnB() { _gen_game_obj.priestStartOnBoat(); }
	public void priestEOnB() { _gen_game_obj.priestEndOnBoat(); }

	public void devilSOnB() { _gen_game_obj.devilStartOnBoat(); }
	public void devilEOnB() { _gen_game_obj.devilEndOnBoat(); }

	public string getMessage() { return message; }
	public void setMessage(string message) { this.message = message; }

    public bool isMoving() { return moving; }
    public void setMoving(bool state) { this.moving = state; }

    public void moveBoat() { _gen_game_obj.moveBoat(); }

    public void offBoatL() { _gen_game_obj.getOffTheBoat(0); }
    public void offBoatR() { _gen_game_obj.getOffTheBoat(1); }

    public void restart()
    {
        moving = false;
        message = "";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}

// 游戏对象当前运动状态
public interface QueryGameStatus
{
	string getMessage();
	void setMessage(string message);

	bool isMoving();
	void setMoving(bool state);

}

public interface UserActions
{
	void devilSOnB();
	void devilEOnB();

	void priestSOnB();
	void priestEOnB();

	void offBoatL();
	void offBoatR();

	void moveBoat();
	IEnumerator nextmove();

	void restart();

}


