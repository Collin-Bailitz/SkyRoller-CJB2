using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float forwardSpeed = 8f;
    float sideSpeed = 6f;

    Rigidbody rb;

    Vector2 moveInput;

    float currentSideInput;
    float sideVelocity;

    float originalForwardSpeed;

    bool reverseControls;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalForwardSpeed = forwardSpeed;
    }

    public void ActivateSpeedBoost(float boostSpeed, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(boostSpeed, duration));
    }

    private IEnumerator SpeedBoostRoutine(float boostSpeed, float duration)
    {
        forwardSpeed = boostSpeed;
        yield return new WaitForSeconds(duration);
        forwardSpeed = originalForwardSpeed;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void ActivateReverseControls(float duration)
{
    StartCoroutine(ReverseControlsRoutine(duration));
}

private IEnumerator ReverseControlsRoutine(float duration)
{
    reverseControls = true;
    yield return new WaitForSeconds(duration);
    reverseControls = false;
}

    void FixedUpdate()
    {   

        float horizontalInput = reverseControls ? -moveInput.x : moveInput.x;

        currentSideInput = Mathf.SmoothDamp(
            currentSideInput,
            horizontalInput,
            ref sideVelocity,
            0.1f
            );
        
        Vector3 movement = new Vector3(
            currentSideInput * sideSpeed,
            rb.linearVelocity.y,
            forwardSpeed
        );

        rb.linearVelocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
