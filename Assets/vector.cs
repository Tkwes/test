using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vector : MonoBehaviour
{
    public GameObject[] waypoints; //list do gameobjet dos pontos 
     int currentWP = 0; //ultimo ponto passado 
    public float speed = 1.0f; // velocidade  de aceleração 
    public float accuracy = 1.0f; //precisao de encontro com os ponto 
    public float rotSpeed = 0.4f;
     
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint"); //procura o obj chamado waypoint
    }

    void LateUpdate()
    {
        if (waypoints.Length == 0) return; // retorna o valor
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z); //direciona o objeto para o waypoint
        Vector3 direction = lookAtGoal - this.transform.position; // 
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed); // velocidade dee rotaçao;
        if (direction.magnitude < accuracy) // calculo de precisao e ponto que se enconta 
        { 
            currentWP++; 
            if (currentWP >= waypoints.Length) 
            { 
             currentWP = 0;
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime); //velocidade do obj para o way
    }
}
