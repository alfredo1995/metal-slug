using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOMBA_EXPLODE : MonoBehaviour {

	[SerializeField]
	private bool colidiu = false;
	[SerializeField]
	private float raio;
	[SerializeField]
	private LayerMask layer;
	[SerializeField]
	private GameObject animBomba;
    [SerializeField]
    private AudioSource bombaSom;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(colidiu)
		{            
			Instantiate (animBomba,transform.position,Quaternion.identity);
            Instantiate(bombaSom, transform.position, Quaternion.identity);
            Destroy (gameObject);
		}

	}

	void FixedUpdate () {

		colidiu = Physics2D.OverlapCircle (transform.position, raio, layer);
        
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, raio);
	}

}
