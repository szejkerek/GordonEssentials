using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "Audio/AudioSettings", order = 1)]
public class AudioSettings : ScriptableObject
{
    [field: SerializeField] public AudioMixerGroup AudioMixer { private set; get; }
    [field: SerializeField] public string VolumeParameterName { private set; get; }
}

