using UnityEngine;
using System.Collections;

public class FoodThrown : MonoBehaviour {

	public Main m_xMain;
	
	public int m_iValue;
	public int m_iComboBonus;
	public bool m_bComboBreakerC;
	public bool m_bComboBreakerL;
	public Sprite[] m_xaFood;

	public float m_iDelY;

	public bool m_bThrown;

	public Vector3 m_vSpd;

	public AudioClip m_xSound;

	private AudioSource m_xSource;

	public PlayerControl m_xPlayer;

	private Vector3 m_vMovement;
	
	void Start (){
		//SaveTextureToFile( m_xTexture, "picture.png");
		m_bThrown = false;

		m_xMain = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
		m_xPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

		m_xSource = this.gameObject.GetComponent<AudioSource>();
	}

	void Update (){

	}

	void FixedUpdate(){
		if (this.transform.position.y < m_iDelY && m_bThrown) {
			OnLose();
		}
	}

	public void Throw(float p_fRangeSpd){
		SpriteRenderer l_xRend = this.gameObject.GetComponent<SpriteRenderer>();
		l_xRend.sprite = GetFood ();

		//if (m_xSource == null){
			//m_xSource = gameObject.AddComponent<AudioSource>();
			//m_xSource.clip = m_xSound;
		//}

		AudioSource l_xSource = this.gameObject.GetComponent<AudioSource> ();

		l_xSource.Play ();

		/*if (!m_xSource.isPlaying){
			m_xSource.Play ();
		}*/

		this.rigidbody.useGravity = true;

		m_vMovement = m_vSpd;
		m_vMovement.x = p_fRangeSpd;

		this.rigidbody.velocity = m_vMovement;

		m_bThrown = true;
	}

	void OnTriggerEnter(Collider p_xOther){
		if (p_xOther.gameObject.tag == "Player") {
<<<<<<< HEAD
			m_xMain.m_iScore += m_iaValue[m_iFoodnum];

=======

			OnCatch();
>>>>>>> d30b73edfb2cdfcd9a2cfeff42ca8efb096fd120

			m_xPlayer.PlaySound();

			Destroy(this.gameObject);
		}
	}

	Sprite GetFood(){
		int l_iR = Random.Range(0, m_xaFood.Length);
		
		if (l_iR >= m_xaFood.Length) {
			l_iR = 0;
		}
		
		return m_xaFood[l_iR];
	}

	void OnLose(){
		if (m_bComboBreakerL){
			m_xMain.ComboReset();
		}

		Destroy(this.gameObject);
	}

	void OnCatch(){
		m_xMain.m_iScore += (m_iValue + m_iComboBonus * m_xMain.ComboUp());

		if (m_bComboBreakerC){
			m_xMain.ComboReset();
		}
	}
}