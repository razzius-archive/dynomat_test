using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

    // public Vector2 maxVelocity = new Vector2(3, 5);

    // private PlayerKeyboardController controller;
    private Rigidbody2D rigidbody2d;
    private bool mouseDown;
    private Vector2 startMouse;

	// Use this for initialization
    void Start() {
        // controller = GetComponent<PlayerKeyboardController>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.drag = 0;
    }

	// Update is called once per frame
	void Update () {
        if (UnityEngine.Input.GetMouseButton(0)) {
            if (!mouseDown) {
                mouseDown = true;
                Vector3 mousePosition = Input.mousePosition;
                print(mousePosition);
                startMouse = new Vector2(mousePosition.x, mousePosition.y);
            }
        } else if (!UnityEngine.Input.GetMouseButton(0) && mouseDown) {
            mouseDown = false;
            int force = Random.Range(-40, 40);
            print(force);
            Vector3 mousePosition = Input.mousePosition;
            Vector2 endMouse = new Vector2(mousePosition.x, mousePosition.y);
            Vector2 difference = startMouse - endMouse;
            print(difference);
            rigidbody2d.AddForce(2 * difference);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11, 11), transform.position.y, 0);
        print(transform.position.x);
	}
}
