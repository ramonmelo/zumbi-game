using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundMask;
    public int PlayerHealth = 100;

    private MovingCharacter motor;

    private Animator anim;
    private Vector3 dir;

    private const string AnimationRunning = "Running";

    public event Action<int> OnHealthChanged;

    public AudioClip damageClip;

    void Start()
    {
        anim = GetComponent<Animator>();
        motor = GetComponent<MovingCharacter>();
    }

    void Update()
    {
        dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        anim.SetBool(AnimationRunning, dir != Vector3.zero);
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundMask))
        {
            Vector3 origin = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = origin - transform.position;

            motor.Rotate(direction);
        }

        motor.Move(dir);
    }

    public void TakeDamage(int demage = 30)
    {
        this.PlayerHealth -= demage;
        AudioController.instance.PlayOneShot(this.damageClip);

        OnHealthChanged?.Invoke(this.PlayerHealth);
    }
}