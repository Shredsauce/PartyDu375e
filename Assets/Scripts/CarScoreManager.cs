
using System.Collections.Generic;
using UnityEngine;


public class CarScoreManager : MonoBehaviour {
	public static CarScoreManager Instance { get; private set; }

    public static int coneInPlay;
    public static int chickenInPlay;
    public static int totalObstacle;
    public Canvas endgame;
    public static float speedPowerUpDown;
    public float timer;
    public static int arrivedUser;
    public float coneRemoved;
    public static float score;
	public static ConeSpawner[] coneSpawner;
	public static List<ConeSpawner> availableCone = new List<ConeSpawner>();
    public static GameObject[] chickenSpawner;
    public static List<GameObject> availableChicken = new List<GameObject>();
    float coneFrequency=5;
    [SerializeField]
    float coneFrequencyTimer;
    float chickenFrequency = 5;
    float chickenFrequencyTimer;

	public Animator anim;

	void Awake () {
		if (Instance != null && Instance != this) {
			Destroy(this.gameObject);
		} else {
			Instance = this;
		}

		anim = GetComponent<Animator>();
	}

    void Start () {
        timer = 375;
		coneSpawner = FindObjectsOfType<ConeSpawner>();
        chickenSpawner = GameObject.FindGameObjectsWithTag("ChickenSpawner");
        coneFrequencyTimer = 5;
        chickenFrequencyTimer = 5;
        speedPowerUpDown = 1;
        score = 0;
        arrivedUser = 0;
    }
	
	void Update () {
        timer = timer - Time.deltaTime;
        if (timer <=0)
        {
            endgame.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        coneFrequencyTimer = coneFrequencyTimer-Time.deltaTime;
        chickenFrequencyTimer = chickenFrequencyTimer - Time.deltaTime;
        if (coneFrequencyTimer<0)
        {
            coneFrequencyTimer = coneFrequency;
            SpawnCone();
            if(speedPowerUpDown> 1) 
            {
                speedPowerUpDown -= 0.1f;
                Mathf.Clamp(speedPowerUpDown, 1, 2);
            }
            else if (speedPowerUpDown < 1)
            {
                speedPowerUpDown += 0.1f;
                Mathf.Clamp(speedPowerUpDown, 0, 0.8f);
            }
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
            if (!coneSpawner[i].GetComponent<ConeSpawner>().HasCone)
            {
                availableCone.Add(coneSpawner[i]);
            }
        }

		if (availableCone.Count >= 1)
		{
			int rng = Random.Range(0, availableCone.Count - 1);
			GameObject coneClone = Instantiate(Resources.Load("Cone"), availableCone[rng].transform.position, Quaternion.identity) as GameObject;
			coneClone.GetComponent<Cone>().spawner = availableCone[rng];
			availableCone[rng].GetComponent<ConeSpawner>().HasCone = true;
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
    public void PowerUpDown(bool upDown)
    {

        if (upDown)
        {
            speedPowerUpDown = speedPowerUpDown * 1.02f;

        }
        else
        {
            speedPowerUpDown= speedPowerUpDown * 0.98f;
        }
    }
}
