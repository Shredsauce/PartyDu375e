using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Partier : MonoBehaviour {
	
	private NavMeshAgent m_agent;
	[SerializeField]
	private Transform target;

	void Start () {
		m_agent = GetComponent<NavMeshAgent>();
	}

	void Update () {
		if (target == null) {
			Debug.LogError("Assign a target");
			return;
		}

		m_agent.destination = target.position;
	}
}
