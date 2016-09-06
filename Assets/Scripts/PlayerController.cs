using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public Vector2 lastMove;

	private Animator anim;
	private Rigidbody2D playerRigidBody;
	private bool playerMoving;

	private static bool playerExists;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody2D> ();

		// prevent duplication of player
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}


	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		// Update character position
		if (Mathf.Abs(Input.GetAxisRaw ("Horizontal")) > 0.5f) {
			//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidBody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}

		if (Mathf.Abs(Input.GetAxisRaw ("Vertical")) > 0.5f) {
			//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.05f) {
			playerRigidBody.velocity = new Vector2 (0f, playerRigidBody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.05f) {
			playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, 0f);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
