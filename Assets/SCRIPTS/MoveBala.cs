using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBala : MonoBehaviour {

	private float vel = 45;

	public float Vel{

		get{return vel; }
		set{vel = value; }
	}

	[SerializeField]
	private Transform lf, lt;

	void Start()
	{
		lf = GameObject.FindWithTag ("lf").GetComponent<Transform>();
		lt = GameObject.FindWithTag ("lt").GetComponent<Transform>();
	}


	void Move()
	{
		Vector3 aux = transform.position;
		aux.x += vel * Time.deltaTime;
		transform.position = aux;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();

		/*if(transform.position.x > lf.position.x || transform.position.x < lt.position.x)
		{ 
			Destroy (gameObject);
		}*/

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("lf") || col.gameObject.CompareTag("lt"))
		{
			Destroy (gameObject);
		}
	}
}
