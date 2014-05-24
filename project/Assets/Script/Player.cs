using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip audioJump;
	public AudioClip audioGetTreasure;
	public AudioClip audioMiss;
	AudioSource audioSource;


	public static int GET_POINT = 10;
	public int point = 0;

	public static float STAMINA_MAX = 100.0f;
	public float stamina = 0.0f;
	public float stamina_delta = 0.0f;
	public float stamina_up_y = 0.0f;
	public static float STAMINA_DRAW_SCALE_DEF = 0.4161998f;


	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		stamina = STAMINA_MAX;
		stamina_delta = 2.5f;
		stamina_up_y = -3.135001f;
		point = GET_POINT;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0)){
			if(stamina > 0) {
				stamina -= stamina_delta;
				if(stamina < 0) {
					stamina = 0;
				}
	//			Debug.Log("left");
				int x = 0;
				int y = +50;
				int z = 0;
				this.gameObject.transform.rigidbody2D.AddForce(new Vector3(x, y, z));
			}
		}
		if (Input.GetMouseButtonDown(0)) {
			audioSource.PlayOneShot (audioJump);
		}

		//stamina_up
		if(this.gameObject.transform.position.y < stamina_up_y) {
			stamina = STAMINA_MAX;
		}

		//stamina_draw
		GameObject.Find("stamina_2").transform.localScale = new Vector3(0.4161998f, STAMINA_DRAW_SCALE_DEF*stamina/STAMINA_MAX, 1f);

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
