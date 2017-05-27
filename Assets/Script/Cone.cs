using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {
    private GameObject car;

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
            car.GetComponent<CarScoreManager>().coneRemoved += 1;
            Destroy(this.gameObject);
        }
    }
}


