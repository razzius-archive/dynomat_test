using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool standing = true;

	// private PlayerKeyboardController controller;
	private PlayerSerialController controller;

	private Rigidbody2D rigidbody2d;
	private Animator animator;

	void Start() {
		controller = GetComponent<PlayerSerialController>();
		rigidbody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		rigidbody2d.drag = 2;
	}

	void Update () {
		rigidbody2d.AddForce(controller.moving);

		var absVelX = Mathf.Abs (rigidbody2d.velocity.x);

		if (controller.moving.x != 0) {
			animator.SetInteger ("AnimState", 1);
			transform.localScale = new Vector3 (controller.moving.x > 0 ? 1 : -1, 1, 1);
			if (absVelX > 5) {
				animator.SetInteger ("AnimState", 2);
			}
		} else {
			animator.SetInteger ("AnimState", 0);
		}
	}
}
