using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera Cam1, Cam2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Showshop()
    {
        Cam2.Priority++;
        Cam1.Priority--;
    }
    public void BackToMenu()
    {
        Cam2.Priority--;
        Cam1.Priority++;
    }
}
