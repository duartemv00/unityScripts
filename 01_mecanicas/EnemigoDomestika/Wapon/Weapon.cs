using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab; //de esta forma puedes arrastrar un prefab a la propiedad piblica.
	public GameObject shooter; //lo mismo con esta otra propiedad

	public GameObject explosionEffect;
	public LineRenderer lineRenderer;

	private Transform _firePoint; //variable donde almacenaremos la posicion del "punto de fuego"



	void Awake()
	{
		_firePoint = transform.Find("FirePoint"); //almacenanos componente transform del objeto FirePoint
	}

	// Start is called before the first frame update
	void Start()
    {
		//Invoke("Shoot", 1f); //invocar un método con el tiempo que quieres que pase antes de la llamada
		//Invoke("Shoot", 2f);
		//Invoke("Shoot", 3f);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Shoot()
	{
		if (bulletPrefab != null && _firePoint != null && shooter != null) { //evitar que se ejecute tontamente
			//crear una instancia del objeto referenciado en bulletPrefab
			GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;

			Bullet bulletComponent = myBullet.GetComponent<Bullet>();

			if (shooter.transform.localScale.x < 0f) {
				// Left
				bulletComponent.direction = Vector2.left; // new Vector2(-1f, 0f)
			} else {
				// Right
				bulletComponent.direction = Vector2.right; // new Vector2(1f, 0f)
			}
		}
	}

	public IEnumerator ShootWithRaycast() {
		
		if (explosionEffect!= null && lineRenderer != null) {

			RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right); //info sobre lo que se encuentra el rayo en su camino

			if (hitInfo) { //Si el Raycast colisiona con un collider
				//Example code
				//if (hitInfo.collider.tag == "Player") {
				//	Transform player = hitInfo.transform;
				//	player.GetComponent<PlayerHealth>().ApllyDamage(5);
				//}

				// Instantiate explosion on hit poiny
				Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);

				// Set line renderer
				lineRenderer.SetPosition(0, _firePoint.position); //posicion del punto 0 (inicio de la linea)
				lineRenderer.SetPosition(1, hitInfo.point); //posición del punto 1 (final de la linea)
			} else { //si la bala no toca nada, la linea sigue avanzando hasta el infinito (o casi)
				lineRenderer.SetPosition(0, _firePoint.position);
				lineRenderer.SetPosition(1, hitInfo.point + Vector2.rigth * 100);
			}

			lineRenderer.enabled = true;

			yield return null;

			lineRenderer enabled = false;
		}
	}
}
