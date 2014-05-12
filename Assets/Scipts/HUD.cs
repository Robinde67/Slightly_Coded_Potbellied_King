using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	public Main m_xMain;

	public GUIStyle m_xGUIStyle;

	public GUIContent m_xScoreCounter;
	public GUIContent m_xLeftIndicator;
	public GUIContent m_xRightIndicator;

	void OnGUI(){
		GUI.Box (new Rect (Screen.width - 322 , 20, 280, 120), m_xScoreCounter, m_xGUIStyle);
		GUI.Label (new Rect (Screen.width - 335, 38, 280, 120), m_xMain.m_iScore.ToString (), m_xGUIStyle);
        if (m_xMain.m_bLeftIndicator)
        {
            GUI.Box (new Rect (100, Screen.height / 2 - 150, 200, 300), m_xLeftIndicator, m_xGUIStyle);
        }
        if (m_xMain.m_bRightIndicator)
        {
            GUI.Box(new Rect(Screen.width - 300, Screen.height / 2 - 150, 200, 300), m_xRightIndicator, m_xGUIStyle);
        }
	}
}