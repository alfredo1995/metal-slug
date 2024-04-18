using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombasCaindo : MonoBehaviour {

    [SerializeField]
    private GameObject[] bomba;
    private bool ativo = false;

    // Use this for initialization
    void Start () {

        for (int i = 0; i < bomba.Length; i++)
        {
            bomba[i].gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (BossControl.inst.cabineTiros == null && !ativo)
        {
            for (int i = 0; i < bomba.Length; i++)
            {
                bomba[i].gameObject.SetActive(true);

                if (bomba[i].activeInHierarchy && i == bomba.Length - 1)
                {
                    ativo = true;
                    break;
                }
            }            
            
        }

	}

    
}
