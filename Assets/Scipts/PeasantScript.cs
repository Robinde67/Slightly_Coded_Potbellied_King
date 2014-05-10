using UnityEngine;
using System.Collections;

public class PeasantScript : MonoBehaviour {

	public int m_iRange;

	public int m_iRangeAddOn;

	public int m_iDist;

	public int m_iFoodAmount;

	public int m_iFoodType;

	public bool m_bRWave;

	public bool m_bLWave;

	//public FoodThrown m_xFood;

	public PlayerControl m_xKing;

	public bool m_bInDist;

	void Start (){
		m_iFoodAmount = 2;
		m_iDist = 60;
	}

	void Update (){
		if (m_xKing.rigidbody.position.z < this.transform.position.z && m_iDist > (this.transform.position.z - m_xKing.rigidbody.position.z)) {
			m_bInDist = true;
		}
		else {
			m_bInDist = false;
		}

		if (m_bLWave && m_bRWave) {
			m_bLWave = false;
			m_bRWave = false;
		}
	}

	void FixedUpdate(){
		if ((m_bInDist && m_xKing.m_bRhandWave && m_bRWave) || (m_bInDist && m_xKing.m_bLhandWave && m_bLWave) || (m_bInDist && !m_bLWave && !m_bRWave)) {
			for (int i = 0; i < m_iFoodAmount; i++){
				GameObject l_xFood;

				l_xFood = Instantiate (Resources.Load<GameObject>("Prefabs/Food0"), this.transform.position, this.transform.rotation) as GameObject;
				l_xFood.GetComponent<FoodThrown>().m_iFoodnum = Random.Range(0, 3);
				l_xFood.GetComponent<FoodThrown>().m_bThrown = true;
				l_xFood.GetComponent<FoodThrown>().m_vSpd.x = Random.Range (-m_iRange, m_iRange) + m_iRangeAddOn;
				l_xFood.rigidbody.useGravity = true;

				l_xFood.GetComponent<FoodThrown>().Throw();
				
				m_iFoodAmount--;
			}
		}
	}
}