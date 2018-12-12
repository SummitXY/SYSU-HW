using UnityEngine;
using System.Collections;


public interface GameInterface
{
	int getRound();
	int getScore();
	void nextRound();

	int getTrial();
	void setTrial(int input);

	bool isCounting();
	bool isShooting();

    void MakeEmissionDiskable();
    
    int getTimeToNextEmissionTime();
    
    void setScore(int point);
    void setRound(int input);
    
    void gameOver();
}

public class SceneController : System.Object, GameInterface
{
    private static SceneController _instance;
	private GUI _UserInterface;
	private MainController _firstController;
    private RoundController _roundController;
	private ScoreController _scoreController;
    
    private int _round;
	private int _trial;
    private int _score;
    public bool isGameOver;

    public static SceneController getInstance()
    {
        if (_instance == null)
        {
            _instance = new SceneController();
        }
        return _instance;
    }

	public void setFirstController(MainController input)
	{
		_firstController = input;
	}

	internal MainController getFirstController()
	{
		return _firstController;
	}

	public int getRound()
	{
		return _round;
	}

	public void setRound(int input)
	{
		_round = input;
	}

	public void nextRound()
	{
		_roundController.loadRoundData(++_round);
	}

	public int getTrial()
	{
		return _roundController.trial;
	}

	public void setTrial(int input)
	{
		_roundController.trial = input;
	}

	public bool isCounting()
	{
		return _firstController.getIsCounting();
	}

	public bool isShooting()
	{
		return _firstController.getIsShooting();
	}

    public void setScoreController(ScoreController input)
    {
        _scoreController = input;
    }

    internal ScoreController getScoreController()
    {
        return _scoreController;
    }

	public int getScore()
	{
		return _score;
	}

	public void setScore(int input)
	{
		_score = input;
	}
		
    internal GUI getUserInterface()
    {
        return _UserInterface;
    }

    public void setUserInterface(GUI input)
    {
        _UserInterface = input;
    }

    public void setRoundController(RoundController input)
    {
        _roundController = input;
    }

    internal RoundController getRoundController()
    {
        return _roundController;
    }


    public void MakeEmissionDiskable()
    {
        _firstController.MakeEmissionDiskable();
    }
		
   
    public int getTimeToNextEmissionTime()
    {
        return (int)_firstController.timeToNextEmission + 1;
    }
		
    public void gameOver()
    {
        isGameOver = true;
        _UserInterface.gameOver();
    }
}