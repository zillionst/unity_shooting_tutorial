using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    GameObject GameController;

    void Start()
    {
        GameController = GameObject.Find("GameController");
    }

    void OnTriggerEnter(Collider other)
    {

        GameObject exp = explosion != null ? explosion : playerExplosion;
        Transform trans = transform;
        if (other.tag == "Enemy") {
            return;
        }
        if (other.name == "vehicle_playerShip")
        {
            exp = playerExplosion;
            trans = other.transform;
            GameController.GetComponent<GameController>().GameOver();
        }
        else {
            GameController.GetComponent<GameController>().AddScore(10);
        }
        Instantiate(exp, trans.position, trans.rotation);

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
