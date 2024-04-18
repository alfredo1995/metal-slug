using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeiculoControll : CLASSEPAI_HERO
{   
	[Header("Variaveis do Veiculo")]
    //Balas
    public GameObject bala;
    public GameObject canoArma;
    private AudioSource tiros;
    // Use this for initialization
    void Start()
    {

        base.Start();
        infChar.rb = GetComponent<Rigidbody2D>();
        tiros = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GAMEMANAGER.inst.personagem == 1)
        {

            if(Input.GetKeyDown(KeyCode.G))
            {
               // GAMEMANAGER.inst.QuebraParentesco();                 
            }
            //Animação Andar

            if (infChar.nochao)
            {
               infChar.move = infChar.joyC.Hori();
            }

        }


        //luta final

        if (GAMEMANAGER.inst.gameEstado == 0)
        {

            if (GAMEMANAGER.inst.personagem == 1)
            {
                infChar.move = infChar.joyC.Hori();
            }
        }
        else
        {
            infChar.move = 0;           
        }

        //luta final

        GAMEMANAGER.inst.LutaFinal(transform);
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(infChar.nochaoCheck.position, infChar.nochaoRaio);
    }

    private void FixedUpdate()
    {
        if (GAMEMANAGER.inst.personagem == 1)
        {     

           InfosPulo();          

        }
    }

   

    public override void Pulo()
    {
        if (GAMEMANAGER.inst.personagem == 1)
        {
            if (infChar.nochao)
            {
                infChar.rb.AddForce(new Vector2(0, infChar.jumpForce), ForceMode2D.Impulse);                
            }
        }
    }

    public override void Tiro()
    {
        if (GAMEMANAGER.inst.personagem == 1)
        {
            if (infChar.nochao)
            {               
                GameObject balaInst = Instantiate(bala, canoArma.transform.position, Quaternion.identity) as GameObject;
                balaInst.GetComponent<MoveBala>().Vel *= -transform.localScale.x;
                if (!tiros.isPlaying)
                {
                    tiros.Play();
                }
            }
        }
    }

}
