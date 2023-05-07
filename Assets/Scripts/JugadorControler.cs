using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorControler : MonoBehaviour {


    public float moveSpeed = 3.5f;
    public float jumpForce = 15f;
    private int contador;

    private Rigidbody rb;
    private bool isGrounded;
    private float groundCheckDistance = 1f;
    private Vector3 groundCheckOffset;
    public static bool hasTheKey = false;
    public int maxJumpCount = 2;
    private int currentJumpCount;
    public float diagonalSpeedModifier = Mathf.Sqrt(2);
    public Vector3 startingSpawn;

    void Start() {
        startingSpawn = transform.position;
        rb = GetComponent<Rigidbody>();
        groundCheckOffset = new Vector3(0, -0.5f, 0);
        currentJumpCount = 0;
    }

    void Update() {
        // Check if the player is grounded
        Collider[] colliders = Physics.OverlapSphere(transform.position + groundCheckOffset, groundCheckDistance);
        isGrounded = false;
        foreach (var collider in colliders) {
            if (collider.CompareTag("Suelo")) {
                isGrounded = true;
                currentJumpCount = 0;
                break;
            }
            if (collider.CompareTag("Spike")) {
                GoToSpawn();
                break;
            }
        }



        if (isGrounded) {
            currentJumpCount = 0;
        }

        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Apply movement using Rigidbody
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (moveVertical != 0 && moveHorizontal != 0) {
            movement = movement.normalized * moveSpeed * diagonalSpeedModifier;
        }
        else {
            movement = movement.normalized * moveSpeed;
        }
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Check for jump input and apply jump force if the jump count is less than the maximum allowed
        if (Input.GetButtonDown("Jump") && currentJumpCount < maxJumpCount) {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            currentJumpCount++;
        }
        //If the user falls
        if(transform.position.y < -30f) {

            GoToSpawn();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coleccionable")) {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            Debug.Log("Llevas recogidos" + contador + "colecionables.");
            Scoreboard scoreboard = FindObjectOfType<Scoreboard>();
            scoreboard.SumScore();
            hasTheKey= true;
        }
    }

    void GoToSpawn() {
        transform.position = startingSpawn;
    }
}
