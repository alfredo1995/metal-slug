using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TESTE_FUNGUS : MonoBehaviour {

    private Flowchart fc;

	// Use this for initialization
	void Start () {

        fc = GetComponent<Flowchart>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!fc.HasExecutingBlocks())
            {
                fc.ExecuteBlock("Start");
            }
        }

	}
}
