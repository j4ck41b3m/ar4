using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Disparador : MonoBehaviour
{
    public GameObject arCamera, proyectil, enemigoAl, bomb;
    public GameObject[] enemigos;
    float tiempo, tiempoAleatorio, lentoAleatorio;
    public int vidas, score;
    public TextMeshProUGUI vidasTxt, puntosTxt;


    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        tiempoAleatorio = Random.Range(0, 3);
        vidas = 5;

    }

    void CrearEnemigo()
    {
        Debug.Log("enemigo creado");
        Vector3 posicionEnemigo = new Vector3(Random.Range(-5,5), Random.Range(3, 4), Random.Range(3, 8));
         GameObject enemy =  Instantiate(enemigoAl, posicionEnemigo, Quaternion.Euler(0,Random.Range(0,359), 0));
       
    }

    void CrearBomba()
    {
        Vector3 posicionBomba = new Vector3(Random.Range(-5, 5), Random.Range(3, 4), Random.Range(3, 8));
        Instantiate(bomb, posicionBomba, Quaternion.Euler(0, Random.Range(0, 359), 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <= 0)
        {
            SceneManager.LoadScene(0);
        }
        Physics.gravity = new Vector3(0, -0.1f, 0);
        tiempoAleatorio -= Time.deltaTime;
        if (tiempoAleatorio <= 0)
        {
            CrearEnemigo();
            tiempoAleatorio = Random.Range(3, 9);
        }

        lentoAleatorio -= Time.deltaTime;
        if (lentoAleatorio <= 0)
        {
            CrearBomba();
            lentoAleatorio = Random.Range(6, 10);
        }


       /* if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GameObject nuevaBala = Instantiate(proyectil, arCamera.transform.position, arCamera.transform.rotation) as GameObject;
            nuevaBala.GetComponent<Rigidbody>().AddForce(arCamera.transform.forward * 2000);
          
        }*/
        

    }

    public void Daño()

    {
        vidas--;


    }

    public void puntos()
    {
        score++;
    }

    public void Sethud()
    {
        vidasTxt.text = vidas.ToString();
        puntosTxt.text = score.ToString();
    }

    public void Shoot()
    {
        GameObject nuevaBala = Instantiate(proyectil, arCamera.transform.position, arCamera.transform.rotation) as GameObject;
        nuevaBala.GetComponent<Rigidbody>().AddForce(arCamera.transform.forward * 2000);
    }
}
