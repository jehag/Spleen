using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public GameObject boss;
    public Material mat;
    public GameObject crown;
    private int i ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = Color.black;
        color.r = Mathf.Pow(Mathf.Sin(i++), 2);
        mat.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(boss);
            Destroy(gameObject);
            Instantiate(crown);
            crown.transform.position = new Vector3(100,0,0);
            crown.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            crown.transform.localRotation = new Quaternion(0, -90, -90, 0);
        }
    }
}
