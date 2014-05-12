using UnityEngine;
using System.Collections;

using System.IO;

[RequireComponent(typeof(Renderer))]

public class Main : MonoBehaviour
{
	public int m_iScore;
	public int m_iCombo;

	public bool m_bLeftIndicator;
	public bool m_bRightIndicator;

	public GameObject m_gGoal;

	public GameObject m_gPlayer;

	public DisplayColor m_xDispl;

	private Texture2D m_tTex;

	void Start(){
		m_iScore = 0;
		gameObject.GetComponent<AudioSource>().Play();
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.F12)) {

		}

		if (WinCondition ()) {
			PlayerPrefs.SetInt("m_iScore", m_iScore);
			Application.LoadLevel("Scene_02");
		}
	}

	void FixedUpdate(){

	}

	void TakePicture(){
		if (Input.GetKeyDown (KeyCode.S)) {
			m_tTex = (m_xDispl.GetCurrentTexture());
			byte[] l_bByte = m_tTex.EncodeToPNG();
			
			//Destroy (m_tTex);
			
			//File.WriteAllBytes("../SavedScreen.png", l_bByte);
			
			print("Screenshot Taken :D");
		}
	}

	bool WinCondition(){
		if (m_gPlayer.transform.position.z > m_gGoal.transform.position.z) {
			return true;
		}

		return false;
	}
}