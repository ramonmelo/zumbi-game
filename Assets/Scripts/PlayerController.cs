using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5;
    public LayerMask groundMask;
    public int PlayerHealth = 100;

    private Animator anim;
    private Rigidbody rb;
    private Vector3 dir;

    private const string AnimationRunning = "Running";

    public event Action<int> OnHealthChanged;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        anim.SetBool(AnimationRunning, dir != Vector3.zero);
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
        {
            Vector3 origin = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = origin - transform.position;

            rb.MoveRotation(Quaternion.LookRotation(direction));
        }

        if (dir != Vector3.zero)
        {
            rb.MovePosition(rb.position + (dir * Speed * Time.fixedDeltaTime));
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void TakeDamage(int demage = 30)
    {
        this.PlayerHealth -= demage;
        OnHealthChanged?.Invoke(this.PlayerHealth);
    }
}