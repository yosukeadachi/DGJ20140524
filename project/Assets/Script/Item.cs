﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter2D(Collision2D collision2d)
	{
		GameObject go = collision2d.gameObject;
		if(go.tag == "Player") {
		}
	}

}
