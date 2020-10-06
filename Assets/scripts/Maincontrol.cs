using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Maincontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Lindrum;
    public GameObject Loutdrum;
    public GameObject Rindrum;
    public GameObject Routdrum;
    public GameObject taikobar;
    public GameObject Score;
    public GameObject Combo;

    public AudioSource clip;
    public AudioSource BGM;
    private double trackStartTime;
    private double BPM=244;
    private double nextTick=4;
    public double Timeline;
    private double Goodoffset=0.025;
    public double OKoffset=0.075;
    public double Timeoffset=1.2;
    private int combo=0;
    private int score=0;
    public double BGMoffset=-0.074;

    public GameObject noteR;
    public GameObject noteB;
    LinkedList<GameObject> note=new LinkedList<GameObject>();
    private GameObject k;
    void Start()
    {
        StartMusic();
    }
    // Update is called once per frame
    void Update()
    {
        Timeline=AudioSettings.dspTime-trackStartTime;
        if(Timeline>=nextTick*60.0/BPM-Timeoffset)
        {
            if(Random.Range(0,2)==1)createnoteB(nextTick*60/BPM);else createnoteB(nextTick*60/BPM);
            nextTick++;
        }
        if(note.Count!=0)
        {
            if(note.First.Value.GetComponent<Click>().Centerjudge+OKoffset<=Timeline)
            {
                note.First.Value.GetComponent<Click>().falseclick();
                note.RemoveFirst();
            }
            judgement();
        }
        Pressshow();
        soundeffect();
        Score.GetComponent<Text>().text=score.ToString();
        Combo.GetComponent<Text>().text=combo.ToString();
    }
    private void Pressshow()
    {
        if(Input.GetKey(KeyCode.Z))Loutdrum.SetActive(true);
        else Loutdrum.SetActive(false);
        if(Input.GetKey(KeyCode.X))Lindrum.SetActive(true);
        else Lindrum.SetActive(false);
        if(Input.GetKey(KeyCode.C))Rindrum.SetActive(true);
        else Rindrum.SetActive(false);
        if(Input.GetKey(KeyCode.V))Routdrum.SetActive(true);
        else Routdrum.SetActive(false);
    }
    private void judgement()
    {
        GameObject a=note.First.Value;
        if(Input.GetKeyDown(KeyCode.X)||Input.GetKeyDown(KeyCode.C))
        {
            if(!a.GetComponent<Click>().notetype)
            {
                if(a.GetComponent<Click>().Centerjudge-Goodoffset<=Timeline&&a.GetComponent<Click>().Centerjudge+Goodoffset>=Timeline)
                {
                    Delnote();
                    a.GetComponent<Click>().click();
                    combo++;
                    score+=300;
                }
                else if(a.GetComponent<Click>().Centerjudge-OKoffset<=Timeline&&a.GetComponent<Click>().Centerjudge+OKoffset>=Timeline)
                {
                    Delnote();
                    a.GetComponent<Click>().click();
                    combo++;
                    score+=100;
                }
                else if(Timeline<a.GetComponent<Click>().Centerjudge-OKoffset&&Timeline>a.GetComponent<Click>().Centerjudge-0.15)
                {
                    Delnote();
                    a.GetComponent<Click>().falseclick();
                    combo=0;
                }
                else if(Timeline>a.GetComponent<Click>().Centerjudge+OKoffset)
                {
                    Delnote();
                    a.GetComponent<Click>().falseclick();
                    combo=0;
                }
                else if(Timeline>=a.GetComponent<Click>().Centerjudge+0.15)
                {

                }
            }
            //else 打错note颜色的情况
        }
        if(Input.GetKeyDown(KeyCode.Z)||Input.GetKeyDown(KeyCode.V))
        {
            if(a.GetComponent<Click>().notetype)
            {
                if(a.GetComponent<Click>().Centerjudge-Goodoffset<=Timeline&&a.GetComponent<Click>().Centerjudge+Goodoffset>=Timeline)
                {
                    Delnote();
                    a.GetComponent<Click>().click();
                    combo++;
                    score+=300;
                }
                else if(a.GetComponent<Click>().Centerjudge-OKoffset<=Timeline&&a.GetComponent<Click>().Centerjudge+OKoffset>=Timeline)
                {
                    Delnote();
                    a.GetComponent<Click>().click();
                    combo++;
                    score+=100;
                }
                else if(Timeline<a.GetComponent<Click>().Centerjudge-OKoffset&&Timeline>a.GetComponent<Click>().Centerjudge-0.15)
                {
                    Delnote();
                    a.GetComponent<Click>().falseclick();
                    combo=0;
                }
                else if(Timeline>a.GetComponent<Click>().Centerjudge+OKoffset)
                {
                    Delnote();
                    a.GetComponent<Click>().falseclick();
                    combo=0;
                }
                else if(Timeline>=a.GetComponent<Click>().Centerjudge+0.15)
                {

                }
            }
            //else 打错note颜色的情况
        }

    }
    private void soundeffect()
    {
        if(Input.GetKeyDown(KeyCode.Z))clip.Play();
        if(Input.GetKeyDown(KeyCode.X))clip.Play();
        if(Input.GetKeyDown(KeyCode.C))clip.Play();
        if(Input.GetKeyDown(KeyCode.V))clip.Play();
    }
    public void StartMusic()
    {
        trackStartTime=AudioSettings.dspTime + 2;
        BGM.PlayScheduled(trackStartTime+BGMoffset);
    }
    private void createnoteB(double centertime)
    {
        k=Instantiate(noteB);
        k.GetComponent<Click>().speed=14.5/Timeoffset;
        k.GetComponent<Click>().Centerjudge=centertime;
        k.transform.SetParent(taikobar.transform);
        note.AddLast(k);
    }
    private void createnoteR(double centertime)
    {
        k=Instantiate(noteR);
        k.GetComponent<Click>().speed=14.5/Timeoffset;
        k.GetComponent<Click>().Centerjudge=centertime;
        k.transform.SetParent(taikobar.transform);
        note.AddLast(k);
    }
    public void Delnote(){note.RemoveFirst();}

}
