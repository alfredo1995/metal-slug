using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepoBombas : MonoBehaviour {

    [SerializeField]
    private Vector2 posInicial;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject efeitoEx;
    [SerializeField]
    private GameObject efeitoLetal;
    private AudioSource queda;
    [SerializeField]
    private GameObject bombaAudio;

	// Use this for initialization
	void Start () {
        posInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
        queda = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (rb.velocity.y < -0.01f)
        {
            if (!queda.isPlaying)
            {
                queda.volume = Random.Range(0.5f, 0.8f);
                queda.Play();
                
            }
        }

	}

    private void OnCollisionEnter2D()
    {
        queda.Stop();
        rb.velocity = Vector2.zero;        
        Instantiate(bombaAudio, transform.position, Quaternion.identity);

        Instantiate(efeitoEx, transform.position, Quaternion.identity);
        Instantiate(efeitoLetal, transform.position, Quaternion.identity);        
        transform.position = new Vector2(Random.Range(posInicial.x - 5, posInicial.x + 5),posInicial.y);        
        
    }
}
