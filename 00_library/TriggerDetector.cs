using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Another collider with name " + other.gameObject.name + " HAS ENTERED in my area");
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log("Another collider with name " + other.gameObject.name + " IS in my area");
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Another collider with name " + other.gameObject.name + " HAS LEFT my area");
	}
}
