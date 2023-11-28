using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _path;
    private Transform[] _targets;
    private float _speed = 3;
    private int _currentPosition;

    public void SetTarget(Transform target)
    {
        _path = target;
    }

    private void Start()
    {
        _targets = new Transform[_path.childCount];

        for (int i = 0; i < _targets.Length; i++)
        {
            _targets[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Transform target = _targets[_currentPosition];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.01f)
        {
            MoveToNextTarget();
        }
    }

    private void MoveToNextTarget()
    {
        _currentPosition++;

        if (_currentPosition >= _targets.Length)
        {
            _currentPosition = 0;
        }
    }
}
