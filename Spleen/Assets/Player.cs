using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    private Rigidbody playerRb;
    private int jumpCounter = 0;
    private int jumpMax = 2;
    private Vector3 respawnPos;
    private bool playerInput = true;
    public Camera cam;
    private Vector3 respawnPosition = new Vector3(0, 2, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        respawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput)
        {
            transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < jumpMax)
            {
                ++jumpCounter;
                playerRb.AddForce(Vector3.up * jumpForce * (jumpCounter > 1 ? 0.75f : 1f), ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jumpCounter = 0;
            playerInput = true;
        }

        if (collision.gameObject.CompareTag("Hell") || collision.gameObject.CompareTag("Enemy"))
        {
            playerInput = false;
            playerRb.isKinematic = true;
            this.respawn();
        }
    }

    private void respawn()
    {
        playerRb.isKinematic = false;
        cam.transform.position = new Vector3(0, 4, -10);
        transform.localRotation = Quaternion.identity;
        transform.position = respawnPosition;
    }
}
