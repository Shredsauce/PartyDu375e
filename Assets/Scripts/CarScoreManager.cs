using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarScoreManager : MonoBehaviour {

    public static int coneInPlay;
    public static int chickenInPlay;
    public static int totalObstacle;
    public float timer;
    public float arrivedUser;
    public float coneRemoved;
    public static GameObject[] coneSpawner;
    public static List<GameObject> availableCone = new List<GameObject>();
    public static GameObject[] chickenSpawner;
    public static List<GameObject> availableChicken = new List<GameObject>();
    float coneFrequency=5;
    [SerializeField]
    float coneFrequencyTimer;
    float chickenFrequency = 5;
    float chickenFrequencyTimer;


    // Use this for initialization
    void Start () {
        timer = 375;
        coneSpawner = GameObject.FindGameObjectsWithTag("ConeSpawner");
        chickenSpawner = GameObject.FindGameObjectsWithTag("ChickenSpawner");
        coneFrequencyTimer = 5;
        chickenFrequencyTimer = 5;
    }
	
	// Update is called once per frame
	void Update () {

        timer = timer - Time.deltaTime;

        coneFrequencyTimer = coneFrequencyTimer-Time.deltaTime;
        chickenFrequencyTimer = chickenFrequencyTimer - Time.deltaTime;
        if (coneFrequencyTimer<0)
        {
            coneFrequencyTimer = coneFrequency;
            SpawnCone();
        }

        if (chickenFrequencyTimer < 0)
        {
            chickenFrequencyTimer = chickenFrequency;
            SpawnChicken();
        }
    }

 
    public void SpawnCone()
    {
        availableCone.Clear();
        for (int i =0; i<coneSpawner.Length; i++)
        {
            if (!coneSpawner[i].GetComponent<ConeSpawner>().hasCone)
            {
                availableCone.Add(coneSpawner[i]);
            }
            
        }

        if (availableCone.Count>=1)
        {
            int rng = Random.Range(0, availableCone.Count - 1);
			GameObject coneClone = Instantiate(Resources.Load("Cone"), availableCone[rng].transform.position, Quaternion.identity) as GameObject;
            coneClone.GetComponent<Cone>().spawner = availableCone[rng];
            availableCone[rng].GetComponent<ConeSpawner>().hasCone = true;
            coneInPlay++;
            totalObstacle++;
        }
    }

    public void SpawnChicken()
    {

        availableChicken.Clear();
        for (int o = 0; o < chickenSpawner.Length; o++)
        {
            if (!chickenSpawner[o].GetComponent<ChickenSpawner>().hasChicken)
            {
                availableChicken.Add(chickenSpawner[o]);
            }

        }

        if (availableChicken.Count >= 1)
        {
            int rng1 = Random.Range(0, availableChicken.Count - 1);
            GameObject chickenClone = Instantiate(Resources.Load("Poulet"), availableChicken[rng1].transform.position, Quaternion.identity) as GameObject;
            chickenClone.GetComponent<Chicken>().spawner = availableChicken[rng1];
            availableChicken[rng1].GetComponent<ChickenSpawner>().hasChicken = true;
            chickenInPlay++;
            totalObstacle++;
        }
    }


}
