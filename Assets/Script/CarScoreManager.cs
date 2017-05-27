using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScoreManager : MonoBehaviour {

    public static int coneInPlay;
    public static int partierInPlay;
    public float timer;
    public float arrivedUser;
    public float coneRemoved;
    public GameObject[] coneSpawner;
    public static GameObject[] partierSpawner;

    // Use this for initialization
    void Start () {
        timer = 375;
        coneSpawner= GameObject.FindGameObjectsWithTag("ConeSpawner");
	}
	
	// Update is called once per frame
	void Update () {

        timer = timer - Time.deltaTime;
		
	}


    public void SpawnCone()
    {
        for (int i =0; i< coneSpawner.Length; i++)
        {
            
        }
    }

    public void SpawnPartier()
    {

    }
}
