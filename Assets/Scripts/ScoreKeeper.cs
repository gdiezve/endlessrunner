using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Trash")) {
            Debug.Log("Trash discount");
            if (ScoreManager.instance.GetScore() > 0) {
                ScoreManager.instance.ChangeScore(-1);
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("Enemy point");
            ScoreManager.instance.ChangeScore(+1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Wave")) {
            Destroy(collision.gameObject);
        }
    }
}
