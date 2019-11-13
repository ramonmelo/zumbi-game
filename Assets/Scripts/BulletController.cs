using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public float Speed = 30;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		Destroy(gameObject, 5);
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + transform.forward * Speed * Time.fixedDeltaTime);
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(other.gameObject);
		}

		Destroy(gameObject);
	}
}