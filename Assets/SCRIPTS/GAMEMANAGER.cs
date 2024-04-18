using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.SceneManagement;



public class GAMEMANAGER : MonoBehaviour {

#region 
    public static GAMEMANAGER inst;
    public bool gameover;
    public GameObject heroi, veiculo;    
    public bool bossLuta;
    public int limiteV = 5;
    [SerializeField]
    private Rigidbody2D heroiRb,veiculoRb;
    //

    //Músicas
    public AudioClip[] clips;
    public AudioSource musicaBG;


    //TEMPORIZADOR
    //
    [SerializeField]
    private Text txtTempo;
    private float tempo;

    //SIGA EM FRENTE
    [SerializeField]
    private Animator animaEmFrente;
    private float tempoSiga = 5;
   

    //Personagem
    enum character
    {
        personagem = 0,
        tanque = 1
    };

    //Estado

    enum Estado
    {
        Jogo = 0,
        filme = 1
    };


    public int gameEstado;
    public int personagem;


    #endregion


    //NOVO AJUSTE DO INICIO DA BATALHA
    //variaveis novas

    [SerializeField]
    private Animator barCima, barBaixo;
    [SerializeField]
    private Image joyImg;
    public Flowchart fungus;
    public GameObject[] uiElementos;
    public int execUmavez = 0;
    private WaitForSeconds t;
    [SerializeField]
    private Transform boss;
    private GameObject goPainel;
    private Button denovo;

    private GameObject barreira;
    //container

    public GameObject container1,container2;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
        
        

    }

  

#region Carrega Cena

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        PegaDados();
    }

    void PegaDados()
    {
        container1 = GameObject.FindWithTag("objs");
        container2 = GameObject.FindWithTag("uicena");

        //Objetos de cena
        heroi = container1.transform.GetChild(0).gameObject;
        veiculo = container1.transform.GetChild(1).gameObject;
        boss = container1.transform.GetChild(2);
        fungus = container1.transform.GetChild(3).GetComponent<Flowchart>();
        barreira = container1.transform.GetChild(4).gameObject;
        //UI
        txtTempo = container2.transform.GetChild(7).GetComponent<Text>();
        joyImg = container2.transform.GetChild(3).GetChild(0).GetComponent<Image>();
        uiElementos[0] = container2.transform.GetChild(0).gameObject;
        uiElementos[1] = container2.transform.GetChild(1).gameObject;
        uiElementos[2] = container2.transform.GetChild(2).gameObject;
        uiElementos[3] = container2.transform.GetChild(3).gameObject;
        goPainel = container2.transform.GetChild(9).gameObject;
        denovo = container2.transform.GetChild(9).GetChild(0).GetComponent<Button>();
        //Animators
        animaEmFrente = container2.transform.GetChild(8).GetComponent<Animator>();
        barCima = container2.transform.GetChild(6).GetComponent<Animator>();
        barBaixo = container2.transform.GetChild(5).GetComponent<Animator>(); ;


        //RBs
        heroiRb = heroi.GetComponent<Rigidbody2D>();
        veiculoRb = veiculo.GetComponent<Rigidbody2D>();


        //event

        

        Reinicia();

        denovo.onClick.AddListener(Jogarnovamente);
    }

