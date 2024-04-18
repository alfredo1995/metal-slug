using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MATAOBJETOS : MonoBehaviour {

	// Use this for initialization

	[SerializeField]
	private float tempo;

	void Start () {
	
		Destroy (gameObject,tempo);
	}
	

}
