using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("An object with name " + collision.gameObject.name + " HAS COLLISIONED with me");
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		Debug.Log("An object with name " + collision.gameObject.name + " IS COLLISIONING with me");
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		Debug.Log("An object with name " + collision.gameObject.name + " ISN'T COLLISIONING with me  anymore");
	}
}
