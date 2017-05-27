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
<<<<<<< HEAD:Assets/Scripts/Cone.cs
<<<<<<< HEAD:Assets/Script/Cone.cs
            car.GetComponent<CarScoreManager>().coneRemoved += 1;
            CarScoreManager.coneInPlay -= 1;
=======
=======
>>>>>>> b73e5f5685ae1208a6ebf02ebcee08c0e7357d83:Assets/Scripts/Cone.cs
            car.GetComponent<CarScoreManager>().coneRemoved++;
            CarScoreManager.coneInPlay--;
            CarScoreManager.totalObstacle--;
            spawner.GetComponent<ConeSpawner>().hasCone = false;
<<<<<<< HEAD:Assets/Scripts/Cone.cs
>>>>>>> 41b50d3317b3941fbff595a30146045595ae3fdf:Assets/Scripts/Cone.cs
=======
>>>>>>> b73e5f5685ae1208a6ebf02ebcee08c0e7357d83:Assets/Scripts/Cone.cs
            Destroy(this.gameObject);
        }
    }
}