using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LiftTeleport : MonoBehaviour
{
    [Header("Lift Settings")]
    public Animator fadeAnimator;
    public Transform playerRoot;        
    public Transform cameraTransform;   
    public Transform targetPosition;   
    [Range(0.5f, 7f)] public float moveDuration = 2f;  //Value is in slider
    [Header("UI Settings")]
    public Button gameButton;
    private bool isMoving = false;
    private FPSMovement playerMovement;
    private Rigidbody rb;
    public Image crosshair;
    private bool iscrosshair = false;

    public Action onliftfinished;

    private void Start()
    {
        DisableCrossHair();
        if (playerRoot != null)
        {
            playerMovement = playerRoot.GetComponent<FPSMovement>();
            rb = playerRoot.GetComponent<Rigidbody>();
        }
    }

    // Call this to start lift ascend
    public void StartLift()
    {
        if (isMoving || playerRoot == null || targetPosition == null) return;
        StartCoroutine(MovePlayerSmooth());
        onliftfinished?.Invoke();
    }

    void DisableCrossHair()
    {
        if(crosshair == null)
        {
            Debug.Log("No image found");
        }
        else
        {
            iscrosshair = true;
            crosshair.gameObject.SetActive(false);  //Disappear the crosshair.
        }
        
    }
    void EnableCrossHair()
    {
        if(crosshair == null)
        {
            Debug.Log("No Crosshair image assigned or found");
        }
        else
        {
            iscrosshair = false;
            crosshair.gameObject.SetActive(true); //Appear the crosshair.
        }
    }

    private IEnumerator MovePlayerSmooth()
    {
        isMoving = true;

        if (gameButton != null) gameButton.gameObject.SetActive(false);  //Once the lift ascend starts, we don't need the button
        if (fadeAnimator != null) fadeAnimator.SetTrigger("FadeIn");

        // Disable movement and make Rigidbody kinematic
        if (playerMovement != null) playerMovement.enabled = false;
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Vector3 startPos = playerRoot.position;
        Quaternion startRot = playerRoot.rotation;

        Vector3 endPos = targetPosition.position;
        Quaternion endRot = targetPosition.rotation;

        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);

            playerRoot.position = Vector3.Lerp(startPos, endPos, t);
            playerRoot.rotation = Quaternion.Lerp(startRot, endRot, t);

            yield return null;
        }

        // Snap to exact end position
        playerRoot.position = endPos;
        playerRoot.rotation = endRot;

        // Re-enable physics and movement
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
        if (playerMovement != null) playerMovement.enabled = true;

        isMoving = false;
        EnableCrossHair();
    }
    }

