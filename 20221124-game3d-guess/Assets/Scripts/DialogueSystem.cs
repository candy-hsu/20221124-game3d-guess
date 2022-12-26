﻿
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Events;

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

        private PlayerInput playerInput;
        private UnityEvent onDialogueFinish;

        #region 事件
        private void Awake()
        {
            groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話名稱").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("對話完成圖示");
            goTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StarDialogue(dialogueOpening);
        }
        #endregion

        /// <summary>
        /// 開始對話
        /// </summary>
        /// <param name="data">要執行的對話資料</param>
        /// <param name="_onDialogueFinish">對話結束後的事件,可以空值</param>
        public void StarDialogue(DialogueData data,UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }

        /// <summary>
        /// 淡入淡出群組物件
        /// </summary>
        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            //三元運算子?:
            //語法：
            //布林值? 布林值為true ：布林值為 false;
            //true ? 1 : 10; 結果為10

            float increase = fadeIn ? +0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);
            }
        }

        /// <summary>
        /// 打字效果
        /// </summary>
        private IEnumerator TypeEffect(DialogueData data)
        {
            textName.text = data.dialogueName;

            for (int j = 0; j < data.dialogueContects.Length; j++)
            {
                textContent.text = "";
                goTriangle.SetActive(false);

                string dialogue = data.dialogueContects[j];

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

            StartCoroutine(FadeGroup(false));   //開啟  玩家輸入元件
            playerInput.enabled = true;
            //?.當 onDialogueFinish沒有值時就不執行
            onDialogueFinish?.Invoke();  //對話結束事件,呼叫();
        }

    }

}
