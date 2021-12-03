using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{

    public TextMeshProUGUI CoinText;
    void Update()
    {
        CoinText.text = PlayerPrefs.GetInt("Money").ToString();
    }
}
