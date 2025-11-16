using UnityEngine;
//using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class FPSMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Camera playerCamera;
    public Animator gunAnimator;
    private Rigidbody rb;
    private float rotationX = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
       {
            if (gunAnimator != null)
                gunAnimator.SetTrigger("Fire");
        } 

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX); // Rotate player body
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        if (playerCamera != null)
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
    void FixedUpdate()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move *= moveSpeed;
        move.y = rb.velocity.y; 

        rb.velocity = move;
    }
}
