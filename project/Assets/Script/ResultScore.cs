using UnityEngine;
using System.Collections;

public class ResultScore : MonoBehaviour {
	public static string SCORE_PLAYER_PREF_KEY = "SCORE_PLAYER";
	public static string SCORE_TARGET_PREF_KEY = "SCORE_TARGET";

	public int player_score = 0;
	public int target_score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// スコアを表示する
		scoreGUIText.text = "Score : " + score.ToString ();
		targetScoreGUIText.text = "TargetScore : " + targetScore.ToString ();
	}

	/**
	* get score 
	*/
	void getScore() {
		score_player = PlayerPrefs.GetString(SCORE_PLAYER_PREF_KEY);
		target_player = PlayerPrefs.GetString(SCORE_TARGET_PREF_KEY);
	}
}
