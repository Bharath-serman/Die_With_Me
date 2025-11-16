using UnityEditorInternal;
using UnityEngine.Audio;
using UnityEngine;
public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 0.1f; // Time between shots (0.1 = 10 bullets/sec)

    [Header("References")]
    public Camera cam;
    public ParticleSystem muzzleflash;
    public AudioSource gunfire;

    private float nextTimeToFire = 0f;

    void Update()
    {
        // Hold down left mouse button for continuous fire
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + fireRate;
                Shoot();
            }
        }
        else if (muzzleflash.isPlaying)
        {
            // Stop flash when not firing
            muzzleflash.Stop();
        }
    }

    void Shoot()
    {
        // Play muzzle flash
        if (!muzzleflash.isPlaying)
            muzzleflash.Play();
            gunfire.Play();

        // Raycast shooting logic
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takedamage(damage);
            }
        }
    }
}
