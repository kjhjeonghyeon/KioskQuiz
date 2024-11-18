using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
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
    public GameObject answer;
    public GameObject Image_3;
    public AudioClip c_o;
    public AudioClip c_x;
    public AudioClip c_touch;
    public AudioClip c_main;
    public AudioClip c_time;
    public AudioClip c_clear;
    public AudioClip c_fail;
    public PlayableDirector t_clip;


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
    bool B_timeButton = true;
    float timeButton = -1.5f;

    void Start()
    {

        ranSprite = new Sprite[5];


    }
    void Update()
    {
        if (countO == 3)
        {
            if (matterPanal.GetComponent<Image>().sprite == p3)
            {
                Invoke("Success", 1.5f);
            }
            else
            {
                Success();
            }

        }
        if (countX == 3)
        {
            if (matterPanal.GetComponent<Image>().sprite == p3)
            {
                Invoke("Fail",1.5f);
            }
            else
            {
                Fail();
            }

        }
        if (b_sound == true)
        {
            gameObject.GetComponent<AudioSource>().Play();


            b_sound = false;
        }

        if (timeButton > -1.5f)
        {
            timeButton -= Time.deltaTime;
        }
        if (timeButton <= -1.5f)
        {
            B_timeButton = true;
            timeButton = -1.5f;
        }
    }
    void Success()
    {
        resultPanal.GetComponent<Image>().sprite = resultO;
        gameObject.GetComponent<AudioSource>().clip = c_clear;
        resultPanal.SetActive(true);
        firstPanal.SetActive(false);
        matterPanal.SetActive(false);
        Image_3.SetActive(false);
        answer.SetActive(false);
        countO = 0;
        b_sound = true;
        b_answer = true;
        countSetting++;
    }
    void Fail()
    {
        resultPanal.GetComponent<Image>().sprite = resultX;
        gameObject.GetComponent<AudioSource>().clip = c_fail;

        resultPanal.SetActive(true);
        firstPanal.SetActive(false);
        matterPanal.SetActive(false);
        Image_3.SetActive(false);
        answer.SetActive(false);

        countX = 0;
        b_sound = true;
        b_answer = true;
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
        gameObject.GetComponent<AudioSource>().loop = false;

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
    void Ressetsound()
    {

        gameObject.GetComponent<AudioSource>().clip = c_main;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().loop = true;

    }
    void Answer()
    {
        if (b_answer == false)
        {

            answer.SetActive(false);
            Image_3.SetActive(false);
            matterPanal.GetComponent<Image>().sprite = ranSprite[pageCount];
            matterPanal.SetActive(true);
        }
    }
    public void OPanalButton()
    {

        timeButton = 0;
        if (B_timeButton == true)
        {
            if (matterPanal.GetComponent<Image>().sprite == p1)
            {
                answer.transform.GetChild(0).gameObject.SetActive(true);
                answer.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.GetComponent<AudioSource>().clip = c_o;
                countO++;
            }
            if (matterPanal.GetComponent<Image>().sprite == p2)
            {
                answer.transform.GetChild(0).gameObject.SetActive(true);
                answer.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.GetComponent<AudioSource>().clip = c_o;
                countO++;
            }
            if (matterPanal.GetComponent<Image>().sprite == p3)
            {
                answer.transform.GetChild(0).gameObject.SetActive(true);
                answer.transform.GetChild(1).gameObject.SetActive(false);
                Image_3.SetActive(true);
                gameObject.GetComponent<AudioSource>().clip = c_x;
                t_clip.Play();
                countX++;
            }
            if (matterPanal.GetComponent<Image>().sprite == p4)
            {
                answer.transform.GetChild(0).gameObject.SetActive(true);
                answer.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.GetComponent<AudioSource>().clip = c_o;
                countO++;


            }
            if (matterPanal.GetComponent<Image>().sprite == p5)
            {
                answer.transform.GetChild(0).gameObject.SetActive(true);
                answer.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.GetComponent<AudioSource>().clip = c_o;

                countO++;
            }

            gameObject.GetComponent<AudioSource>().Play();
            answer.SetActive(true);
            pageCount++;
            B_timeButton = false;
            Invoke("sound", 1.5f);
            Invoke("Answer", 1.5f);
        }
    }

    public void XPanalButton()
    {
        timeButton = 0;
        if (B_timeButton == true)
        {

            if (matterPanal.GetComponent<Image>().sprite == p1)
            {
                answer.transform.GetChild(1).gameObject.SetActive(true);
                answer.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.GetComponent<AudioSource>().clip = c_x;
                t_clip.Play();
                countX++;
            }
            if (matterPanal.GetComponent<Image>().sprite == p2)
            {
                answer.transform.GetChild(1).gameObject.SetActive(true);
                answer.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.GetComponent<AudioSource>().clip = c_x;
                t_clip.Play();
                countX++;
            }
            if (matterPanal.GetComponent<Image>().sprite == p3)
            {
                answer.transform.GetChild(1).gameObject.SetActive(true);
                answer.transform.GetChild(0).gameObject.SetActive(false);
                Image_3.SetActive(true);
                gameObject.GetComponent<AudioSource>().clip = c_o;

                countO++;
            }
            if (matterPanal.GetComponent<Image>().sprite == p4)
            {
                answer.transform.GetChild(1).gameObject.SetActive(true);
                answer.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.GetComponent<AudioSource>().clip = c_x;
                t_clip.Play();
                countX++;
            }
            if (matterPanal.GetComponent<Image>().sprite == p5)
            {
                answer.transform.GetChild(1).gameObject.SetActive(true);
                answer.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.GetComponent<AudioSource>().clip = c_x;
                t_clip.Play();
                countX++;
            }
            gameObject.GetComponent<AudioSource>().Play();
            answer.SetActive(true);
            pageCount++;
            B_timeButton = false;
            Invoke("sound", 1.5f);
            Invoke("Answer", 1.5f);
        }
    }
    public void Reset()
    {
        firstPanal.SetActive(true);
        resultPanal.SetActive(false);
        matterPanal.SetActive(false);
        answer.SetActive(false);
        b_answer = false;
        pageCount = 0;
        countO = 0;
        countX = 0;
        Invoke("Ressetsound", 0);
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
