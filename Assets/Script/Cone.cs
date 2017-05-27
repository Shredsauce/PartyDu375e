using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {
    public GameObject car;

	// Use this for initialization
	void Start () {
        car = FindObjectOfType<UnityStandardAssets.Vehicles.Car.CarController>().gameObject;
    }
	
	// Update is called once per frame
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


