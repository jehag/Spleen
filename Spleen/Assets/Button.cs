using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Transform teleportTarget;
    public Rigidbody player;
    public Camera cam;

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = teleportTarget.transform.position;
        cam.transform.position = new Vector3(100, 4, -15);
    }
}
