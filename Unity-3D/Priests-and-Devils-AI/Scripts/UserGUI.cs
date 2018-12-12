using UnityEngine;
using System.Collections;


public class UserGUI : MonoBehaviour
{
    GameSceneController scene;
    QueryGameStatus state;
    UserActions action;

    float width, height;
    float castw(float scale) { return (Screen.width - width) / scale; }
    float casth(float scale) { return (Screen.height - height) / scale; }

    void Start()
    {
        scene = GameSceneController.GetInstance();
        state = GameSceneController.GetInstance() as QueryGameStatus;
        action = GameSceneController.GetInstance() as UserActions;
    }

    void OnGUI()
    {
        GUI.skin.button.fontSize = GUI.skin.textArea.fontSize = 14;

        if (state.getMessage() != "")
        {
			if (GUI.Button(new Rect(castw(2.2f), casth(4f), 200,50), state.getMessage())) action.restart();
        }
        else
        {

			if (!state.isMoving ()) 
			{
				if (GUI.Button(new Rect(castw(2.2f), casth(4f), 200,50), "AI告诉你下一步如何走")) StartCoroutine(action.nextmove());

			}
        }
    }
}