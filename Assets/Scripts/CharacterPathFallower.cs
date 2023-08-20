using System.Collections.Generic;
using UnityEngine;

public class CharacterPathFallower : MonoBehaviour
{
    [SerializeField] private List <Transform> _pathPoints;
    private int _listLenght, _listLenghtCounter=0;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    [SerializeField] private float _speed =5f;
    private float _rotationSpeed = .5f;
    private float _distance;
    

    private void Start()
    {
        _pathPoints = new List<Transform>(DynamicPathListCreator.pathPoints);
        _listLenght = _pathPoints.Count;                                      
    }

    private void Update()
    {
        if(InputManager.canMove)
            ListOutOfRangeController();        
    }

    private void ListOutOfRangeController()
    {
        if (_listLenghtCounter < _listLenght)
        {
            Move();
            SetDistance();           
        }
    }

    private void SetDistance()
    {
        _distance = CalculateDistance(_startPosition, _targetPosition);
        if (_distance < .1f)
        {
            _listLenghtCounter++;
        }
        
    }

    private float CalculateDistance(Vector3 startPosition, Vector3 targetPosition)
    {
        return Vector3.Distance(_startPosition, targetPosition);
    }

    private void Move()
    {
        _startPosition = transform.position;
        _targetPosition = _pathPoints[_listLenghtCounter].transform.position;
        Rotate();
        transform.position = Vector3.MoveTowards(_startPosition, _targetPosition, _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        Quaternion targetRotation = CalculateTargetRotation(_pathPoints[_listLenghtCounter].transform.position - transform.position);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,_rotationSpeed / Mathf.Clamp01(_distance) * Time.deltaTime); //dynamic rotation
        

        
    }

    private Quaternion CalculateTargetRotation(Vector3 direction)
    {
        return Quaternion.LookRotation(direction, Vector3.up);
    }

}

