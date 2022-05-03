using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    [SerializeField] private CubeHolder _holder;

    private BoxCollider _boxCollider;

    public BoxCollider BoxCollider => _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cube cube))
        {
            _holder.AttachCube(this);
        }

        if(other.TryGetComponent(out Destroyer destroyer))
        {
            gameObject.SetActive(false);
        }
    }

    public IEnumerator Fall(Vector3 targetPosition, float fallVelocity)
    {
        Vector3 startPosition = transform.position;

        while (transform.position.y != targetPosition.y)
        {
            startPosition.y = Mathf.MoveTowards(startPosition.y, targetPosition.y, Time.deltaTime * fallVelocity);
            transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
            yield return null;
        }

        yield break;
    }
}
