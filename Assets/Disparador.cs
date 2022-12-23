using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject arCamera, proyectil, enemigoAl;
    public GameObject[] enemigos;
    float tiempo, tiempoAleatorio;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        tiempoAleatorio = Random.Range(0, 3);
    }

    void CrearEnemigo()
    {
        Debug.Log("enemigo creado");
        Vector3 posicionEnemigo = new Vector3(Random.Range(-5,5), Random.Range(3, 4), Random.Range(3, 8));
        Instantiate(enemigoAl, posicionEnemigo, Quaternion.Euler(0,Random.Range(0,359), 0));
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -0.1f, 0);
        tiempoAleatorio -= Time.deltaTime;
        if (tiempoAleatorio <= 0)
        {
            CrearEnemigo();
            tiempoAleatorio = Random.Range(0, 3);
        }


        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GameObject nuevaBala = Instantiate(proyectil, arCamera.transform.position, arCamera.transform.rotation) as GameObject;
            nuevaBala.GetComponent<Rigidbody>().AddForce(arCamera.transform.forward * 2000);
          
        }

    }
}
