﻿using System.Collections;
using UnityEngine;
namespace Uzai
{
    /// <summary>
    /// 學習協同程序，簡稱協程 coroutine
    /// 目的：讓城市停留達到等待的效果
    /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {
        //使用協同程序的三個條件
        //1.引用命名空間 System.Collections
        //2.定義一個傳回 IEnumerator 的方法
        //3.方法內必須使用 yield return (等待)
        //4.使用 StartCoroutine 啟動

        private string testDialogue = "這裡好恐怖，我想要快點離開......";
        
        private void Awake()
        {
            StartCoroutine(Test());

            print("取得測試對話的第一個字：" + testDialogue[0]);

            StartCoroutine(ShowDialogue());
        }

        private IEnumerator Test()
        {
            print("<color=#33ff33>第一行程式</color>");
            yield return new WaitForSeconds(2);
            print("<color=#ff3333>第二行程式</color>");
            yield return new WaitForSeconds(3);
            print("<color=#3333ff>第二行程式</color>");
        }

        private IEnumerator ShowDialogue()
        {
            print(testDialogue[0]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[1]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[2]);
            yield return new WaitForSeconds(0.1f);

        }
    }

}