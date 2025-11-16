using UnityEngine;
public class FollowHealthBar : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2f, 0);
    void LateUpdate()
    {
        if (target == null) return;

        // Position above enemy
        transform.position = target.position + offset;

        // Face camera
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180f, 0);
    }
}
