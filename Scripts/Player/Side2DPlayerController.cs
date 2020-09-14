using System;
using System.Linq;
using UnityEngine;

namespace UnityKit {

public class Side2DPlayerController : MonoBehaviour {
	private static readonly int doWalkParam = Animator.StringToHash("DoWalk");
	private static readonly int velocityYParam = Animator.StringToHash("VelocityY");
	private static readonly int isOnGroundParam = Animator.StringToHash("IsOnGround");
	private static readonly int dieParam = Animator.StringToHash("Die");

	[SerializeField] private GameStateAcesser gameStateAcesser;
	[SerializeField] private PhysicsMaterial2D groundMaterial;
	[SerializeField] private float jumpForce;
	[SerializeField] private float speed;

	// *** Pacman Bounds
	// [SerializeField] private RectTransform screenBounds;
	// [SerializeField] private float screenBoundOffset;
	// private float screenHalf;

	private new Transform transform;
	private new Rigidbody2D rigidbody;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private bool isOnGround;
	
	// Emulated inputs
	public bool isRightPressed { get; set; }
	public bool isLeftPressed { get; set; }
	public bool isUpPressed { get; set; }

	private void Awake() {
		transform = GetComponent<Transform>();
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Start() {
		// *** Pacman Bounds
		// screenHalf = screenBounds.lossyScale.x * screenBounds.rect.width / 2;
	}

	private void Update() => animator.SetFloat(velocityYParam, rigidbody.velocity.y);
	private void FixedUpdate() => inputProcessing();

	private void inputProcessing() {
		float movement = 0f;

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || isLeftPressed) movement += -speed;
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || isRightPressed) movement += speed;

		// If movement required
		if (Math.Abs(movement) > 0.01f) {
			animator.SetBool(doWalkParam, true);
			transform.Translate(movement * Time.deltaTime * Vector2.right);
			spriteRenderer.flipX = movement < 0;

			// *** Pacman Bounds
			// if (transform.position.x >= screenHalf - screenBoundOffset) {
			// 	Vector3 pos = transform.position;
			// 	transform.position = new Vector3(-screenHalf + screenBoundOffset, pos.y, pos.z);
			// } else if (transform.position.x <= -screenHalf + screenBoundOffset) {
			// 	Vector3 pos = transform.position;
			// 	transform.position = new Vector3(screenHalf - screenBoundOffset, pos.y, pos.z);
			// }
		}
		else animator.SetBool(doWalkParam, false);

		// Jump check
		if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || isUpPressed) 
			&& isOnGround && Math.Abs(rigidbody.velocity.y) < 1f) {
			rigidbody.AddForce(Vector2.up * jumpForce);
		}
	}

	private void OnCollisionStay2D(Collision2D other) {
		// Ground collisions
		if (!other.collider.sharedMaterial.Equals(groundMaterial)) return;
		
		// Set onGround based on collision normals
		if (!other.contacts.Any(contact => Math.Abs(contact.normal.x) < 0.05f)) return;
		if (other.contacts.Any(contact => Math.Abs(contact.normal.y - 1f) < 0.05f)) setOnGround(true);
		if (!other.contacts.Any(contact => Math.Abs(contact.normal.y + 1f) < 0.05f) || !isOnGround) return;
		if (gameStateAcesser.getCurrentGameState() == GameStateAcesser.GameState.OutGame) return;
			
		animator.SetBool(dieParam, true);
		gameStateAcesser.notifyGameEnded();
	}

	private void OnCollisionExit2D(Collision2D other) {
		// If player is no longer colliding with ground
		if (other.collider.sharedMaterial.Equals(groundMaterial)) 
			setOnGround(false);
	}

	private void setOnGround(bool state) {
		isOnGround = state;
		animator.SetBool(isOnGroundParam, state);
	}
}

}