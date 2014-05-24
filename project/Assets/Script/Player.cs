using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioClip audioClip1;
	public AudioClip audioClip2;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClip1;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0)){
			audioSource.Play ();
//			Debug.Log("left");
			int x = 0;
			int y = +50;
			int z = 0;
			this.gameObject.transform.rigidbody2D.AddForce(new Vector3(x, y, z));
		}
	}

	private void OnCollisionEnter2D(Collision2D collision2d)
	{
		GameObject go = collision2d.gameObject;
		if(go.tag == "treasure") {
			Destroy(collision2d.gameObject);
		}
	}
	
	private void OnCollisionStay2D(Collision2D collision2d)
	{
	}
	
	private void OnCollisionExit2D(Collision2D collision2d)
	{
	}
}
