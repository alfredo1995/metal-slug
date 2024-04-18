using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



[System.Serializable]
public class InfosChar
{    
    public float puloMenorY = 6.0f, puloMaiorY = 2;    
    public bool face = true;
    public float maxSpeed = 5f;
    public float move;
    public bool nochao;
    public Transform nochaoCheck;
    public float nochaoRaio = 0.02f;
    public LayerMask oqueEChao;
    public float jumpForce = 5f;
    public Rigidbody2D rb;

    //JOY
    public JoyControl joyC;
     
    //btn
    public Button pulo,tiro;


}

public abstract class CLASSEPAI_HERO : MonoBehaviour {

    public InfosChar infChar;

	public Vector2 direcaoH;
	//private WaitForSeconds tempo = new WaitForSeconds (1);

    // Use this for initialization
    public virtual void  Start () {
        
        infChar.pulo = GameObject.FindWithTag("pulo").GetComponent<Button>();
        infChar.pulo.onClick.AddListener(Pulo);

        infChar.tiro = GameObject.FindWithTag("tiro").GetComponent<Button>();
        infChar.tiro.onClick.AddListener(Tiro);

		direcaoH = Vector2.right;

    }


    public abstract void Pulo();
    public abstract void Tiro();


    void FaceMetodo(Transform t)
    {
		
		//novidade
		if (infChar.nochao) {
			if (infChar.move > 0 && !infChar.face) {
				Flip (t);


			} else if (infChar.move < 0 && infChar.face) {
				Flip (t);

			}
		}
    }



    void Flip(Transform obj)
    {
        infChar.face = !infChar.face;
        Vector3 tempScale = obj.localScale;
        tempScale.x *= -1;
		obj.localScale = tempScale;
    }

    protected void InfosPulo()
    {
        infChar.nochao = Physics2D.OverlapCircle(infChar.nochaoCheck.position, infChar.nochaoRaio, infChar.oqueEChao);

        if (infChar.rb.velocity.y < 0)
        {
            infChar.rb.gravityScale = infChar.puloMenorY;

        }
        else if (infChar.rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            infChar.rb.gravityScale = infChar.puloMaiorY;

        }
        else
        {
            infChar.rb.gravityScale = 1;
        }
       

       infChar.rb.velocity = new Vector2(infChar.move * infChar.maxSpeed, infChar.rb.velocity.y);


        FaceMetodo(transform);
    }

    private void Update()
    {
        
    }

    /*public void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.CompareTag("vilao"))
		{
            if(transform.localScale.x == col.transform.localScale.x)
            {
                if(transform.position.x < col.transform.position.x)
                {
                    direcaoH = transform.localScale * -1;
                }
                else
                {
                    direcaoH = transform.localScale * 1;
                }
                
            }
            else if(transform.localScale.x == col.transform.localScale.x && transform.position.x > col.transform.position.x)
            {
                direcaoH = transform.localScale * 1; //transform.localScale * (-1);
            }

            
			KnockBack (-1.5f * direcaoH.x);
			SendMessage ("Dano",1);
		}
	}

	void KnockBack(float poder)
	{
		iTween.MoveBy (gameObject,new Vector3(poder,0,0),0.3f);
		iTween.ColorTo (gameObject, iTween.Hash ("g", 0, "b", 0, "time", 0.05f, "looptype", iTween.LoopType.pingPong,"oncomplete","ParaEfeito"));
	}

	void VoltaCor()
	{
		iTween.ColorTo (gameObject, iTween.Hash ("color", Color.white, "time", 0.1f));
	}

	IEnumerator ParaEfeito()
	{
		yield return tempo;
		iTween.Stop (gameObject,true);
		VoltaCor ();
	}*/



}
