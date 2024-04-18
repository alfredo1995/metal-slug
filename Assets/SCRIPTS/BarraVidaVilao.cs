using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaVilao : MonoBehaviour {

	public int quantMaxCoracao = 5;
	public int inicioQuantCor = 3;
	public int quantPedacosC = 4;
	public Image[] containers;
	public Sprite[] spriteCoracao;

	//Novo
	public int vidaAtual;
	public int maxVida;


    public static BarraVidaVilao instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    // Use this for initialization
    void Start () {
		
		//novo
		CalculaValoresVida();


	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.F))
		{
			MaisCoracao ();
		}



	}

	void QuantidadeVida()
	{
		for(int i = 0; i < quantMaxCoracao; i++)
		{
			if(inicioQuantCor <= i)
			{
				containers [i].enabled = false;
			}
			else
			{
				containers [i].enabled = true;
			}
		}

		Coracoes ();
	}

	//novo
	void Coracoes()
	{
		bool vazio = false;
		int x = 0;

		foreach(Image imagem in containers)
		{
			if (vazio) 
			{				
				imagem.sprite = spriteCoracao [0];
			}
			else
			{
				x++;

				if (vidaAtual >= x * quantPedacosC) {
					
					imagem.sprite = spriteCoracao [4];

				} 
				else
				{
					
					int coracoesAtual = (int)(quantPedacosC - (quantPedacosC * x - vidaAtual));
					int vidaImagem = quantPedacosC / (spriteCoracao.Length - 1);
					int id = coracoesAtual / vidaImagem;
					imagem.sprite = spriteCoracao [id];
					vazio = true;

				}
			}
		}
	}

    public GameObject heroiMorto;

	public void Dano(int d)
	{
		if(vidaAtual > 0)
		{
			vidaAtual -= d;
		}
        else
        { 

            GAMEMANAGER.inst.gameover = true;
            CameraSegue.inst.segueHeroi = false;
            GameObject temp = Instantiate(heroiMorto,new Vector2(transform.position.x,transform.position.y),Quaternion.identity) as GameObject;
      
            temp.transform.localScale = transform.localScale;
            Destroy(gameObject);
            
        }
		Coracoes ();
	}

	public void MaisCoracao()
	{
		if(inicioQuantCor < quantMaxCoracao)
		{
			inicioQuantCor++;
		}

		CalculaValoresVida ();

	}


	void CalculaValoresVida()
	{
		vidaAtual = inicioQuantCor * quantPedacosC;
		maxVida = quantMaxCoracao * quantPedacosC;

		QuantidadeVida ();
	}

}
