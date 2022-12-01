
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Uzai
{
    /// <summary>
    /// 對話系統
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("對話間隔"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;

        private WaitForSeconds dialogueInterval;
        private CanvasGroup groupDialogue;
        private TextMeshPro textName;
        private TextMeshPro textContent;
        private GameObject goTriangle;

    }

}
