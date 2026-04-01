using UnityEngine;

namespace Assets.Scripts.Patterns.Singleton_Pattern.AudioManager
{
    /// <summary>
    /// Global audio manager that provides access to sound effects by generated enum type.
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {
        #region Fields

        [Header("Test 1")]
        [SerializeField]
        private SoundEffect AudioClipsAssets;

        [Header("Test 2")]
        [SerializeField]
        private SoundEffect AudioClips;

        #endregion

        protected override void Awake()
        {
            base.Awake();

            if (Instance != this)
            {
                return;
            }

            Debug.Log("TestManager singleton initialized.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlayClip(AudioClipsAssets.SingleSoundEffect, AudioClipsAssets.Volume);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayRandomAudio(AudioClips.RandomSoundEffect, AudioClipsAssets.Volume);
            }
        }

        #region Audio Functions

        /// <summary>
        /// Plays a single clip at the main camera position.
        /// </summary>
        private void PlayClip(AudioClip clip, float volume)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }

        /// <summary>
        /// Plays a random clip from the given array at the main camera position.
        /// </summary>
        private void PlayRandomAudio(AudioClip[] randomAudio, float volume)
        {
            int randomIndex = UnityEngine.Random.Range(0, randomAudio.Length);
            AudioClip selectedClip = randomAudio[randomIndex];
            Vector3 cameraPosition = Camera.main.transform.position;

            AudioSource.PlayClipAtPoint(selectedClip, cameraPosition, volume);
        }

        #endregion
    }
}