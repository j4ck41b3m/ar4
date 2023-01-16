using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject explosion, controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Controller");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.CompareTag("plane"))
        {
            Debug.Log("Choca con plano");
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            controller.GetComponent<Disparador>().Daño();
            Destroy(gameObject);
        }
    }
}
