using System.IO;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float stopDistance = 2f;
    private Rigidbody rb;
    public bool canmove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    void FixedUpdate()
    {
        if (!canmove || player == null) return;

        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        Vector3 lookDir = new Vector3(direction.x, 0, direction.z);
        if (lookDir != Vector3.zero)
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(lookDir), Time.fixedDeltaTime * 5f));

        if (distance > stopDistance)
        {
            Vector3 move = transform.forward * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }
}
