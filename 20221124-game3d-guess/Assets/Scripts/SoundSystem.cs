
using UnityEngine;

namespace Uzai
{
    /// <summary>
    /// 音效系統
    /// </summary>
    /// 要求元件：在第一次套用此腳本時，會添加裡面指定的
    [RequireComponent(typeof(AudioSource))]
    public class SoundSystem : MonoBehaviour
    {
        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// 撥放音樂
        /// </summary>
        /// <param name="sound">要撥放的音效</param>
        public void PlaySound(AudioClip sound)
        {
            //音效來源.撥放一次音效(音效);
            aud.PlayOneShot(sound);
        }
    }
}
   
