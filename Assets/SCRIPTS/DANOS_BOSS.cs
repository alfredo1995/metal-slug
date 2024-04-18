using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DANOS_BOSS : MonoBehaviour {

    private bool rodando;
    [SerializeField]
    private int resistencia;
    [SerializeField]
    private GameObject animBomba;


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("bala"))
        {            
            Destroy(col.gameObject);
            Calculo(1);
        }

        else if (col.gameObject.CompareTag("bomba"))
        {
            Instantiate(animBomba, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Calculo(15);
        }
    }


    public void Calculo(int dano)
    {
        
        DanoVisual();
        if (!rodando)
        {
            StartCoroutine("AcabaEfeito");
            rodando = true;
        }
        if (resistencia > 0)
        {
            resistencia -= dano;
        }
        if (resistencia <= 0)
        {
            Destroy(gameObject);
            //GAMEMANAGER.inst.gameover = true;
        }

        if(resistencia <= 0 && gameObject.name != "BOSS_8")
        {
            GAMEMANAGER.inst.gameover = true;
        }
    }

    public void DanoVisual()
    {
        iTween.ColorTo(gameObject, iTween.Hash("r", 1, "g", 0, "b", 0, "time", 0.03f, "looptype", iTween.LoopType.pingPong));
    }

    IEnumerator AcabaEfeito()
    {
        yield return new WaitForSeconds(1);
        iTween.Stop(gameObject, true);
        iTween.ColorTo(gameObject, iTween.Hash("color", Color.white, "time", 0.01f));
        rodando = false;
    }


}
