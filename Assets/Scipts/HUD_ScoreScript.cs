using UnityEngine;
using System.Collections;

public class HUD_ScoreScript : MonoBehaviour {

	public Main m_xMain;

	public GUIText m_xText;

	//private int m_iScore;

	void Start () {
		//m_xText.fontSize = 12;
	}

	void Update () {
		m_xText.text = m_xMain.m_iScore.ToString ();
	}
}