using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaCX_Quebrada : MonoBehaviour {

	[SerializeField]
	private GameObject cxQuebrada;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("bala"))
		{
			Instantiate (cxQuebrada,transform.position,Quaternion.identity);
			Destroy (gameObject);
			Destroy (col.gameObject);
		}
	}

}
