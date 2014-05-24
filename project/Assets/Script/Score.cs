using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public static string SCORE_PLAYER_PREF_KEY = "SCORE_PLAYER";
	public static string SCORE_TARGET_PREF_KEY = "SCORE_TARGET";

	// スコアを表示するGUIText
	public GUIText scoreGUIText;
	
	// targetスコアを表示するGUIText
	public GUIText targetScoreGUIText;
	
	// スコア
	private int score;
	
	//   target
	private int targetScore;
	
	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		// スコアがtargetスコアより大きければ
		if (targetScore < score) {
			setPrefs();
			Debug.Log ("clear");
			Application.LoadLevel("result");
		}
		
		// スコアを表示する
		scoreGUIText.text = "Score : " + score.ToString ();
		targetScoreGUIText.text = "TargetScore : " + targetScore.ToString ();
	}
	
	// ゲーム開始前の状態に戻す
	private void Initialize ()
	{
		// スコアを0に戻す
		score = 0;
		
		// 
		targetScore = 10;
		setPrefs();
	}
	
	// ポイントの追加
	public void AddPoint (int point)
	{
		score = score + point;
	}


	public void setPrefs()
	{
		PlayerPrefs.SetInt(SCORE_PLAYER_PREF_KEY, score);
		PlayerPrefs.SetInt(SCORE_TARGET_PREF_KEY, targetScore);
	}
}


