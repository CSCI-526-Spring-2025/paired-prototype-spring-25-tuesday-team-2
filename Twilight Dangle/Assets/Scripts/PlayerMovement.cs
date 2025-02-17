using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 15.0f;  // Increased movement speed
    public float rotationSpeed = 120.0f;  // Rotation speed
    public float jumpForce = 5.0f;
    public GameEventmanager gameManager;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevents tipping over
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // Ensures no wall phasing
        rb.interpolation = RigidbodyInterpolation.Interpolate; // Smoother movement
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Move the player with Rigidbody velocity (prevents skipping walls)
        Vector3 moveDirection = transform.forward * moveVertical * speed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        // Rotate player smoothly while moving
        if (moveHorizontal != 0)
        {
            float turn = moveHorizontal * rotationSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Death"))
        {
            ResetGame();
        }
    }

    private void ResetGame(){
      gameManager.PlayerDied();
    }
}
