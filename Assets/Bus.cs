using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Bus : MonoBehaviour {

	private NavMeshAgent m_agent;

	[SerializeField]
	private Transform[] wayPoints;
	[SerializeField]
	private float distanceThreshold = 10f;

	private int currentWayPointIndex = 0;

	void Start () {
		m_agent = GetComponent<NavMeshAgent>();

		// Set first way point as the destination
		m_agent.destination = wayPoints[currentWayPointIndex].position;
	}
	
	void Update () {
		if (wayPoints.Length == 0) {
			Debug.Log("Assign way points PLEASE");
			return;
		}

		if (!m_agent.isOnNavMesh)
			return;

		if (m_agent.remainingDistance < distanceThreshold) {
			// Set the next way point destination
			m_agent.destination = wayPoints[currentWayPointIndex++ % wayPoints.Length].position;
		}
	}
}
