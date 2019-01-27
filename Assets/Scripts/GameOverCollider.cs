using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollider : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerAttributes>() != null && other.gameObject.GetComponent<PlayerAttributes>().isActiveAndEnabled)
        {

            GameObject.Find("Menu UI").GetComponent<GameOver>().isGameOver = true;
        }
    }
}
