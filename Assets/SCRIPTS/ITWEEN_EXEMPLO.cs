using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITWEEN_EXEMPLO : MonoBehaviour {

	// Use this for initialization
	void Start () {

		iTween.MoveTo (gameObject,iTween.Hash("x",0,"y",10,"time",2,"looptype",iTween.LoopType.pingPong,"easetype",iTween.EaseType.easeInOutElastic));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
