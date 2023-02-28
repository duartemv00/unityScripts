using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// 1. Getting mouse button events
        if (Input.GetMouseButtonDown(0)) {
			Debug.Log("We can use this to make a player attack. It only gets called once");
		}
		if (Input.GetMouseButton(0)) {
			Debug.Log("We are pressing down the button and this will be called until it is released");
		}
		if (Input.GetMouseButtonUp(0)) {
			Debug.Log("We've just released the button!");
		}

		// 1.1 By the way, you can change the number "0" for other numbers
		// 			"1" is the right button
		// 			"2" is the middle button


		// 2. Getting keyboard button events
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("Using KeyCode. We can use this to make a player jump for example. It only gets called once");
		}

		// 2.1. Remember that you can use GetKeyDown, GetKey, GetKeyUp as well

		// 2.2. Unity recomends use GetButton (configure your input in EDIT/PROJECT SETTINGS/ INPUT
		if (Input.GetButtonDown("Jump")) {
			Debug.Log("Using Jump. We can use this to make a player jump for example. It only gets called once");
		}



		// 3. Getting axis for movement
		float horizontal = Input.GetAxis("Horizontal"); // Values from -1f to 1f
		float vertical = Input.GetAxis("Vertical"); 	// Values from -1f to 1f

		if (horizontal < 0f || horizontal > 0f) {
			Debug.Log("Horizontal axis is " + horizontal);
		}
		if (vertical < 0f || vertical > 0f) {
			Debug.Log("Vertical axis is " + vertical);
		}
	}
}
