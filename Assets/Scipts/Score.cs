using UnityEngine;
using System.Collections;

using System.IO; 

public class Score : MonoBehaviour {

	public bool m_bSetTestScore;

	public int m_iCurrentScore;

	public int[] m_iaHighScore;
	public string[] m_saFname;
	public string[] m_saPhotoName;
	
	public TextMesh[] m_xaHighScoreText;
	public TextMesh m_xTextData;
	public TextMesh m_xCurrentScore;

	void Start () {
		for (int i = 0; i < m_saFname.Length; i++) {
			StreamReader theReader = new StreamReader("Assets/HighScoreData/" + m_saFname[i] + ".txt");

			string l_sLine = theReader.ReadToEnd();

			theReader.Close();

			m_iaHighScore[i] = int.Parse(l_sLine);

			print (i + " reading: " + m_iaHighScore[i]);
		}

		if (!m_bSetTestScore){
			m_iCurrentScore = PlayerPrefs.GetInt ("m_iScore");
		}

		//bool l_bSorted;

		for (int i = 0; i < m_iaHighScore.Length; i++){
			if (m_iCurrentScore > m_iaHighScore[i]){
				//l_bSorted = true;

				for (int ii = m_iaHighScore.Length - 1; ii > i; ii--){
					if (ii > 0){
						print (ii + " = " + (ii - 1));
						m_iaHighScore[ii] = m_iaHighScore[ii - 1];
					}
				}

				m_iaHighScore[i] = m_iCurrentScore;

				for (int ii = 0; ii < m_iaHighScore.Length; ii++){
					File.WriteAllText("Assets/HighScoreData/" + m_saFname[ii] + ".txt", m_iaHighScore[ii].ToString());
					print ("wrote " + m_iaHighScore[ii] + " to " + "Assets/HighScoreData/" + m_saFname[ii] + ".txt");
				}
				i = m_iaHighScore.Length;
			}
		}

		for (int i = 0; i < m_iaHighScore.Length; i++) {
			m_xaHighScoreText[i].text = m_iaHighScore[i].ToString();
		}

		m_xCurrentScore.text = m_iCurrentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < m_iaHighScore.Length; i++) {
			m_xaHighScoreText[i].text = m_iaHighScore[i].ToString();
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			PlayerPrefs.SetInt("m_iScore", m_iCurrentScore);
			Application.LoadLevel("Scene_01");
		}
	}
}