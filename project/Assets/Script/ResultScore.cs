using UnityEngine;
using System.Collections;

public class ResultScore : MonoBehaviour {
	public static string SCORE_PLAYER_PREF_KEY = "SCORE_PLAYER";
	public static string SCORE_TARGET_PREF_KEY = "SCORE_TARGET";

	// スコアを表示するGUIText
	public GUIText scoreGUIText;
	// targetスコアを表示するGUIText
	public GUIText targetScoreGUIText;
	
	public int player_score = 0;
	public int target_score = 0;
	// Use this for initialization
	void Start () {
		getScore();
	}
	
	// Update is called once per frame
	void Update () {
		// スコアを表示する
		scoreGUIText.text = "Score : " + player_score.ToString ();
		targetScoreGUIText.text = "TargetScore : " + target_score.ToString ();
	}

	/**
	* get score 
	*/
	void getScore() {
		player_score = PlayerPrefs.GetInt(SCORE_PLAYER_PREF_KEY);
		target_score = PlayerPrefs.GetInt(SCORE_TARGET_PREF_KEY);
	}
}
