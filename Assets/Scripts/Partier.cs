using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Partier : MonoBehaviour {
	
	public Transform target { get; set; }
	private NavMeshAgent m_agent;
	private Rigidbody rb;
	private Collider coll;

	private IEnumerator dazedCoroutine;

	[SerializeField]
	private float hitMultiplier = 1f;

	void Start () {
		m_agent = GetComponent<NavMeshAgent>();
		rb = GetComponent<Rigidbody>();
		coll = GetComponent<Collider>();
		coll.isTrigger = true;

		// TODO: Temporary, use better way of finding the target
		target = GameObject.Find("Target").transform;
	}

	void FixedUpdate () {
		if (target == null) {
			Debug.LogError("Assign a target");
			return;
		}

		if (m_agent.enabled)
			m_agent.destination = target.position;
	}

	void OnDestroy () {
		// Remove this partier from the list
		PartierSpawner.partiers.Remove(this);
	}

	void OnTriggerEnter (Collider coll) {

		if (coll.tag == "Player") {
			Debug.Log(coll.name);
			Dazed(coll.GetComponentInParent<Rigidbody>());
		}
	}

	private void Dazed (Rigidbody otherRb) {
		if (dazedCoroutine != null) {
			StopCoroutine(_Dazed(otherRb));
		}
		dazedCoroutine = _Dazed (otherRb);
		StartCoroutine(_Dazed(otherRb));
	}

	private IEnumerator _Dazed (Rigidbody otherRb) {
		coll.isTrigger = false;
		m_agent.enabled = false;
		rb.isKinematic = false;

//		Debug.DrawRay(this.transform.position, transform.TransformDirection(otherRb.velocity), Color.red, 5f);

		rb.velocity = otherRb.velocity * hitMultiplier;
//		Debug.Break();

		// TODO random range 
		yield return new WaitForSeconds(3f);

		coll.isTrigger = true;

		m_agent.enabled = true;
		rb.isKinematic = true;
	}
}
