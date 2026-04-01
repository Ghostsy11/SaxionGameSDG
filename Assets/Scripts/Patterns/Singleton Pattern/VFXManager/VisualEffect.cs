using UnityEngine;

namespace Assets.Scripts.Patterns.Singleton_Pattern.VFXManager
{
    [CreateAssetMenu(fileName = "VisualEffect", menuName = "SingleVisual Effect")]
    public class VisualEffect : ScriptableObject
    {
        [Header("Audio Data")]
        [Tooltip("Single ParticleSystem to be played by the VisualEffectsManager.")]
        public ParticleSystem SingleVFX;

        [Tooltip("Optional list of ParticleSystem to play single random VFX.")]
        public ParticleSystem[] RandomVFX;
    }
}