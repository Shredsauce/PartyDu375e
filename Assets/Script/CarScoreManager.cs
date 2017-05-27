using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScoreManager : MonoBehaviour {

    public float timer;
    public float arrivedUser;
    public float coneRemoved;

	// Use this for initialization
	void Start () {
        timer = 375;
	}
	
	// Update is called once per frame
	void Update () {

        timer = timer - Time.deltaTime;
		
	}
}
