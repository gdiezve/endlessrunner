using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    public ScoreManager scoreManager;
    private int changeSpeedScore = 10;

    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.down;
        if (scoreManager.GetScore() == changeSpeedScore) {
            moveSpeed += 1f;
            changeSpeedScore += 10;
        }
    }
}
