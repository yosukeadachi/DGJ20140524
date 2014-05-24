using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip audioJump;
	public AudioClip audioGetTreasure;
	public AudioClip audioMiss;
	AudioSource audioSource;
	public int point = 10;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0)){
//			Debug.Log("left");
			int x = 0;
			int y = +50;
			int z = 0;
			this.gameObject.transform.rigidbody2D.AddForce(new Vector3(x, y, z));
		}
		if (Input.GetMouseButtonDown(0)) {
			audioSource.PlayOneShot (audioJump);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision2d)
	{
		GameObject go = collision2d.gameObject;
		if(go.tag == "treasure") {
			// スコアコンポーネントを取得してポイントを追加
			FindObjectOfType<Score>().AddPoint(point);
			audioSource.PlayOneShot (audioGetTreasure);
			Destroy(collision2d.gameObject);
		}
		else if(go.tag == "enemy") {
			//
			audioSource.PlayOneShot (audioMiss);
			Destroy(collision2d.gameObject);
			Application.LoadLevel("result");
			FindObjectOfType<Score>().setPrefs();
		}
	}
	
	private void OnCollisionStay2D(Collision2D collision2d)
	{
	}
	
	private void OnCollisionExit2D(Collision2D collision2d)
	{
	}
}
