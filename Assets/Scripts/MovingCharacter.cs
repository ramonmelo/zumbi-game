using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingCharacter : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Rotate(Vector3 orientation)
    {
        rb.MoveRotation(Quaternion.LookRotation(orientation));
    }

    public void Move(Vector3 dir)
    {
        if (dir != Vector3.zero)
        {
            rb.MovePosition(rb.position + (dir * Speed * Time.fixedDeltaTime));
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
