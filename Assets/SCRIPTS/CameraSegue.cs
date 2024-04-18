using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour {

    public GameObject player;    
    public float camVel = 0.25f; 
    //novo
    public bool segueHeroi;
    //
    public Vector3 velAtual;
	[Range(0, 5)]
	public float ajusteCam = 1;
	Vector3 novaCamPos;

    public static CameraSegue inst;

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        
        segueHeroi = true;
        
    }

    // LateUpdate is called after Update each frame
    void FixedUpdate()
    {        
       if(segueHeroi)
        {			
			if (player.transform.position.x >= transform.position.x) {
				novaCamPos = Vector3.SmoothDamp (transform.position, player.transform.position, ref velAtual, camVel);

				transform.position = new Vector3 (novaCamPos.x, novaCamPos.y + ajusteCam, transform.position.z);

			} else{
				
				novaCamPos = Vector3.SmoothDamp (transform.position, player.transform.position, ref velAtual, camVel);
				transform.position = new Vector3 (transform.position.x, novaCamPos.y+ ajusteCam, transform.position.z);
			}
        }
    }

    public void CamShake()
    {
        iTween.ShakePosition(gameObject,new Vector3(0.8f,0,0),0.3f);
    }
}
