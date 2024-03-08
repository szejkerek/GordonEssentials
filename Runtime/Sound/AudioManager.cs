using GordonEssentials.Types;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace GordonEssentials
{
    public class AudioManager : Singleton<AudioManager>
    {
        AudioSource musicSource;

        protected override void Awake()
        {
            base.Awake();
            musicSource = GetComponentInChildren<AudioSource>();
        }

        public void PlayOnTarget(GameObject target, Sound sound)
        {
            var sourceObj = target.AddComponent<AudioSource>();
            Play(sourceObj, sound, SoundType.SFX);
            Destroy(sourceObj, sound.Clip.length + 0.4f);
        }

        public void PlayAtPosition(Vector3 position, Sound sound)
        {
            GameObject gameObject = new GameObject(sound.name);
            var soundObj = Instantiate(gameObject, position, Quaternion.identity);
            PlayOnTarget(soundObj, sound);
        }

        public void Play(AudioSource source, Sound sound, SoundType type)
        {
            sound.ApplyTo(source).Play();
        }

        public void PlayGlobal(Sound sound)
        {
            if (sound.SoundType == SoundType.Music)
            {
                musicSource.Stop();
                StartCoroutine(FadeInMusic(sound, 1f));
            }

            PlayOnTarget(gameObject, sound);
        }

        private IEnumerator FadeInMusic(Sound sound, float duration)
        {
            float startVolume = 0.0f;
            musicSource.volume = startVolume;

            float currentTime = 0.0f;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                musicSource.volume = Mathf.Lerp(startVolume, sound.Volume, currentTime / duration);
                yield return null;
            }

            musicSource.volume = sound.Volume;
        }

        //private void SetMixer(AudioSource source, SoundType type)
        //{
        //    switch (type)
        //    {
        //        case SoundType.SFX:
        //            if (sfxMixer != null)
        //                source.outputAudioMixerGroup = sfxMixer;
        //            break;
        //        case SoundType.Music:
        //            if (musicMixer != null)
        //                source.outputAudioMixerGroup = musicMixer;
        //            break;
        //    }
        //}

        public void SetVolume(float value)
        {
            value = Mathf.Log10(value) * 20;

            if (value <= -19)
                value = float.MinValue;

            //if (masterMixer != null)
            //    masterMixer.audioMixer.SetFloat("MasterVolume", value);
        }
    }
}