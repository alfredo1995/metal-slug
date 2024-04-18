using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {

    [SerializeField]
    private GameObject balas;
    [SerializeField]
    private Transform[] pos;
    private int posTiroTemp = 0;

    //novo

    [SerializeField]
    private bool possoAtirar = false;

    public int vida = 100;//
    [SerializeField]
    private float tempAux1;
    [SerializeField]
    private Animator bossAnim;
    [SerializeField]
    private float raio = 5;
    [SerializeField]
    private GameObject[] points;
    [SerializeField]
    private float vel;
    [SerializeField]
    private int atual = 0;
    [SerializeField]
    private Transform Vilao;

    private bool inicio = false;

    //novo

    public static BossControl inst;

    public GameObject cabineTiros;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

           

    }

	// Update is called once per frame
	void Update () {

        if (GAMEMANAGER.inst.gameEstado == 0)
        {

            if (inicio)
            {

                tempAux1 += Time.deltaTime;

                if (vida >= 50)
                {
                    TirosControll(5, 9);//5,9 e 3,9
                }
                else if (vida < 50)
                {
                    TirosControll(0, 9);
                }

                Movimento();
            }
        }

    }


    public void IniciaAtaque()
    {
        inicio = true;
        GAMEMANAGER.inst.bossLuta = true;
    }


    void TirosControll(float t1,float t2)
    {
        if (tempAux1 > 0 && tempAux1 < t1)
        {
            possoAtirar = false;
        }
        else if (tempAux1 >= t1)
        {
            possoAtirar = true;
        }
        if (tempAux1 > t2)
        {
            tempAux1 = 0;
        }
    }

    //novo
    public void Atira()
    {
        if (cabineTiros != null)
        {
            if (possoAtirar == true)
            {
                GameObject newBala;
                newBala = (GameObject)Instantiate(balas, pos[posTiroTemp].position, Quaternion.identity);
                newBala.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 10), ForceMode2D.Impulse);
                posTiroTemp = posTiroTemp == 0 ? posTiroTemp = 1 : posTiroTemp = 0;
            }
        }

    }

    
    //novo
    void Movimento()
    {
        if (bossAnim != null)
        {
        
            if (Vector3.Distance(points[atual].transform.position, Vilao.position) < raio) 
            {
                atual = Random.Range(0, points.Length);
                if(atual >= points.Length)
                {
                    atual = 0;
                }
            }

            Vilao.position = Vector3.MoveTowards(Vilao.position, new Vector3(points[atual].transform.position.x, Vilao.position.y, Vilao.position.z), Time.deltaTime * vel);

            if (atual == 0)
            {
                bossAnim.SetFloat("X", -1);
            }
            else
            {
                bossAnim.SetFloat("X", 1);
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }



}
