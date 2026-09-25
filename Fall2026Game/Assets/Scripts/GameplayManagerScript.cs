using System;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
//using TMPro;


public class GameplayManagerScript : MonoBehaviour
{

    public enum MoveType
    {
        MoveDistance,
        MoveToTarget,
        MoveToClick,
    }

    [Header("Movement")]
    public MoveType moveType;

    public float moveDistance = 2f;
    public float moveTime = 0.5f;
    public Transform targetPosition;

    [Header("Click Movement")]
    public Camera mainCamera;

    [Header("Score")]
    //public TextMeshProUGUI scoreText;
    public int score = 0;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        //spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (moveType == MoveType.MoveToClick)
            {
                MoveToClickedPosition(Input.mousePosition);
            }
            else
            {
                Move();
            }
        }
    }

    void Move()
    {
        //distance forward
        if (moveType == MoveType.MoveDistance)
        {
            Vector3 newPosition = transform.position + transform.forward * moveDistance;
            transform.DOMove(targetPosition.position, moveTime);
        }
        
        //move to gameobject
        if (moveType == MoveType.MoveToTarget)
        {
            transform.DOMove(targetPosition.position, moveTime);
        }
    }

    void MoveToClickedPosition(Vector2 screenPosition)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 newPosition = hit.point;
            newPosition.y = transform.position.y;
            transform.DOMove(newPosition, moveTime).SetEase(Ease.Linear);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            //score++;
            //UpdateScore();
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("GAME OVER");
            Destroy(this.gameObject);
        }
    }
    
    /*
     * void UpdateScore()
     * {
     *      scoreText.text = scoreText.ToString();
     * }
     */
    
    
    
    
    
    
    
    
    
    
}
