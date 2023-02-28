using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public float speed; //velocidad de movimiento
	public float minX; //punto maximo de movimiento por la izquierda
	public float maxX; //punto maximo de movimiento por la derecha
	public float waitingTime; //tiempo de pausa antes del cambio de dirección.

	private GameObject _target; //objetivo hacia el que el enemigo se movera
	private Animator _animator;
	private Weapon_02 _weapon;


    void Awake() {
		_animator = GetComponent<Animator>();
		_weapon = GetComponentInChildren<Weapon_v02>();
	}

	
	// Start is called before the first frame update
    void Start() {
		UpdateTarget();
		StartCoroutine("PatrolToTarget");
	}

    // Update is called once per frame
    void Update() {}

	private void UpdateTarget()
	{
		// If first time, create target in the left
		if (_target  == null) {
			_target = new GameObject("Target");
			_target.transform.position = new Vector2(minX, transform.position.y);
			transform.localScale = new Vector3(-1, 1, 1);
			return; //evita que se ejecuten el resto de if
		}

		// If we are in the left, change target to the right
		if (_target.transform.position.x == minX) {
			_target.transform.position = new Vector2(maxX, transform.position.y);
			transform.localScale = new Vector3(1, 1, 1);
		}

		// If we are in the right, change target to the left
		else if (_target.transform.position.x == maxX) {
			_target.transform.position = new Vector2(minX, transform.position.y);
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	private IEnumerator PatrolToTarget() //Con IEnumerator se marca una co-rutina. Esta, mueve al enemigo
	{
		//mientras estemos lejos de target
		while(Vector2.Distance(transform.position, _target.transform.position) > 0.05f) { 
			// movamonos hacia el target
			_animator.SetBool(“Idle”, false);

			Vector2 direction = _target.transform.position - transform.position; //vector de direccion
			float xDirection = direction.x; //solo cogemos el eje x porque el y no nos interesa

			transform.Translate(direction.normalized * speed * Time.deltaTime); //aplicamos movimiento

			// IMPORTANT
			yield return null; //sal de la rutina, y vuelve a empezarla desde el proincipio
		}

		// Una vez CASI llegado al target
		Debug.Log("Target reached");
		//ajustamos completamente la posicion del enemigo a la del target (para asegurar)
		transform.position = new Vector2(_target.transform.position.x, transform.position.y); 
		UpdateTarget(); //establecer el nuevo target

		_animator.SetBool(“Idle”, false);

		_animator.SetTrigger("Shoot");


		// El enemigo espera un momento
		Debug.Log("Waiting for " + waitingTime + " seconds");
		yield return new WaitForSeconds(waitingTime); // Llamate otra vez, pero dentro de un rato

		// Una vez pasado el tiempo, se crea el nuevo target
		Debug.Log("Waited enough, let's update the target and move again");
		StartCoroutine("PatrolToTarget"); //volver a empezar la co-rutina
	}

	void CanShoot() {
		if (_weapon != null) {
			_weapon.Shoot();
			//StartCoroutine(_weapon.ShootWithRaycast());
		}
	}
}
