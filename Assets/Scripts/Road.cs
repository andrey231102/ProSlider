using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float distancePerFrame = _speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, 0, distancePerFrame), transform.position.z);
    }
}
