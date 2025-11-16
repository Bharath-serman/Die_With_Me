using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    [Header("Inputs")]
    public Transform playertransform;
    public Vector3 offset;

    void Update()
    {
        transform.position = playertransform.position + offset;
        //Rotation
        Vector3 rotationangle = new Vector3(90f, playertransform.eulerAngles.y, 0f);

        transform.rotation = Quaternion.Euler(rotationangle);
    }
}
