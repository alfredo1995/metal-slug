using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporizadorBombaBoss : MonoBehaviour {

    private WaitForSeconds tempo;
    [SerializeField]
    private GameObject BumAnim;
    [SerializeField]
    private GameObject efeitoLetal,bombaAudio;

	// Use this for initialization
	void Start () {

        tempo = new WaitForSeconds(Random.Range(0.5f, 3));
        StartCoroutine("Temporizador");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Temporizador()
    {
        yield return tempo;

        Instantiate(bombaAudio, transform.position, Quaternion.identity);

        Instantiate(BumAnim,transform.position,Quaternion.identity);
        Instantiate(efeitoLetal, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
