using UnityEngine;

public class FireWorkSoundEffect : MonoBehaviour
{
    public ParticleSystem Particle;
    int OldNumberOfParticles;
    public AudioClip[] FireWorksExplosions;
    void Start()
    {
        Particle = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Particle.particleCount < OldNumberOfParticles)
        {
            int Rand = Random.Range(0, FireWorksExplosions.Length);
            gameObject.GetComponent<AudioSource>().clip = FireWorksExplosions[Rand];
            gameObject.GetComponent<AudioSource>().Play();
        }
        OldNumberOfParticles = Particle.particleCount;
    }
}
