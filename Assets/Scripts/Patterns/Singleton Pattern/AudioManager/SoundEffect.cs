using UnityEngine;

namespace Assets.Scripts.Patterns.Singleton_Pattern.AudioManager
{
    /// <summary>
    /// Holds the data for a single sound effect or optional a set of sound effects to play random clip.
    /// </summary>
    [CreateAssetMenu(fileName = "SoundEffect", menuName = "Audio/Sound Effect")]
    public class SoundEffect : ScriptableObject
    {
        [Header("Audio Data")]
        [Tooltip("Single audio clip to be played by the AudioManager.")]
        public AudioClip SingleSoundEffect;

        [Tooltip("Optional list of clips to play single random clip.")]
        public AudioClip[] RandomSoundEffect;

        [Range(0f, 1f)]
        [Tooltip("Playback volume for this sound effect.")]
        public float Volume = 0.5f;
    }
}