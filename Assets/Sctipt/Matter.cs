using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Matter : MonoBehaviour
{
    //�� ��ǲ�ʵ忡 �۾��� ���� Ȯ���� ������ ������ �ڵ��Էµȴ�
    public TMP_InputField InputO;
    public TMP_InputField InputX;

    TMP_Text[] Quiztext;
    int countX;
    int countO;
    void Start()
    {

    }

    void Update()
    {   //input�� ���� ���� �ޱ�
        //���� ����Ʈ����� (�ν���Ʈ)
        //��������Ʈ�� ���� �����
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
