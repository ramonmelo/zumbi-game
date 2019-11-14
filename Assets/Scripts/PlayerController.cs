using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundMask;
    public int PlayerHealth = 100;

    private MovingPlayer motor;

    private Animator anim;
    private Vector3 dir;

    private const string AnimationRunning = "Running";

    public event Action<int> OnHealthChanged;

    public AudioClip damageClip;

    void Start()
    {
        anim = GetComponent<Animator>();
        motor = GetComponent<MovingPlayer>();
    }

    void Update()
    {
        dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        anim.SetBool(AnimationRunning, dir != Vector3.zero);
    }

    void FixedUpdate()
    {
        motor.Rotate(groundMask);
        motor.Move(dir);
    }

    public void TakeDamage(int demage = 30)
    {
        this.PlayerHealth -= demage;
        AudioController.instance.PlayOneShot(this.damageClip);

        OnHealthChanged?.Invoke(this.PlayerHealth);
    }
}