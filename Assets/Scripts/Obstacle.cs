using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private CubeHolder _cubeHolder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cube cube))
        {
            _cubeHolder.ReleaseCube(cube, transform);
            Handheld.Vibrate();
        }
    }
}