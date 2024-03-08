using GordonEssentials.Types;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "Audio/AudioSettings", order = 1)]
public class AudioSettings : ScriptableObject
{
    [field: SerializeField] public List<MixerInfo> MixerInfos { private set; get; }

    public AudioMixer GetMixerOfType(SoundType type)
    {
        return MixerInfos.Where(info => info.Type == type).FirstOrDefault()?.AudioMixer;
    }
}

[System.Serializable]
public class MixerInfo
{
    [field: SerializeField] public SoundType Type { private set; get; }
    [field: SerializeField] public AudioMixer AudioMixer { private set; get; }
    [field: SerializeField] public string VolumeParameterName { private set; get; }
}