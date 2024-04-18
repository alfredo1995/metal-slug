using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNOCK2 : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rbPai;
    private Vector2 direcao;    

    // Use this for initialization
    void Start () {

        rbPai = GetComponentInParent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerEnter2D(Collider2D col)
    {

            if (col.gameObject.CompareTag("vilao"))
            {
                Danos(col);
            }
            else if (col.gameObject.CompareTag("letal"))
            {
                Danos(col);
            }

    }

    public void Danos(Collider2D vilao)
    {
        direcao = rbPai.transform.position - vilao.transform.position;
        CameraSegue.inst.CamShake();
        iTween.MoveBy(rbPai.gameObject, iTween.Hash("x", direcao.normalized.x * 2.5f, "time", 0.3f));
        iTween.ColorTo(rbPai.gameObject, iTween.Hash("g", 0, "b", 0, "time", 0.03f, "looptype", iTween.LoopType.pingPong, "oncompletetarget", rbPai.gameObject, "oncomplete", "ParaEfeito"));
        BarraVidaVilao.instance.Dano(1);
    }




}
