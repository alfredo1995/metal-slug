using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJUDAVILAO : MonoBehaviour {

    private WaitForSeconds t;
    [SerializeField]
    private GameObject prefab;
    

	// Use this for initialization
	void Start () {

        t = new WaitForSeconds(3);
        StartCoroutine("TempoCriacao");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TempoCriacao()
    {        

        while (true)
        {
            yield return t;
            if (GAMEMANAGER.inst.bossLuta && GAMEMANAGER.inst.limiteV > 0)
            {
                Instantiate(prefab,transform.position,Quaternion.identity);
                GAMEMANAGER.inst.limiteV--;
            }
        }
    }
}
