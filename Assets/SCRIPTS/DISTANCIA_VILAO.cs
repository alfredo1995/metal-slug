using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DISTANCIA_VILAO : MonoBehaviour {

    public GameObject vilao;
    public float tempo = 3;
    public bool ativacao;
    public GameObject player;


    private void Update()
    {
        if (ativacao)
        {
            tempo -= Time.deltaTime;

            if (tempo < 0)
            {
                Instantiate(vilao,new Vector2(player.transform.position.x + 25, player.transform.position.y + 1),Quaternion.identity);
                tempo = 3;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("hero") || col.CompareTag("VEICULO"))
        {
            ativacao = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("hero") || col.CompareTag("VEICULO"))
        {
            ativacao = false;
        }
    }

}
