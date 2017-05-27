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
            car.GetComponent<CarScoreManager>().coneRemoved++;
            CarScoreManager.coneInPlay--;
            CarScoreManager.totalObstacle--;
            CarScoreManager.score++;
            spawner.GetComponent<ConeSpawner>().hasCone = false;
            Destroy(this.gameObject);

//			CarScoreManager.Instance.

        }
    }
}