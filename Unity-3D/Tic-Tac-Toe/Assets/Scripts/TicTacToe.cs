using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour {
	private int turn=1;
	private int[,] chessBoard=new int[3,3];
	public Texture2D background;
	public Texture2D img1;  
	public Texture2D img2; 

	void Reset()
	{
		turn = 1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				chessBoard [i, j] = 0;
			}
		}
	}

	void Start () {
		Reset ();
	}

	void OnGUI()
	{
		Debug.Log ("测试ing");
		
		GUIStyle backgroundStyle = new GUIStyle ();
		backgroundStyle.normal.background = background;
		GUI.Label (new Rect(0,0,1424,781),"",backgroundStyle);

		GUIStyle titleStyle = new GUIStyle ();  
		titleStyle.fontSize = 48;
		GUI.Label (new Rect(550,100,100,100),"Tic Tac Toe",titleStyle);

		GUIStyle titleStyle2 = new GUIStyle ();
		titleStyle2.fontSize = 30;
		titleStyle2.normal.textColor = new Color (0,0,0);

		GUI.Label (new Rect (350, 150, 200, 100), img1);  
		GUI.Label (new Rect (900, 150, 200, 100), img2);  

		if (GUI.Button (new Rect (625, 500, 100, 50), "RESET"))  
			Reset ();  
		int result = check ();    
		if (result == 1) {    
			GUI.Label (new Rect (300, 300, 100, 50), "阿里爸爸获胜", titleStyle2);    
		} else if (result == 2) {    
			GUI.Label (new Rect (850, 300, 100, 50), "腾讯爸爸赢了", titleStyle2);    
		}   

		for (int i=0; i<3; ++i) {    
			for (int j=0; j<3; ++j) {    
				if (chessBoard [i, j] == 1)    
					GUI.Button (new Rect (555 + i * 80, 220 + j * 80, 80, 80), img1);  
				if (chessBoard [i, j] == 2)  
					GUI.Button (new Rect (555 + i * 80, 220 + j * 80, 80, 80), img2);  
				if (GUI.Button (new Rect (555 + i * 80, 220 + j * 80, 80, 80), "")) {    
					if (result == 0) {    
						if (turn == 1)    
							chessBoard [i, j] = 1;  
						else    
							chessBoard [i, j] = 2;    
						turn = -turn;    
					}    
				}    
			}  
		}  


	}

	int check()
	{
		// 水平三连发  
		for (int i=0; i<3; ++i) {    
			if (chessBoard[i,0]!=0 && chessBoard[i,0]==chessBoard[i,1] && chessBoard[i,1]==chessBoard[i,2]) {    
				return chessBoard[i,0];    
			}    
		}    
		//竖直三连发
		for (int j=0; j<3; ++j) {    
			if (chessBoard[0,j]!=0 && chessBoard[0,j]==chessBoard[1,j] && chessBoard[1,j]==chessBoard[2,j]) {    
				return chessBoard[0,j];    
			}    
		}    
		//对角三连发   
		if (chessBoard[1,1]!=0 &&    
			chessBoard[0,0]==chessBoard[1,1] && chessBoard[1,1]==chessBoard[2,2] ||    
			chessBoard[0,2]==chessBoard[1,1] && chessBoard[1,1]==chessBoard[2,0]) {    
			return chessBoard[1,1];    
		}    
		return 0; 
	}

	

}
