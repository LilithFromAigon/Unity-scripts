using UnityEngine;
using UnityEngine.ParticleSystem;

public class PlayerParticleSystem : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private void Update()
    {
        if (particleSystem != null)
        {
            particleSystem.transform.position = transform.position;
            particleSystem.transform.rotation = transform.rotation;
        }
    }
}
