using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.XR;

public class Bala : MonoBehaviour
{
    public GameObject explosion, explosion2, controlador;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroya", 2f);
        controlador = GameObject.Find("Controller");

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
            controlador.GetComponent<Disparador>().puntos();

            Destroy(other.transform.gameObject);
                Debug.Log("Destruyo Enemigo");
            Instantiate(explosion, other.transform.position, other.transform.rotation);
                Invoke("Destroya", 0.1f);

            }
            else if (other.CompareTag("bomb"))
            {
               controlador.GetComponent<Disparador>().Daño();

            Destroy(other.transform.gameObject);
                Instantiate(explosion2, other.transform.position, other.transform.rotation);
                Invoke("Destroya", 0.1f);
 
            }

    }

    public void Destroya()
    {
        Destroy(gameObject);
    }


}
