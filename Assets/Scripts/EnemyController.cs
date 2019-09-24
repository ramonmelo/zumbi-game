using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public Transform target;
	public float Speed;
	public float StopDistance = 1;

	private PlayerController player;

	private Rigidbody rb;
	private Vector3 dir;
	private Animator animator;

	private const string AnimationAtack = "Atack";
	private const string TargetPlayer = "Player";

	void Start()
	{
		target = GameObject.FindGameObjectWithTag(TargetPlayer).transform;
		player = GameObject.FindGameObjectWithTag(TargetPlayer).GetComponent<PlayerController>();

		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();

		transform.GetChild(Random.Range(1, 28)).gameObject.SetActive(true);
	}

	void Update()
	{
		dir = target != null ? (target.position - transform.position) : Vector3.positiveInfinity;
	}

	void FixedUpdate()
	{
		if (target == null) { return; }

		rb.MoveRotation(Quaternion.LookRotation(dir));

		if (dir.magnitude > StopDistance)
		{
			rb.MovePosition(rb.position + (dir.normalized * Speed * Time.fixedDeltaTime));
			animator.SetBool(AnimationAtack, false);
		}
		else
		{
			animator.SetBool(AnimationAtack, true);
		}
	}

	void AtackEvent()
	{
		if (dir.magnitude < StopDistance)
		{
			Debug.Log("Atack!");

			int demage = Random.Range(10, 31);
			player.TakeDamage(demage);
		}
	}
}