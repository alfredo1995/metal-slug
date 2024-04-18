using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LOADCOD : MonoBehaviour {

    [SerializeField]
    private GameObject logoImg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BtnClick(string s)
    {
        StartCoroutine(LoadGameProg(s));
    }

    IEnumerator LoadGameProg(string val)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(val);

        while (!async.isDone)
        {
            if (logoImg != null)
            {
                logoImg.SetActive(true);
            }            
            yield return null;
        }
    }
}
