using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {
	
    public GameObject car;
    public GameObject spawner;

    // Use this for initialization
    void Start () {
        car = FindObjectOfType<UnityStandardAssets.Vehicles.Car.CarController>().gameObject;
    }
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //When the player car collides with a cone, enter the IF
        if (other.gameObject.tag == "Player")
        {
<<<<<<< HEAD:Assets/Script/Cone.cs
            car.GetComponent<CarScoreManager>().coneRemoved += 1;
            CarScoreManager.coneInPlay -= 1;
=======
            car.GetComponent<CarScoreManager>().coneRemoved++;
            CarScoreManager.coneInPlay--;
            CarScoreManager.totalObstacle--;
            spawner.GetComponent<ConeSpawner>().hasCone = false;
>>>>>>> 41b50d3317b3941fbff595a30146045595ae3fdf:Assets/Scripts/Cone.cs
            Destroy(this.gameObject);
        }
    }
}