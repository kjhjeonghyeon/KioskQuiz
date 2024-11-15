using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Matter : MonoBehaviour
{
    //각 인풋필드에 글씨를 쓰고 확인을 누르면 문제가 자동입력된다
    public TMP_InputField InputO;
    public TMP_InputField InputX;

    TMP_Text[] Quiztext;
    int countX;
    int countO;
    void Start()
    {

    }

    void Update()
    {   //input을 통해 문제 받기
        //문제 리스트만들기 (인스턴트)
        //문제리스트로 게임 만들기
    }

    public void InPutX()
    {
        countX++;
        Quiztext[countX] = InputX.GetComponent<TMP_Text>();
    }
    public void InPutO()
    {
        countO++;
        Quiztext[countO] = InputO.GetComponent<TMP_Text>();
    }
}
