using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class selmap : MonoBehaviour
{
    private string MapfilePath=Application.streamingAssetsPath+"/359821 Yooh - LegenD [no video]/Yooh - LegenD. (toybot) [LEGEND].osu";
    private string MP3filePath=Application.streamingAssetsPath+"/359821 Yooh - LegenD [no video]/LegenD.mp3";
    private int hitline;
    public AudioClip BVW;
    // Start is called before the first frame update
    void Start()
    {
        staticsetting.TBGM=BVW;
        string[] fileData=File.ReadAllLines(MapfilePath);
        for(int i=52;i<fileData.Length;i++)
        {
            if(fileData[i]=="[HitObjects]")
            {
                hitline=i+1;
                break;
            }
        }
        for(int i=hitline;i<fileData.Length;i++)
        {
            string[] lineData = fileData[i].Split(',');
            staticsetting.notetimeline.AddLast(double.Parse(lineData[2])/1000);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mode1()
    {
        staticsetting.mode=1;
        SceneManager.LoadScene("Taiko");

    }
    public void mode2()
    {
        staticsetting.mode=2;
        SceneManager.LoadScene("Taiko");
    }
}
