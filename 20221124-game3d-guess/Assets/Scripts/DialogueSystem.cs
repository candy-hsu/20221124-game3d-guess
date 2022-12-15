﻿
using UnityEngine;
using System.Collections;
using TMPro;
namespace Uzai
{
    /// <summary>
    /// 對話系統
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        #region 資料區域
        [SerializeField, Header("對話間隔"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("開頭對話")]
        private DialogueData dialogueOpening;
        [SerializeField, Header("對話按鍵")]
        private KeyCode dialogueKey = KeyCode.Space;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);
        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;
        #endregion

        #region 事件
        private void Awake()
        {
            groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話名稱").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("對話完成圖示");
            goTriangle.SetActive(false);

            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect());
        }
        #endregion

        /// <summary>
        /// 淡入淡出群組物件
        /// </summary>
        private IEnumerator FadeGroup()
        {
            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += 0.1f;
                yield return new WaitForSeconds(0.04f);
            }
        }

        /// <summary>
        /// 打字效果
        /// </summary>
        private IEnumerator TypeEffect()
        {
            textName.text = dialogueOpening.dialogueName;
            textContent.text = "";

            string dialogue = dialogueOpening.dialogueContects[0];

            for (int i = 0; i < dialogue.Length; i++)
            {
                textContent.text += dialogue[i];
                yield return dialogueInterval;
            }

            goTriangle.SetActive(true);

            //如果玩家還沒按下指定按鍵就等待
            while (!Input.GetKeyDown(dialogueKey))
            {
               //只停留一個影格的時間
                yield return null;
            }
            print("<color=#993300>玩家按下按鍵!</color>");
        }

    }

}
