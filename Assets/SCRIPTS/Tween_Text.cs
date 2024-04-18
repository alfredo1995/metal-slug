using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tween_Text : MonoBehaviour {

    [SerializeField]
    private RectTransform txtRect;
    [SerializeField]
    private Text txt;
    [SerializeField]
    private float velF, velS;
    [SerializeField]
    private bool fade, scale;

    // Use this for initialization
    void Start () {
		
        

	}
	
	// Update is called once per frame
	void Update () {
        AnimacaoScala(velF, velS, fade, scale);
    }

    void AnimacaoScala(float velf, float vels, bool fade, bool scale)
    {
        if (scale)
        {
            if (txtRect.localScale.x == 1)
            {
                txtRect.DOScale(new Vector3(1.2f, 1.2f, 1.2f), velS);
            }
            else if (txtRect.localScale.x == 1.2f)
            {
                txtRect.DOScale(new Vector3(1f, 1f, 1f), velS);
            }
        }

        if (fade)
        {
            if (txt.color.a == 1)
            {
                txt.DOFade(0, velF);
            }
            else if (txt.color.a == 0)
            {
                txt.DOFade(1, velF);
            }
        }


    }


  

}
