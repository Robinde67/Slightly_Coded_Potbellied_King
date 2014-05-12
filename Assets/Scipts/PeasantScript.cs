using UnityEngine;
using System.Collections;

public class PeasantScript : MonoBehaviour {

	public float m_fRange;

	public float m_fRangeAddOn;

	public int m_iDist;

	public bool m_bRWave;

	public bool m_bLWave;

	public FoodThrown[] m_xaFood;

	public PlayerControl m_xKing;

	public bool m_bInDist;

	public bool m_bThrown;

	void Start (){

		m_bThrown = false;

		if (m_bLWave && m_bRWave) {
			m_bLWave = false;
			m_bRWave = false;
		}
	}

	void Update (){
		if (m_xKing.rigidbody.position.z < this.transform.position.z && m_iDist > (this.transform.position.z - m_xKing.rigidbody.position.z)) {
			m_bInDist = true;
		}
		else {
			m_bInDist = false;
		}
	}

	void FixedUpdate(){
		if ((m_bInDist && m_xKing.m_bRhandWave && m_bRWave) || (m_bInDist && m_xKing.m_bLhandWave && m_bLWave) || (m_bInDist && !m_bLWave && !m_bRWave)) {
			if (!m_bThrown){
				for (int i = 0; i < m_xaFood.Length; i++){
					FoodThrown l_xFood;

					//l_xFood = Instantiate (Resources.Load<GameObject>("Assets/Prefabs/Food" + m_iaFood + ".prefab"), this.transform.position, this.transform.rotation) as GameObject;
					l_xFood = Instantiate (m_xaFood[i], this.transform.position, this.transform.rotation) as FoodThrown;

					l_xFood.Throw(Random.Range (-m_fRange, m_fRange) + m_fRangeAddOn);
				}

				m_bThrown = true;
			}
		}
	}
}