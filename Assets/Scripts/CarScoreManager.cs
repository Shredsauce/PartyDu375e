using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarScoreManager : MonoBehaviour {

    public static int coneInPlay;
    public static int totalObstacle;
    public float timer;
    public float arrivedUser;
    public float coneRemoved;
    public static GameObject[] coneSpawner;
    public static List<GameObject> availableCone = new List<GameObject>();
    public static List<GameObject> partierSpawner = new List<GameObject>();
    public GameObject conePrefab;
    float coneFrequency=5;
    [SerializeField]
    float coneFrequencyTimer;

    // Use this for initialization
    void Start () {
        timer = 375;
        coneSpawner = GameObject.FindGameObjectsWithTag("ConeSpawner");
        coneFrequencyTimer = 5;
    }
	
	// Update is called once per frame
	void Update () {

        timer = timer - Time.deltaTime;

        coneFrequencyTimer = coneFrequencyTimer-Time.deltaTime;
        if (coneFrequencyTimer<0)
        {
            coneFrequencyTimer = coneFrequency;
            SpawnCone();
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
            GameObject coneClone = Instantiate(conePrefab, availableCone[rng].transform.position, Quaternion.identity) as GameObject;
            coneClone.GetComponent<Cone>().spawner = availableCone[rng];
            availableCone[rng].GetComponent<ConeSpawner>().hasCone = true;
            coneInPlay++;
            totalObstacle++;
        }
    }

    
}
