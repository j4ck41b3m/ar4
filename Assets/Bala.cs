using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Bala : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
            Debug.Log("Detecto Colision");
            if (other.transform.tag == "enemigo")
            {
                Destroy(other.transform.gameObject);
                Debug.Log("Destruyo Enemigo");
                Instantiate(explosion, other.transform.position, other.transform.rotation);
                
            }
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }


}
