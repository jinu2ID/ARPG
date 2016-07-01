﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator anim;
	private bool playerMoving;
	private Vector2 lastMove;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		// Update character position
		if (Mathf.Abs(Input.GetAxisRaw ("Horizontal")) > 0.5f) {
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}

		if (Mathf.Abs(Input.GetAxisRaw ("Vertical")) > 0.5f) {
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			playerMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
