using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Partier : MonoBehaviour {
	
	public Transform target { get; set; }
	private NavMeshAgent m_agent;

	void Start () {
		m_agent = GetComponent<NavMeshAgent>();

		// TODO: Temporary, use better way of finding the target
		target = GameObject.Find("Target").transform;
	}

	void Update () {
		if (target == null) {
			Debug.LogError("Assign a target");
			return;
		}

		m_agent.destination = target.position;
	}

	void OnDestroy () {
		// Remove this partier from the list
		PartierSpawner.partiers.Remove(this);
	}
}
