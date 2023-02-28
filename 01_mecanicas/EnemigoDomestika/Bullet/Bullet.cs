using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed; //velocidad de la bala
	public Vector2 direction; //direccion que toma la bala

	public float livingTime; //timepo tras el que la bala desaparece
	public Color initialColor = Color.white;
	public Color finalColor;

	private SpriteRenderer _renderer;
	private float _startingTime;

	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	// Start is called before the first frame update
	void Start()
    {
		//  Save initial time
		_startingTime = Time.time;

		// Destroy the bullet after some time
		Destroy(this.gameObject, livingTime); //destruye el objeto asociado al script tras un tiempo
		//Destroy(GetComponent<SpriteRenderer>(), livingTime); //otra forma igual de funcional
    }

    // Update is called once per frame
    void Update()
    {
		//  Move object
		Vector2 movement = direction.normalized * speed * Time.deltaTime; //Crer vector de movimiento
		transform.Translate(movement); //Aplicar el vector de movimiento al componente Transform

		// Change bullet's color over time
		float _timeSinceStarted = Time.time - _startingTime;
		float _percentageCompleted = _timeSinceStarted / livingTime;

		_renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);
    }
}
