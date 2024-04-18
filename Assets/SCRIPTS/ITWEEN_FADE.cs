using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ITWEEN_FADE : MonoBehaviour {


   
	// Use this for initialization
	void Start () {

		StartCoroutine ("EfeitoAlpha");
    }	


	IEnumerator EfeitoAlpha()
	{
		yield return new WaitForSeconds (2);
		iTween.FadeTo(gameObject,iTween.Hash("alpha",0,"delay",0.01f,"time",0.02f,"looptype",iTween.LoopType.pingPong,"easetype",iTween.EaseType.easeInElastic));
	}

}
