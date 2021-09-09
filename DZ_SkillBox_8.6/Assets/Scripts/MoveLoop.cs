using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLoop : MonoBehaviour, IMovevarble
{
    [SerializeField] private float _speed; // скорость кубика
    [SerializeField] private List<Vector3> _vec; // точки перемещения куба
    [SerializeField] private int _indexVec; // индекс точки перемещения
    [SerializeField] private GameObject[] _gm; // кубы для эстафеты

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Метод для перемещения данных по индексу меня их местами в list
    /// </summary>
    /// <typeparam name="T">тип list</typeparam>
    /// <param name="list"></param>
    /// <param name="i">первый параметр по индексу</param>
    /// <param name="j">второй параметр по индесу</param>
    public static void Swap<T>(List<T> list, int i, int j)
    {
        var elem1 = list[i];
        var elem2 = list[j];

        list[i] = elem2;
        list[j] = elem1;
    }

    /// <summary>
    /// Метод для передачи эстафеты кубов
    /// </summary>
    public void Move()
    {
        _gm[_indexVec].transform.position = Vector3.MoveTowards(_gm[_indexVec].transform.position, _vec[_indexVec],
            _speed * Time.deltaTime);

        if (_gm[_indexVec].transform.position == _vec[_indexVec])
        {
            _indexVec++;
            if (_indexVec == _vec.Count)
            {
                //Debug.Log("Цикл вкл")
                _indexVec = 0;
                for (int i = 0; i < _vec.Count; i++)
                {
                    _indexVec++;
                    if (_indexVec < _vec.Count)
                    {
                        Swap(_vec, i, _indexVec);
                    }
                }
                _indexVec = 0;
            }

        }
    }
}
