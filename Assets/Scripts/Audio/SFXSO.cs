using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DaemonsGate.Audio
{
    [CreateAssetMenu(fileName = "NewSoundEffect", menuName = "DaemonsGate/Audio/New Sound Effect")]
    public class SFXSO : ScriptableObject
    {
        public AudioClip[] clips;
        public Vector2 volume = new Vector2(0.5f, 0.5f);
        public Vector2 pitch = new Vector2(1f, 1f);
        [SerializeField] int playIndex;
        [SerializeField] SoundClipPlayOrder playOrder;

        private AudioClip GetAudioClip()
        {
            var clip = clips[playIndex >=clips.Length ? 0 : playIndex];
            switch (playOrder)
            {
                case SoundClipPlayOrder.in_order:
                    playIndex = (playIndex + 1) % clips.Length;
                    break;
                case SoundClipPlayOrder.random:
                    playIndex = Random.Range(0, clips.Length);
                    break;
                case SoundClipPlayOrder.reversed:
                    playIndex = (playIndex + clips.Length - 1) % clips.Length;
                    break;
            }
            return clip;
        }

        public AudioSource Play(GameObject sourceObj, AudioSource audioSourceParam = null)
        {
            if (clips.Length == 0)
            {
                Debug.LogWarning($"Missing sound clips for {name}");
                return null;
            }

            var source = audioSourceParam;
            if (source == null)
            {
                var _obj = new GameObject("Sound", typeof(AudioSource));
                source = _obj.GetComponent<AudioSource>();
                _obj.transform.position = sourceObj.transform.position;
            }

            source.clip = clips[0];
            source.volume = Random.Range(volume.x, volume.y);
            source.pitch = Random.Range(pitch.x, pitch.y);
            
            source.Play();
            
            Destroy(source.gameObject, source.clip.length/source.pitch);

            return source;

        }

        enum SoundClipPlayOrder
        {
            random, 
            in_order,
            reversed
        }
        
    }
}