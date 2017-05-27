using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarScoreManager : MonoBehaviour {

    public static int coneInPlay;
    public static int partierInPlay;
    public float timer;
    public float arrivedUser;
    public float coneRemoved;
    public static List<GameObject> coneSpawner;
    public static List<GameObject> availableCone;
    public static List<GameObject> partierSpawner;
    public GameObject conePrefab;

    // Use this for initialization
    void Start () {
        timer = 375;
        coneSpawner.Equals( GameObject.FindGameObjectsWithTag("ConeSpawner"));
        SpawnCone();

    }
	
	// Update is called once per frame
	void Update () {

        timer = timer - Time.deltaTime;
		
	}


    public void SpawnCone()
    {
        availableCone.Clear();
        for (int i =0; i< coneSpawner.Count; i++)
        {
            if (!coneSpawner[i].GetComponent<ConeSpawner>().hasCone)
            {
                availableCone.Add(coneSpawner[i]);
            }
            
        }
        int rng = Random.Range(0, availableCone.Count - 1);

        GameObject coneClone = Instantiate(conePrefab, availableCone[rng].transform) as GameObject;


    }

    public void SpawnPartier()
    {

    }
}
