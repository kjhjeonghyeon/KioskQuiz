using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;

public class Page : MonoBehaviour
{

    public Sprite p1;
    public Sprite p2;
    public Sprite p3;
    public Sprite p4;
    public Sprite p5;
    public Sprite main;
    public Sprite resultO;
    public Sprite resultX;
    public Sprite o;
    public Sprite x;

    public GameObject firstPanal;
    public GameObject matterPanal;
    public GameObject resultPanal;
    public GameObject answerPanal;
    public AudioClip c_o;
    public AudioClip c_x;
    public AudioClip c_touch;
    public AudioClip c_time;
    public AudioClip c_clear;
    public AudioClip c_fail;


    Sprite[] ranSprite;
    int countO = 0;
    int countX = 0;
    int pageCount = 0;
    bool b_sound = false;
    bool b_answer = false;

    int countSetting = 0;
    public TMP_Text people;
    public GameObject peoplePanal;
    bool opneSetting = false;
    void Start()
    {

        ranSprite = new Sprite[5];


    }
    void Update()
    {
        if (countO == 3)
        {
            resultPanal.GetComponent<Image>().sprite = resultO;
            gameObject.GetComponent<AudioSource>().clip = c_clear;
            resultPanal.SetActive(true);
            firstPanal.SetActive(false);
            matterPanal.SetActive(false);
            answerPanal.SetActive(false);
            countO = 0;
            b_sound = true;
            b_answer = true;
            countSetting++;
        }
        if (countX == 3)
        {
            resultPanal.GetComponent<Image>().sprite = resultX;
            gameObject.GetComponent<AudioSource>().clip = c_fail;

            resultPanal.SetActive(true);
            firstPanal.SetActive(false);
            matterPanal.SetActive(false);
            answerPanal.SetActive(false);

            countX = 0;
            b_sound = true;
            b_answer = true;

        }
        if (b_sound == true)
        {
            gameObject.GetComponent<AudioSource>().Play();


            b_sound = false;
        }
    }
    void FinalSound()
    {
        gameObject.GetComponent<AudioSource>().clip = c_clear;
        gameObject.GetComponent<AudioSource>().Play();
    }
    private void RandomArray()
    {
        Sprite now = null;

        ranSprite[0] = p1;
        ranSprite[1] = p2;
        ranSprite[2] = p3;
        ranSprite[3] = p4;
        ranSprite[4] = p5;


        int a;
        int b;

        for (int i = 0; i < 5; i++)
        {
            a = Random.Range(0, 5);
            b = Random.Range(0, 5);
            now = ranSprite[a];
            ranSprite[a] = ranSprite[b];
            ranSprite[b] = now;
        }
        //for (int i = 0; i < 5; i++)
        //{
        //    print(ranSprite[i]);
        //}
        matterPanal.GetComponent<Image>().sprite = ranSprite[0];
    }

    // Update is called once per frame

    public void FirstPanalButton()
    {
        matterPanal.SetActive(true);
        RandomArray();
        firstPanal.SetActive(false);
        gameObject.GetComponent<AudioSource>().clip = c_touch;
        gameObject.GetComponent<AudioSource>().Play();

        Invoke("sound", 0);
    }
    void sound()
    {
        if (b_answer == false)
        {
            gameObject.GetComponent<AudioSource>().clip = c_time;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
    void Answer()
    {
        if (b_answer == false)
        {

            answerPanal.SetActive(false);
            matterPanal.GetComponent<Image>().sprite = ranSprite[pageCount];
            matterPanal.SetActive(true);
        }
    }
    public void OPanalButton()
    {

        if (matterPanal.GetComponent<Image>().sprite == p1)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = o;
            gameObject.GetComponent<AudioSource>().clip = c_o;
            countO++;
        }
        if (matterPanal.GetComponent<Image>().sprite == p2)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = o;
            gameObject.GetComponent<AudioSource>().clip = c_o;
            countO++;
        }
        if (matterPanal.GetComponent<Image>().sprite == p3)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = o;
            gameObject.GetComponent<AudioSource>().clip = c_o;
            countO++;
        }
        if (matterPanal.GetComponent<Image>().sprite == p4)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = x;
            gameObject.GetComponent<AudioSource>().clip = c_x;


            countX++;
        }
        if (matterPanal.GetComponent<Image>().sprite == p5)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = x;
            gameObject.GetComponent<AudioSource>().clip = c_x;

            countX++;
        }

        gameObject.GetComponent<AudioSource>().Play();
        answerPanal.SetActive(true);
        pageCount++;
        Invoke("sound", 3);
        Invoke("Answer", 3);
    }

    public void XPanalButton()
    {

        if (matterPanal.GetComponent<Image>().sprite == p1)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = o;
            gameObject.GetComponent<AudioSource>().clip = c_x;

            countX++;
        }
        if (matterPanal.GetComponent<Image>().sprite == p2)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = o;
            gameObject.GetComponent<AudioSource>().clip = c_x;

            countX++;
        }
        if (matterPanal.GetComponent<Image>().sprite == p3)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = o;
            gameObject.GetComponent<AudioSource>().clip = c_x;

            countX++;
        }
        if (matterPanal.GetComponent<Image>().sprite == p4)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = x;
            gameObject.GetComponent<AudioSource>().clip = c_o;

            countO++;
        }
        if (matterPanal.GetComponent<Image>().sprite == p5)
        {
            answerPanal.transform.GetChild(0).GetComponent<Image>().sprite = x;
            gameObject.GetComponent<AudioSource>().clip = c_o;
            countO++;
        }
        gameObject.GetComponent<AudioSource>().Play();
        answerPanal.SetActive(true);
        pageCount++;
        Invoke("sound", 3);
        Invoke("Answer", 3);
    }
    public void Reset()
    {
        firstPanal.SetActive(true);
        resultPanal.SetActive(false);
        matterPanal.SetActive(false);
        answerPanal.SetActive(false);
        b_answer = false;
        pageCount = 0;
        countO = 0;
        countX = 0;
        Invoke("sound", 0);
    }
    public void CountSetting()
    {
        people.text = countSetting.ToString();

        if (opneSetting == false)
        {
            peoplePanal.SetActive(true);
            opneSetting = true;
        }
        else if (opneSetting == true)
        {
            peoplePanal.SetActive(false);
            opneSetting = false;
        }

    }
    public void CountSettingResst()
    {
        countSetting = 0;
        people.text = countSetting.ToString();

    }
}
