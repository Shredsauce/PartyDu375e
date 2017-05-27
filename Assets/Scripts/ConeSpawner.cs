using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeSpawner : MonoBehaviour {

    public bool hasCone;

	// Use this for initialization
	void Start () {
        hasCone = false;

    }   // Update is called once per frame
    void Update () {
		
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position,"cone" , true);
    }
}
