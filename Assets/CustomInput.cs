#region 模块信息
// **********************************************************************
// Copyright (C) 2017 The company name
//
// 文件名(File Name):             CustomInput.cs
// 作者(Author):                  #AuthorName#
// 创建时间(CreateTime):           #CreateTime#
// 修改者列表(modifier):
// 模块描述(Module description): 自定义按键输入
// **********************************************************************
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CustomInput : MonoBehaviour{
    private bool isChanging =false;
    public List<KeyCode> keys;
    public List<Button> buttons;

    private int keyIndex;
    public void OnPointerClick()
    {
        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "Enter Pls...";
        keyIndex = buttons.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<Button>());
        isChanging = true;
    }
    private void Start()
    {
        keys.Add(KeyCode.W);
        keys.Add(KeyCode.A);
        keys.Add(KeyCode.S);
        keys.Add(KeyCode.D);
        for (int i = 0;i<buttons.Count;i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = keys[i].ToString();
            buttons[i].onClick.AddListener(OnPointerClick);
            
        }
    }
    void Update () {
        //检查按键
        if (Input.anyKeyDown)
        {
            InputCheaking();
        }
    }
    void InputCheaking()
    {
        for (int i = 0; i<keys.Count;i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                print("Press " + keys[i].ToString());
            }
        }
    }
    private void OnGUI()
    {
        if (isChanging)
        {
            if (Input.anyKeyDown)
            {
                Event e = Event.current;
                if (e.isKey)
                {
                    EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = e.keyCode.ToString() ;
                    keys[keyIndex] = e.keyCode;
                    isChanging = false;
                }
            }
        }
    }
}
