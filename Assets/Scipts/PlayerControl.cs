using UnityEngine;
using System;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public Main m_xMain;
	
	public int m_iLimitTimeOut;
	public int m_iLimitTimeOutStart;

	public float m_fLimit;
	public float m_fLimitVariance;

	public bool m_bRhandWave;
	public bool m_bLhandWave;
	public bool m_bMoveOut;
	public bool m_bFallOff;

	public bool m_bUseKeyb;

	public Vector3 m_vSpd;
	public Vector3 m_vAddon;
	public Vector3 m_vBounds;

	public AudioClip[] m_xSound;

	public GameObject m_gFocus;
	public GameObject m_gRhand;
	public GameObject m_gLhand;

	public float m_fBodyRot;
	public float m_fMaxRot;
	public GameObject m_gBody;

	private int m_iWeight;
	private int m_iMinWeight;
	private int m_iMaxWeight;
	private int m_iScore;

	private Vector3 m_vMovement;
	private Vector3 m_vZero;
	
	void Start () {
		m_iScore = m_xMain.m_iScore;
	}

	void Update () {

	}

	void FixedUpdate() {

		if (m_iMaxWeight <= 0) {
			m_iMaxWeight = 1;
		}

		BalanceUpdate ();
		WavingUpdate ();
		MovementUpdate ();

		if (m_bFallOff) {
			PlayerPrefs.SetInt("m_iScore", m_iScore);
			Application.LoadLevel("Scene_02");
		}
	}

	void BalanceUpdate(){
		m_vMovement.x = GetBalance() * m_vSpd.x;

		m_vMovement.z = m_vSpd.z + m_vSpd.z * (m_iWeight / m_iMaxWeight);

		if (!m_bMoveOut) {
			m_vMovement.z = 0;
		}

		float l_fRot = GetBalance() * m_fBodyRot;

		if (l_fRot > m_fMaxRot) {
			l_fRot = m_fMaxRot;
		}
		else if (l_fRot < -m_fMaxRot) {
			l_fRot = -m_fMaxRot;
		}

		m_gBody.transform.rotation = new Quaternion(0, 0, (l_fRot), 0);

		/*if (GetBalance() > GetLimit() || GetBalance() < -GetLimit()) {
			m_iLimitTimeOut--;
			if (m_iLimitTimeOut <= 0 && m_bMoveOut) {
				m_bFallOff = true;
			}
		}
		else if (m_iLimitTimeOut < m_iLimitTimeOutStart) {
			m_iLimitTimeOut++;
		}*/
	}

	void WavingUpdate(){
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
		
		if (m_bRhandWave || m_bLhandWave) {
			m_bMoveOut = true;
		}
	}

	void MovementUpdate(){
		if (m_bFallOff){
			m_vMovement = m_vZero;
		}

		if (m_bUseKeyb) {
			if (Input.GetKey(KeyCode.D)){
				m_vMovement.x = 0.2f * m_vSpd.x;
			}
			else if (Input.GetKey(KeyCode.A)){
				m_vMovement.x = -0.2f * m_vSpd.x;
			}
		}
		
		rigidbody.velocity = m_vMovement;
	}

	public float GetLimit(){
		return (m_fLimit - m_fLimitVariance * (m_iWeight / m_iMaxWeight));
	}

	public float GetBalance(){
		return m_gFocus.transform.position.x + m_vAddon.x;
	}

	public void PlaySound(){
		int l_iR = UnityEngine.Random.Range(0, 3);
		if(l_iR ==3)
		{
			l_iR = 0;
		}
		audio.clip = m_xSound[l_iR];
		audio.Play ();
	}
}