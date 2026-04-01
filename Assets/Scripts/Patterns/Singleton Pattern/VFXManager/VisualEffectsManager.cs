using UnityEngine;

namespace Assets.Scripts.Patterns.Singleton_Pattern.VFXManager
{

    public class VisualEffectsManager : Singleton<VisualEffectsManager>
    {
        [Header("Test 1")]
        [SerializeField]
        private CustomVisualEffect visualEffectSO;

        [Header("Test 2")]
        [SerializeField]
        private CustomVisualEffect VisualEffectso;

        /// <summary>
        /// Initializes this manager.
        /// </summary>
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
            if (Input.GetKeyDown(KeyCode.D))
            {
                PlaySinglePartilceEffect(visualEffectSO.SingleVFX, transform);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                PlaySingleRandomParticleEffect(VisualEffectso.RandomVFX, transform);
            }
        }


        private void PlaySinglePartilceEffect(ParticleSystem particle, Transform pos)
        {
            if (particle != null)
            {
                ParticleSystem visualEffect = Instantiate(particle, pos.gameObject.transform.position, Quaternion.identity);

                if (!visualEffect.isPlaying)
                {
                    visualEffect.Play();
                }

                Destroy(visualEffect.gameObject, visualEffect.main.duration + visualEffect.main.startLifetime.constantMax);
            }
        }
        public void PlaySingleRandomParticleEffect(ParticleSystem[] particles, Transform pos)
        {
            if (particles != null)
            {
                int randomParticle = Random.Range(0, particles.Length);
                ParticleSystem visualEffect = Instantiate(particles[randomParticle], pos.transform.position, Quaternion.identity);

                if (!visualEffect.isPlaying)
                {
                    visualEffect.Play();
                }

                Destroy(visualEffect.gameObject, visualEffect.main.duration + visualEffect.main.startLifetime.constantMax);

            }
        }
    }

}