#endregion

    // Use this for initialization
    void Start () {


        Reinicia();
        

    }
	
	// Update is called once per frame
	void Update () {

        UpdateMusica();

        //NOVO TEMPORIZADOR

        if (tempo > 0 && personagem == 1)
        {
            txtTempo.enabled = true;
            tempo -= Time.deltaTime;
            txtTempo.text = tempo.ToString("#");
        }
        else if(tempo <= 0 && personagem == 1)
        {
            tempo = 0;
            txtTempo.enabled = false;
            QuebraParentesco();
            
        }

        //ANIMA SIGA EM FRENTE

        if (heroi != null)
        {
            if (!bossLuta)
            {

                if (heroiRb.velocity == Vector2.zero && gameEstado != 1 && personagem == 0 || veiculoRb.velocity == Vector2.zero && gameEstado != 1 && personagem == 1)
                {
                    if (tempoSiga > 0 && !animaEmFrente.gameObject.activeSelf)
                    {
                        tempoSiga -= Time.deltaTime;
                    }
                    else
                    {
                        animaEmFrente.gameObject.SetActive(true);
                        tempoSiga = 5;
                    }
                }
                else
                {
                    animaEmFrente.gameObject.SetActive(false);
                    tempoSiga = 5;
                }

            }

        }



        if (gameover && !goPainel.gameObject.activeSelf)
        {
            FimdeJogo();
        }



    }

    


    public void QuebraParentesco()
    {

        veiculo.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = false;//ajuste

        veiculo.GetComponentInParent<Rigidbody2D>().isKinematic = true;
        heroi.SetActive(true);
        heroi.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,12), ForceMode2D.Impulse);        
        heroi.transform.parent = null;       
        heroi.GetComponent<CapsuleCollider2D>().enabled = true;

        //NOVO AJUSTE

        veiculo.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;        
        personagem = 0;
        heroi.transform.localScale = new Vector3(1, 1, 1);
        heroi.GetComponent<HeroControll>().infChar.face = true;


    }


    // MUSICAS    

    void UpdateMusica()
    {
        if (gameEstado == 0)
        {
            if (!musicaBG.isPlaying)
            {
                musicaBG.clip = clips[0];
                musicaBG.Play();
            }
        }
        else if(gameEstado == 1)
        {
            if (musicaBG.isPlaying)
            {
                musicaBG.Stop();
            }
            if (!musicaBG.isPlaying)
            {
                musicaBG.clip = clips[1];
                musicaBG.Play();
            }
        }

    }






    public void LutaFinal(Transform t)
    {
        if (execUmavez == 0)
        {
            if (Vector2.Distance(t.position, boss.position) < 20)
            {
                gameEstado = 1;
                barCima.Play("BarAnimCima");
                barBaixo.Play("BarAnimBaixo");

                for (int i = 0; i < uiElementos.Length; i++)
                {
                    uiElementos[i].SetActive(false);
                }

            }


        }
        else if (gameEstado != 0)
        {
            gameEstado = 0;
            barCima.Play("BarAnimCimaInvers");
            barBaixo.Play("BarAnimBaixoInvers");

            for (int i = 0; i < uiElementos.Length; i++)
            {
                uiElementos[i].SetActive(true);
            }
            
            joyImg.rectTransform.anchoredPosition = Vector3.zero;
            JoyControl.inputDir = Vector3.zero;
            barreira.SetActive(false);
        }
    }



    public void FechaBloco()
    {
        execUmavez = 1;
        StopCoroutine("TempoCoroutine");        
    }

    
    IEnumerator TempoCoroutine()
    {
        while (execUmavez < 1)
        {
            yield return t;
            if (heroi != null)
            {
                if (Vector2.Distance(heroi.transform.position, boss.position) < 20 || Vector2.Distance(veiculo.transform.position, boss.position) < 20)
                {
                    fungus.ExecuteBlock("Start");
                }
            }


        }


    }


    void Jogarnovamente()
    {
        SceneManager.LoadScene(0);
        musicaBG.Stop();
    }
    
    //Reiniciar

    void Reinicia()
    {
        limiteV = 5;
        personagem = (int)character.personagem;
        gameEstado = (int)Estado.Jogo;
        gameover = false;
        bossLuta = false;
        execUmavez = 0;

        //NOVO HEROCONTROLL
        t = new WaitForSeconds(2.5f);
        StartCoroutine("TempoCoroutine");

        //TEMPORIZADOR

        tempo = 10;
        txtTempo.text = tempo.ToString("#");
        txtTempo.enabled = false;
        

        //SIGA EM FRENTE
        animaEmFrente.gameObject.SetActive(false);
        heroiRb = heroi.GetComponent<Rigidbody2D>();
        veiculoRb = veiculo.GetComponent<Rigidbody2D>();
        
        execUmavez = 0;
        bossLuta = false;
        gameEstado = 0;        
        goPainel.gameObject.SetActive(false);

        //Barreira
        barreira.SetActive(true);
    }

    //Fim de jogo

    void FimdeJogo()
    {
        goPainel.gameObject.SetActive(true);
        
    }


    private void OnDestroy() {
        StopAllCoroutines();
        SceneManager.sceneLoaded -= Carrega;
    }

}


















