using UnityEngine;

[RequireComponent(typeof(InputDetection))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public PlayerSettings settings;
    [HideInInspector]
    public InputDetection input;

    [HideInInspector]
    public Transform cameraTransform;

    Animator animator;
    CharacterController controller;

    float turnSmoothVelocity;
    float speedSmoothVelocity;

    float currentSpeed;
    float velocityY;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<InputDetection>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 dirInput = input.InputDirection;
        Vector2 dirInputNor = dirInput.normalized;

        bool run = input.RunInput;

        Move(dirInputNor, run);

        float animationSpeedPercent = (run) ? currentSpeed / settings.runSpeed : currentSpeed / settings.walkSpeed * .5f;
        animator.SetFloat("SpeedPercent", animationSpeedPercent, settings.speedSmoothTime, Time.deltaTime);
    }

    void Move(Vector2 inputDir, bool run)
    {
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(settings.turnSmoothTime));
        }
        float targetSpeed = ((run) ? settings.runSpeed : settings.walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothVelocity));

        velocityY += Time.deltaTime * settings.gravity;

        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
            velocityY = 0f;
    }

    float GetModifiedSmoothTime(float smoothTime)
    {
        if (velocityY == 0)
            return smoothTime;

        if (settings.airControlPercent == 0)
            return float.MaxValue;

        return smoothTime / settings.airControlPercent;
    }
}
