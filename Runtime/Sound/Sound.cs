using UnityEngine;

namespace GordonEssentials.Types
{
    [CreateAssetMenu(fileName = "Sound", menuName = "Audio/Sound", order = 1)]
    public class Sound : ScriptableObject
    {
        [field: SerializeField] public AudioClip Clip { private set; get; }
        public SoundType SoundType => soundType;
        [SerializeField] SoundType soundType = SoundType.SFX;
        public float Volume => volume;
        [SerializeField, Range(0, 1)] float volume = 1;
        public float PitchVariation => pitchVariation;
        [SerializeField, Range(0, 3)] float pitchVariation = 0;
        public bool Loop => loop;
        [SerializeField] bool loop = false;
        [field: SerializeField] public Settings3D Settings3D { private set; get; }

        public AudioSource ApplyTo(AudioSource source)
        {
            if (Clip == null)
            {
                Debug.LogWarning($"Sound of {source.gameObject.name} is null");
                return null;
            }

            source.clip = Clip;
            source.volume = Volume;

            if (PitchVariation > 0)
            {
                source.pitch = 1 + Random.Range(-PitchVariation, PitchVariation);
            }
            else
            {
                source.pitch = 1;
            }

            source.loop = Loop;

            source.spatialBlend = Settings3D.SpatialBlend ? 1f : 0f;
            source.minDistance = Settings3D.MinDistance;
            source.maxDistance = Settings3D.MaxDistance;

            return source;
        }
    }
}