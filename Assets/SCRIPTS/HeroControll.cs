using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroControll : CLASSEPAI_HERO {

    [Header("Variaveis do Player")]
    public Transform carro;
    public Animator animHSup, animHInf;
    
    //Balas
    public GameObject bala;
    public GameObject canoArma;
    //Bombas    
    public GameObject bomba;
    public GameObject localBomba;

    private WaitForSeconds tempo = new WaitForSeconds(0.5f);

    //NOVO AUDIO

    private AudioSource tiros;


    #region
    /*
     * estão no gamemanager
     * 
     *     [SerializeField]
    private Transform boss;
    [SerializeField]
    private Animator barCima, barBaixo;
    [SerializeField]
    private Image joyImg;
        public Flowchart fungus;
    public GameObject[] uiElementos;
    public int execUmavez = 0;
    private WaitForSeconds t;
   */

#endregion
    //

    // Use this for initialization
    void Start() {

        base.Start();
        infChar.rb = GetComponent<Rigidbody2D>();

        #region
        /*
         * ESTA NO GAMEMANAGER
         * 
        t = new WaitForSeconds(2.5f);

        StartCoroutine("TempoCoroutine");
        */
        #endregion


        tiros = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update() {

        if (GAMEMANAGER.inst.gameEstado == 0)
        {

            if (GAMEMANAGER.inst.personagem == 0)
            {
                //Animação Andar


               infChar.move = infChar.joyC.Hori();
               animHInf.SetFloat("X", Mathf.Abs(infChar.move));


            }

        }
        else
        {
            infChar.move = 0;
            animHInf.SetFloat("X", 0);
        }


        //Animação Pulo

        animHInf.SetFloat("Y", infChar.rb.velocity.y);
        animHSup.SetFloat("Y", infChar.rb.velocity.y);
        animHInf.SetBool("chao", infChar.nochao);
        animHSup.SetBool("chao", infChar.nochao);

        //luta final

        GAMEMANAGER.inst.LutaFinal(transform);

        #region
        /*if (execUmavez == 0)
        {
            if (Vector2.Distance(transform.position, boss.position) < 20)
            {
                GAMEMANAGER.inst.gameEstado = 1;
                barCima.Play("BarAnimCima");
                barBaixo.Play("BarAnimBaixo");

                for (int i = 0; i < uiElementos.Length; i++)
                {
                    uiElementos[i].SetActive(false);
                }                
                
            }

            
        }
        else if(GAMEMANAGER.inst.gameEstado != 0)
        {
            GAMEMANAGER.inst.gameEstado = 0;
            barCima.Play("BarAnimCimaInvers");
            barBaixo.Play("BarAnimBaixoInvers");

            for (int i = 0; i < uiElementos.Length; i++)
            {
                uiElementos[i].SetActive(true);
            }



            //..
            joyImg.rectTransform.anchoredPosition = Vector3.zero;
            JoyControl.inputDir = Vector3.zero;
        }*/
        #endregion


    }

    #region
    /* NO GAMEMANAGER 
     * 
    public void FechaBloco()
    {
        execUmavez = 1;
        StopCoroutine("TempoCoroutine");
        
    }

    //.
    IEnumerator TempoCoroutine()
    {
        while(execUmavez < 1)
        {
            yield return t;
            if (Vector2.Distance(transform.position, boss.position) < 20)
            {                    
                fungus.ExecuteBlock("Start");
            }
            
        }
    

    }
    */
#endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(infChar.nochaoCheck.position, infChar.nochaoRaio);
    }

    private void FixedUpdate()
    {
        if (GAMEMANAGER.inst.gameEstado == 0)
        {
            if (GAMEMANAGER.inst.personagem == 0)
            {
                InfosPulo();
            }
        }

    }

	public override void Pulo()
	{
        if (GAMEMANAGER.inst.gameEstado == 0)
        {
            if (GAMEMANAGER.inst.personagem == 0)
            {
                if (infChar.nochao)
                {
                    infChar.rb.AddForce(new Vector2(0, infChar.jumpForce), ForceMode2D.Impulse);
                    animHInf.SetTrigger("pulo");
                }
            }
        }
 
	}

    public override void Tiro()
    {
        if (GAMEMANAGER.inst.gameEstado == 0)
        {
            if (GAMEMANAGER.inst.personagem == 0)
            {
                // if (infChar.nochao)
                //{
                animHSup.SetTrigger("Tiro");
                GameObject balaInst = Instantiate(bala, canoArma.transform.position, Quaternion.identity) as GameObject;
                balaInst.GetComponent<MoveBala>().Vel *= transform.localScale.x;
                if (!tiros.isPlaying)
                {
                    tiros.Play();
                }
                
                //}
            }
        }

    }

	public  void Bomba()
	{
        if (GAMEMANAGER.inst.gameEstado == 0)
        {
            if (GAMEMANAGER.inst.personagem == 0)
            {
                //if (infChar.nochao)
                //{
                animHSup.SetTrigger("bomba");
                GameObject bombaInst = Instantiate(bomba, localBomba.transform.position, Quaternion.identity) as GameObject;
                bombaInst.GetComponent<Rigidbody2D>().AddForce(new Vector2(12.5f * transform.localScale.x, 8.5f), ForceMode2D.Impulse);
                //}
            }
        }

	}

    //veiculo

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("entrada"))
        {
            carro = col.transform;
            carro.GetComponentInParent<Rigidbody2D>().isKinematic = false;
            GAMEMANAGER.inst.personagem = 1;
            transform.SetParent(carro,true);
			transform.localPosition = new Vector2 (0, 0);
            transform.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }



    void VoltaCor()
    {
        iTween.ColorTo(gameObject, iTween.Hash("color", Color.white, "time", 0.01f));
    }

    IEnumerator ParaEfeito()
    {        
        yield return tempo;
        iTween.Stop(gameObject, true);
        VoltaCor();

    }

}






