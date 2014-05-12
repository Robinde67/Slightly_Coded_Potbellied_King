using UnityEngine;
using System.Collections;

public class FoodThrown : MonoBehaviour {

	public Main m_xMain;

	public int m_iFoodnum;

	public int[] m_iaCalories;
	
	public int[] m_iaValue;

	public float m_iDelY;

	public bool m_bThrown;

	public Vector3 m_vSpd;

	public AudioClip m_xSound;

	private AudioSource m_xSource;

	public Sprite[] m_xaSprites;

	public PlayerControl m_xPlayer;

	private Vector3 m_vMovement;
	
	void Start (){
		//SaveTextureToFile( m_xTexture, "picture.png");
		m_xMain = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
		m_xPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}

	void Update (){

	}

	void FixedUpdate(){
		if (this.transform.position.y < m_iDelY) {
			Destroy(this.gameObject);
		}
	}

	public void Throw(){
		SpriteRenderer l_xRend = this.gameObject.GetComponent<SpriteRenderer>();
		l_xRend.sprite = m_xaSprites [m_iFoodnum];

		if(m_xSource == null)
		{
			m_xSource = gameObject.AddComponent<AudioSource>();
			m_xSource.clip = m_xSound;
		}

		if(!m_xSource.isPlaying)
		{
			m_xSource.Play ();
		}
		
		m_vMovement = m_vSpd;
		rigidbody.velocity = m_vMovement;
		m_bThrown = false;
	}

	void OnTriggerEnter(Collider p_xOther){
		if (p_xOther.gameObject.tag == "Player") {
			m_xMain.m_iScore += m_iaValue[m_iFoodnum];


			m_xPlayer.PlaySound();

			Destroy(this.gameObject);
		}
	}
}