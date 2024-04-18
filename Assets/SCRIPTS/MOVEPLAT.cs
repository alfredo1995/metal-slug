using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEPLAT : MonoBehaviour {

	// Use this for initialization
	void Start () {

        iTween.MoveTo(gameObject,iTween.Hash("y",-1.36,"delay",2,"looptype",iTween.LoopType.pingPong,"time",5));

	}


}
