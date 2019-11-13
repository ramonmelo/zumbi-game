using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float StopDistance = 1;
    public AudioClip deathClip;

    //private Rigidbody rb;
    private MovingCharacter motor;
    private PlayerController player;

    private Vector3 dir;
    private Animator animator;
    private const string AnimationAtack = "Atack";
    private const string TargetPlayer = "Player";

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(TargetPlayer).transform;
        player = target.GetComponent<PlayerController>();

        motor = GetComponent<MovingCharacter>();

        animator = GetComponent<Animator>();
        animator.SetBool(AnimationAtack, false);

        transform.GetChild(Random.Range(1, 28)).gameObject.SetActive(true);
    }

    void Update()
    {
        dir = target != null ? (target.position - transform.position) : Vector3.positiveInfinity;
    }

    void FixedUpdate()
    {
        if (target == null || dir == Vector3.zero) { return; }

        motor.Rotate(dir);

        if (dir.magnitude > StopDistance)
        {
            motor.Move(dir.normalized);
            animator.SetBool(AnimationAtack, false);
        }
        else
        {
            animator.SetBool(AnimationAtack, true);
        }
    }

    private void OnDestroy()
    {
        AudioController.instance.PlayOneShot(this.deathClip);
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