using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyControl : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler{


    [SerializeField]
    private Image bgImg;
    [SerializeField]
    private Image joyImg;

    public static Vector3 inputDir;

    private void Start()
    {

        bgImg = GetComponent<Image>();
        joyImg = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
	{

        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,ped.position,ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputDir = new Vector3(pos.x * 2,pos.y * 2,0);
            inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir;

            joyImg.rectTransform.anchoredPosition = new Vector3(inputDir.x * (bgImg.rectTransform.sizeDelta.x / 3),inputDir.y * (bgImg.rectTransform.sizeDelta.y / 3));

            
        }
        
    }

	public virtual void OnPointerDown(PointerEventData ped)
	{
        OnDrag(ped);
    }

	public virtual void OnPointerUp(PointerEventData ped)
	{
        inputDir = Vector3.zero;
        joyImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Hori()
    {
        if(inputDir.x != 0)
        {
            return inputDir.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float Vert()
    {
        if (inputDir.y != 0)
        {
            return inputDir.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }

}
