using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUI : MonoBehaviour {

    [SerializeField]
    private RawImage scrollImage;
    private Rect temp;

    private void Start()
    {
        temp = new Rect(scrollImage.uvRect);
    }

    // Update is called once per frame
    void Update () {

        temp.x += 0.01f * Time.deltaTime;
        scrollImage.uvRect = temp;

	}
}
