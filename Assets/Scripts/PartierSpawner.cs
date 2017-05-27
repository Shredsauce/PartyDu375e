using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartierSpawner : MonoBehaviour {
	// Global list of all the partiers
	public static List<Partier> partiers = new List<Partier>();

	// The minimum and maximum amount of time to wait for the next partier to spawn
	[SerializeField]
	private float waitMin = 0.5f;
	[SerializeField]
	private float waitMax = 1f;
	
	void Awake () {
		// TEMPORARILY commented out so that only one partier moves
//		StartCoroutine (WaitToAddPartier());
	}

	// Adds new partiers recursively forever and ever
	private IEnumerator WaitToAddPartier () {
		
		GameObject partierGO = (GameObject)Instantiate(Resources.Load("Partier"));
		Partier partier = partierGO.GetComponent<Partier>();
		partier.transform.position = this.transform.position;
		// Add the partiers to the list
		partiers.Add (partier);

		yield return new WaitForSeconds(UnityEngine.Random.Range(waitMin, waitMax));

		StartCoroutine (WaitToAddPartier());
	}
}
