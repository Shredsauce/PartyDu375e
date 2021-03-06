﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {

	[HideInInspector]
	public ConeSpawner spawner;
	[SerializeField]
	private GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        //When the player car collides with a cone, enter the IF
        if (other.gameObject.tag == "Player")
        {
			PickUp ();
        }
    }

	private void PickUp () {
		CarScoreManager.Instance.coneRemoved++;
		CarScoreManager.coneInPlay--;
		CarScoreManager.totalObstacle--;
		CarScoreManager.score++;
		spawner.HasCone = false;
		CarScoreManager.Instance.anim.SetTrigger("pickup");

		StartCoroutine(WaitToDisappear ());
	}

	private IEnumerator WaitToDisappear () {
		yield return new WaitForSeconds(0f);

		GameObject explosionGO = (GameObject)Instantiate(explosion, this.transform.position, Quaternion.identity);
		Destroy(explosionGO, 2f);
		Destroy(this.gameObject);
	}
}