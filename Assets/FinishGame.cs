using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FinishGame : MonoBehaviour
{
    public CinemachineVirtualCamera Cam1, Cam2;
    public ParticleSystem Part1, Part2;
    public GameObject GameUI, FinishUI;
    private CarController LinkToCar;

    // Start is called before the first frame update
    void Start()
    {
        LinkToCar = GameObject.FindGameObjectWithTag("Player").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.name == "Car")
        {
            LinkToCar.CanDrive = false;
            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene()
    {
        GameUI.SetActive(false);
        Part1.Stop();
        Part2.Stop();
        Cam1.Priority--;
        Cam2.Priority++;
        yield return new WaitForSeconds(0.5f);
        LinkToCar.StopWheels();
        yield return new WaitForSeconds(0.2f);
        FinishUI.SetActive(true);
    }
}
