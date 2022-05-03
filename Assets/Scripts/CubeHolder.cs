using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeHolder : MonoBehaviour
{
    private const float PlayerOverCubeOffset = 0.4f;

    [SerializeField] private Transform _stickman;
    [SerializeField] private float _fallVelocity;
    [SerializeField] private ParticleSystem _trail;
    [SerializeField] private float _secondsBeforeFalling;

    private List<Cube> _cubes = new List<Cube>(); 

    public event UnityAction AmountOfCubesChanged;

    public event UnityAction StickmanDied;

    private void Start()
    {
        _cubes.Add(transform.GetChild(0).GetComponent<Cube>());
    }

    public void AttachCube(Cube cube)
    {
        cube.transform.parent = gameObject.transform;
        cube.transform.position = new Vector3(transform.position.x, transform.position.y + _cubes.Count , transform.position.z);
        cube.BoxCollider.isTrigger = false;

        _cubes.Add(cube);

        _stickman.localPosition = new Vector3(transform.localPosition.x, _cubes.Count + PlayerOverCubeOffset, transform.localPosition.z);

        AmountOfCubesChanged?.Invoke();
    }

    public void ReleaseCube(Cube cube, Transform transform)
    {
        cube.transform.SetParent(transform);

        _cubes.Remove(cube);

        if (_cubes.Count == 0)
            StickmanDied?.Invoke();

        StartCoroutine(Falling(_secondsBeforeFalling));
    }

    private IEnumerator Falling(float seconds)
    {
        _trail.Stop();

        var waitForSeconds = new WaitForSeconds(seconds);

        yield return waitForSeconds;

        for (int i = 0; i < _cubes.Count; i++)  
        {
            Vector3 cubeTargetPosition = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
            Vector3 stickmanTargetPostion = new Vector3(0, _cubes.Count, 0);

            StartCoroutine(_cubes[i].Fall(cubeTargetPosition, _fallVelocity));
            
            _stickman.localPosition = new Vector3(_stickman.localPosition.x, _cubes.Count, _stickman.localPosition.z);

            yield return null;
        }

        _trail.Play();

        yield break;
    }
}
