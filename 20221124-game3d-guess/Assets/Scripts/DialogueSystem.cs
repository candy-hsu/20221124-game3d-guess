
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Uzai
{
    /// <summary>
    /// ��ܨt��
    /// </summary>
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("��ܶ��j"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;

        private WaitForSeconds dialogueInterval;
        private CanvasGroup groupDialogue;
        private TextMeshPro textName;
        private TextMeshPro textContent;
        private GameObject goTriangle;

    }

}
