using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject weakPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(-0.05f, 0.05f);
        float z = Random.Range(-0.05f, 0.05f);
        transform.Translate(x, 0f, z);
        weakPoint.transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
    }
}
