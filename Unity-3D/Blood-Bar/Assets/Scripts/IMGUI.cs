using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI : MonoBehaviour {
	
	private Rect bloodbar;
	private Rect addBtn;
	private Rect minusBtn;

    public float nowBlood = 0.0f;
	private float resVal;
    private bool onoff;

    void Start()
    {

		bloodbar = new Rect(350, 160, 250, 50);  

		addBtn = new Rect(610, 160, 20, 20);  

		minusBtn = new Rect(320, 160, 20, 20);  
        resVal = nowBlood;
    }

    void OnGUI()
    {
        if (GUI.Button(addBtn, "+"))
        {
            resVal += 0.2f;
        }
        if (GUI.Button(minusBtn, "-"))
        {
            resVal -= 0.2f;
        }
        if (resVal > 1.0f)
        {
            resVal = 1.0f;
        }
        if (resVal < 0.0f)
        {
            resVal = 0.0f;
        }

        nowBlood = Mathf.Lerp(nowBlood, resVal, 0.05f);

		GUI.HorizontalScrollbar(bloodbar, 0.0f, nowBlood, 0.0f, 1.0f, GUI.skin.GetStyle("horizontalscrollbar"));  
		GUI.color = Color.red;
    }
}