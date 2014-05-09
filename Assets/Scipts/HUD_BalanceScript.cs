using UnityEngine;
using System.Collections;

public class HUD_BalanceScript : MonoBehaviour {

	public Main m_xMain;

	public float m_fAddOn;

	public float m_fMaxPosX;
	public float m_fMaxRot;

	public GameObject m_gArrow;

	public PlayerControl m_xPlayer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		m_gArrow.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x + GetPos(), m_gArrow.gameObject.transform.position.y, m_gArrow.gameObject.transform.position.z);
		//m_gArrow.gameObject.transform.rotation = new Quaternion (0, 0, GetRot(), 0);

		print (m_fMaxPosX * (m_xPlayer.GetBalance() / m_xPlayer.GetLimit()));
		print (m_fMaxRot * (m_xPlayer.GetBalance() / m_xPlayer.GetLimit()));
	}

	float GetPos(){
		if ((m_fMaxPosX * (m_xPlayer.GetBalance () / m_xPlayer.GetLimit ())) < m_fMaxPosX && (m_fMaxPosX * (m_xPlayer.GetBalance () / m_xPlayer.GetLimit ())) > -m_fMaxPosX) {
			return m_fMaxPosX * (m_xPlayer.GetBalance () / m_xPlayer.GetLimit ());
		}
		else if ((m_fMaxPosX * (m_xPlayer.GetBalance () / m_xPlayer.GetLimit ())) <= -m_fMaxPosX){
			return -m_fMaxPosX;
		}

		return m_fMaxPosX;
	}

	float GetRot(){
		if ((m_fMaxRot * (m_xPlayer.GetBalance () / m_xPlayer.GetLimit())) < m_fMaxRot && (m_fMaxRot * (m_xPlayer.GetBalance () / m_xPlayer.GetLimit())) > -m_fMaxRot) {
			return m_fMaxRot * (m_xPlayer.GetBalance () / m_xPlayer.GetLimit ());
		}
		
		return m_fMaxRot;
	}
}