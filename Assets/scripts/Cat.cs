using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

    // public Vector2 maxVelocity = new Vector2(3, 5);

    // private PlayerKeyboardController controller;
    private Rigidbody2D rigidbody2d;
    private bool dragging;
    private Vector2 startMousePosition;
	private bool onGround;
	// Use this for initialization
    void Start() {
        // controller = GetComponent<PlayerKeyboardController>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.drag = 0;
		onGround = true;
    }

	// Update is called once per frame
	void Update () {
        if (UnityEngine.Input.GetMouseButton(0)) {
            if (!dragging) {
                dragging = true;
				startMousePosition = Input.mousePosition;
            }
		// Mouse not clicked
		} else  {

			if (dragging && onGround) {
				Vector3 mousePosition = Input.mousePosition;
				Vector2 endMouse = new Vector2(mousePosition.x, mousePosition.y);
				Vector2 difference = startMousePosition - endMouse;
				//            print(difference);
				rigidbody2d.AddForce(difference);
				onGround = false;
			
			}
			dragging = false;



//            print(force);

        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11, 11), transform.position.y, 0);
//        print(transform.position.x);
//		print (rigidbody2d.velocity);


	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "stoneCenter") {
			rigidbody2d.velocity = new Vector2 (0, 0);
			print ("collided");
			onGround = true;
		}
				
}
}