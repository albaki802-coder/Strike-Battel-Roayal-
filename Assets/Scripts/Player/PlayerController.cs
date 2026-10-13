using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private CharacterController characterController;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpHeight = 1.1f;

    [Header("Look")]
    [SerializeField] private float lookSensitivity = 0.12f;
    [SerializeField] private float maxLookAngle = 80f;

    private Vector2 mobileMove;
    private Vector2 mobileLook;
    private float verticalVelocity;
    private float cameraPitch;
    private bool jumpRequested;

    private void Awake()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();
        if (cameraPivot == null && Camera.main != null)
            cameraPivot = Camera.main.transform;
    }

    private void Update()
    {
        Vector2 move = mobileMove;
#if UNITY_EDITOR || UNITY_STANDALONE
        if (move.sqrMagnitude < 0.001f)
            move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#endif

        Vector2 look = mobileLook;
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButton(1))
            look += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * 4f;
#endif

        Vector3 horizontal = (transform.right * move.x + transform.forward * move.y) * moveSpeed;
        if (characterController.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;

        if (jumpRequested && characterController.isGrounded)
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        jumpRequested = false;
        verticalVelocity += gravity * Time.deltaTime;

        characterController.Move((horizontal + Vector3.up * verticalVelocity) * Time.deltaTime);

        if (cameraPivot != null)
        {
            transform.Rotate(Vector3.up, look.x * lookSensitivity, Space.Self);
            cameraPitch = Mathf.Clamp(cameraPitch - look.y * lookSensitivity, -maxLookAngle, maxLookAngle);
            cameraPivot.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        }

        mobileLook = Vector2.zero;
    }

    // Connect a virtual joystick to this method.
    public void SetMoveInput(Vector2 value) => mobileMove = Vector2.ClampMagnitude(value, 1f);

    // Call while the player drags the look area; pass the drag delta.
    public void AddLookInput(Vector2 delta) => mobileLook += delta;

    // Connect a mobile jump button to this method.
    public void RequestJump() => jumpRequested = true;
}
