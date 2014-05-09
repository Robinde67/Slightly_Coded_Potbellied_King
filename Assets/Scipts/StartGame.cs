using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject m_gFocus;

	public GameObject m_gRhand;
	public GameObject m_gLhand;

	private bool m_bRhandWave;
	private bool m_bLhandWave;
	
	void Start () {
	
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Waving()) {
			print ("Game Start !");
			Application.LoadLevel ("Scene_01");
		}
	}

	bool Waving(){
		if (m_gRhand.transform.position.y > m_gFocus.transform.position.y && !m_bLhandWave) {
			m_bRhandWave = true;
		}
		else {
			m_bRhandWave = false;
		}
		
		if (m_gLhand.transform.position.y > m_gFocus.transform.position.y && !m_bRhandWave){
			m_bLhandWave = true;
		}
		else {
			m_bLhandWave = false;
		}

		if (m_bRhandWave && m_bLhandWave) {
			return false;
		}
		else if (m_bRhandWave || m_bLhandWave) {
			return true;
		}

		return false;
	}
}