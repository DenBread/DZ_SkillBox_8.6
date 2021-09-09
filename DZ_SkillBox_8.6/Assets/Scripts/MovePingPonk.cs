using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePingPonk : MonoBehaviour, IMovevarble
{
    private GameObject _cube; // сам куб для перемещения
    private float _speed; // скорость перемещения
    [SerializeField] private Vector3[] _vectorTartget; // точки для перемещния куба
    [SerializeField] private int _indexTaget; // индекс точки перемещения
    [SerializeField] private bool forward;

    private void Start()
    {
        _cube = gameObject;
        _speed = 7f;
        _indexTaget = 1;
        forward = true;

    }
        
    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Метод для выполнения перемещения обьекта, как пинг-понг
    /// </summary>
    public void Move()
    {
        _cube.transform.position = Vector3.MoveTowards(transform.position, _vectorTartget[_indexTaget], _speed * Time.fixedDeltaTime);

        if (transform.position == _vectorTartget[_indexTaget] && _indexTaget < _vectorTartget.Length && forward)
        {
            _indexTaget++;
            if (_indexTaget == _vectorTartget.Length)
            {
                forward = false;
                _indexTaget--;
            }
        }

        if (transform.position == _vectorTartget[_indexTaget] && !forward)
        {
            _indexTaget--;
            if (_indexTaget <= -1)
            {
                forward = true;
                _indexTaget++;
            }
        }
    }
}
