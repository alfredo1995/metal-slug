using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilaoControll : MonoBehaviour {

	private float velMove = 2f;
	private Rigidbody2D rb;
	private bool moveE;
	[SerializeField]
	private Transform[] limite;

	public LayerMask layer;
	private Animator anim;
    [SerializeField]
    private bool visaoV;

    [SerializeField]
    private float raio;
    [SerializeField]
    private LayerMask layerV;
    [SerializeField]
    private SpriteRenderer srender;
    private bool chamado = true;
    private WaitForSeconds tempo = new WaitForSeconds(1);
    [SerializeField]
    private bool pontoAtaque;


    [SerializeField]
    private GameObject animBomba;

    // Use this for initialization
    void Start () {

		Physics2D.IgnoreLayerCollision (12, 12);        
        Physics2D.IgnoreLayerCollision(12, 9);
        Physics2D.IgnoreLayerCollision(12,11);
        Physics2D.IgnoreLayerCollision(12, 13);


        rb = GetComponent<Rigidbody2D> ();
		moveE = true;
		anim = GetComponent<Animator> ();

        srender = GetComponent<SpriteRenderer>();

       
    }


    public KNOCK2 k;
    private WaitForSeconds t = new WaitForSeconds(1);

    

    IEnumerator PersegueH(bool flipx, bool movE)
    {
        
        yield return t;
        srender.flipX = flipx;
        moveE = movE;
       
    }


    private string dir = "esquerda";

	// Update is called once per frame
	void Update () {


        visaoV = Physics2D.OverlapCircle(transform.position, raio, layerV);

        

        if(visaoV)
        {
            var relativeP = transform.InverseTransformPoint(Physics2D.OverlapCircle(transform.position, raio, layerV).gameObject.transform.position);

            if(relativeP.x < 0.0f)
            {               
               

                if (dir == "esquerda")
                {
                    StartCoroutine(PersegueH(false, true));
                    print("corotineE");
                    dir = "direita";
                }
                
                
            }
            else if(relativeP.x > 0.0f)
            {     
                

                if (dir == "direita")
                {
                    StartCoroutine(PersegueH(true, false));
                    print("corotineD");
                    dir = "esquerda";
                }
                
            }
        }

        pontoAtaque = Physics2D.OverlapCircle(transform.position, raio*0.2f, layerV);

        if(!pontoAtaque)
        {
            if (moveE)
            {
                rb.velocity = new Vector2(-velMove, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(velMove, rb.velocity.y);
            }
        }
        else
        {
            anim.Play("VilaoAtacando");
            if(k == null)
            {
                k = Physics2D.OverlapCircle(transform.position, raio * 0.2f, layerV).GetComponent<KNOCK2>();
            }
            k.Danos(Physics2D.OverlapCircle(transform.position, raio * 0.2f, layerV).GetComponent<Collider2D>());
        }
        
		VerificaCol ();

    }


	void VerificaCol()
	{
		if(!Physics2D.Raycast(limite[0].position,Vector2.down,0.1f,layer) && chamado || !Physics2D.Raycast(limite[1].position, Vector2.down, 0.1f, layer) && chamado)
		{
            StartCoroutine("ChamaFlip");          
            
        }
	}

   

    IEnumerator ChamaFlip()
    {

        Flip();
        chamado = false;
        yield return tempo;
        chamado = true;

    }

	void Flip()
	{
		moveE = !moveE;		

		if(moveE)
		{
            srender.flipX = false;
        }
		else
		{
            srender.flipX = true;
        }

		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("bala")||col.gameObject.CompareTag("bomba"))
		{
            
            anim.Play ("VilaoMorrendo");
			Destroy (gameObject,0.1f);
			Destroy (col.gameObject);

            if (GAMEMANAGER.inst.limiteV < 5)
            {
                GAMEMANAGER.inst.limiteV++;
            }
            
        }

        if (col.gameObject.CompareTag("bomba"))
        {
            Instantiate(animBomba, transform.position, Quaternion.identity);
        }
	}
/*
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("bomba"))
        {
            anim.Play("VilaoMorrendo");
            Destroy(gameObject, 0.6f);

            if (GAMEMANAGER.inst.limiteV < 5)
            {
                GAMEMANAGER.inst.limiteV++;
            }
        }
    }
*/
    //novo

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raio);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raio*0.2f);

    }
}
