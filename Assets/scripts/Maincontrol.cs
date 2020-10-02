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
    public AudioSource clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input();
        soundeffect();
    }
    private void input()
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
    private void soundeffect()
    {
        if(Input.GetKeyDown(KeyCode.Z))clip.Play();
        if(Input.GetKeyDown(KeyCode.X))clip.Play();
        if(Input.GetKeyDown(KeyCode.C))clip.Play();
        if(Input.GetKeyDown(KeyCode.V))clip.Play();
    }
}
