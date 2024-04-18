using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaIMG : MonoBehaviour {

	[SerializeField]
	private Sprite[] imagens;
	[SerializeField]
	private SpriteRenderer sr;
	[SerializeField]
	private int x = 1;
	[SerializeField]
	private int direcao = 0;

	[SerializeField]
	private GameObject balas;

    private Vector2 dir;
    [SerializeField]
    private JoyControl joyC;

	// Use this for initialization
	void Start () {

		sr.sprite = imagens [1];

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(x == 1)
			{
				x = 0;
			}
			else
			{
				x = 1;
			}

			sr.sprite = imagens [x];
		}


        
        Move2();

        Move3();
    }

	public void Direita()
	{
		direcao = 2;
	}

	public void Esquerda()
	{
		direcao = -2;
	}

	public void Parado()
	{
		direcao = 0;
	}



	void Mover()
	{
		transform.Translate (dir * Time.deltaTime);
	}

	public void Tiros()
	{
		Instantiate (balas,transform.position,Quaternion.identity);
	}



    void Move2()
    {
        dir.x = joyC.Hori();
        dir.y = joyC.Vert();
    }

    void Move3()
    {
        //Rotação
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        //Movimento
        transform.Translate(0, 1 * Time.deltaTime, 0);
    }



}
