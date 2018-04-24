using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {
    private IUserAction action;

	// Use this for initialization
	void Start () {
        action = SSDirector.getInstance().currentSceneController as IUserAction;
	}

    private void OnGUI()
    {
        float windowW = Screen.width;
        float windowH = Screen.height;

        GUIStyle gui = new GUIStyle();
        gui.fontSize = 40;
        gui.normal.textColor = Color.red;
        GUI.Label(new Rect(0, 100, 100, 100), "力量：" + action.getPower());
        GUI.Label(new Rect(200, 0, 100, 100), "分数：" + action.getGoal(), gui);
        GUI.Label(new Rect(0, 0, 100, 100), "箭囊：" + (action.getArrow() == true? "满" : "空"), gui);

    }
}
