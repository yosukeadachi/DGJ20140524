using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

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
			Debug.Log ("clear");
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
		targetScore = 100;
	}
	
	// ポイントの追加
	public void AddPoint (int point)
	{
		score = score + point;
	}
	
}


