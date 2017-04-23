using UnityEngine;
using System.Collections;

public class PlayerKeyboardController : MonoBehaviour {

	public float speed = 8f;
	public Vector2 moving = new Vector2();
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update() {
		moving.x = moving.y = 0;

		if (Input.GetKey ("right")) {
			print("R");
			moving.x = speed;
		} else if (Input.GetKey ("left")) {
			moving.x = -speed;
		}

		if (Input.GetKey ("up")) {
			moving.y = 30;
		}
	}
}
