using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _poof;

    private void Start()
    {
        _poof.Stop();
    }

    public void StartCubeAddedParticlesl()
    {
        _poof.Play();
    }
}
