using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    public double Centerjudge;
    public bool notetype;
    private bool BeginDestroy=false;

    // Start is called before the first frame update

    void Start()
    {
        this.GetComponent<RectTransform>().localPosition=new Vector3(20.1f,0.62f,-0.82f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-12*Time.deltaTime,0,0);
        if(BeginDestroy)fade();
    }
    private void fade() 
    {
        this.GetComponent<RectTransform>().localScale=Vector3.Lerp(this.GetComponent<RectTransform>().localScale,new Vector3(0,0,0),Time.deltaTime*10);
        if(this.GetComponent<RectTransform>().localScale.x<=0.2)
        {
            Destroy(this.transform.gameObject);
        }
    }

    public void click()
    {
        BeginDestroy=true;
    }
    public void falseclick()
    {
        Destroy(this.transform.gameObject);
    }

}
