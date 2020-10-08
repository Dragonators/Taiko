using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showanime : MonoBehaviour
{
    private double time=0;
    private Color raw;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<RectTransform>().localPosition=new Vector3(2f,0.62f,-0.82f);
        raw=this.transform.gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time<=0.1)enlarge();
        if(time>0.1&&time<=0.3)fade();
        if(time>0.3)Del();
    }
    private void enlarge()
    {
        this.GetComponent<RectTransform>().localScale=Vector3.Lerp(new Vector3(1,1,1),new Vector3(1.3f,1.3f,1.3f),(float)time*10);
    }
    private void fade()
    {
        this.transform.gameObject.GetComponent<Image>().color=Color.Lerp(raw,Color.clear,(float)time*5);
    }
    public void Del()
    {
        Destroy(this.transform.gameObject);
    }
}
