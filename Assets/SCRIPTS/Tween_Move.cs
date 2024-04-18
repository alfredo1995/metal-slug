using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tween_Move : MonoBehaviour {

	[SerializeField]
	private Button btn;
	[SerializeField]
	private Text txtBtn;
	[SerializeField]
	private int duract;
	[SerializeField]
	private float pos;
	[SerializeField]
	private float startPosX;

	// Use this for initialization
	void Start () {
		startPosX = transform.position.x;
		btn = GetComponent<Button> ();
		txtBtn = GetComponentInChildren<Text> ();

		MoveCima ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.A))
		{
			
			StartCoroutine(MoveBaixo(0.1f));
		}

		if(Input.GetKeyDown(KeyCode.B))
		{
			MoveCima();
		}



	}

	void MoveCima()
	{
		btn.enabled = true;
		btn.image.enabled = true;
		txtBtn.enabled = true;
		btn.image.DOFade (1, 1);
		txtBtn.DOFade (1, 1);

		//Mover
		btn.GetComponent<RectTransform>().DOAnchorPosY(pos,duract,true);
	}

	IEnumerator MoveBaixo(float temp)
	{

		while(btn.image.color.a > 0.01f)
		{
			yield return new WaitForSeconds (temp);
			btn.image.DOFade (0, 1);
			txtBtn.DOFade (0, 1);

			//Mover
			btn.GetComponent<RectTransform>().DOMoveY(-startPosX,duract,true);

		}
		btn.enabled = false;
		btn.image.enabled = false;
		txtBtn.enabled = false;
	}
}
