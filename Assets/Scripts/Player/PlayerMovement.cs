using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float playerSpeed = 8f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float maxSpeed = 10f;
    private Rigidbody playerRigidbody;
    private Vector3 playerInput;

    private bool isGrounded = true;
    private float groundDistanceCheck = 1f;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidbody == null) {
            return;
        }

        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        isGrounded = CheckGround();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (playerRigidbody == null) {
            return;
        }

        MovePlayer();
    }

    private void MovePlayer() {
        // if (!isGrounded) {
        //     return;
        // }
        Vector3 movement = playerInput * playerSpeed;

        playerRigidbody.AddForce(movement);
    }

    private void Jump() {
        Vector3 linearVelocity = playerRigidbody.linearVelocity;
        linearVelocity.y = 0f;

        playerRigidbody.linearVelocity = linearVelocity;

        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
    }

    private bool CheckGround() {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundDistanceCheck)) {
            if (hit.collider.CompareTag("Ground")) {
                return true;
            }
        }
        return false;
    }
}
