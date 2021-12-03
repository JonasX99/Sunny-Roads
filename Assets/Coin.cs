using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Car")
        {
            int money = PlayerPrefs.GetInt("Money");
            Debug.Log("Money : " + money);
            PlayerPrefs.SetInt("Money", money += 1);
            Debug.Log(PlayerPrefs.GetInt("Money"));
            Destroy(gameObject);
        }
    }
}
