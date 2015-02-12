using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	
	void Start()
	{
	}
	
	void Update()
	{

	}

	public void OnHit() {
		Debug.Log("got hit. dying now.");
		Destroy(gameObject);
	}
	
}