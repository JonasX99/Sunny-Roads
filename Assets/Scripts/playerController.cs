using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private CharacterController controller;
    public float Speed;
    private Vector3 playerVelocity;
    private float gravityValue = -9.8f;
    public GameObject directionalLight;
    public bool inShadow;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Speed * Time.deltaTime);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        Raytrace();
    }
    void Raytrace()
    {
        Vector3 Directiontowards = -directionalLight.transform.forward;
        Directiontowards = Directiontowards.normalized;
        Debug.DrawLine(transform.position, transform.position - Directiontowards);

        inShadow = Physics.Raycast(transform.position, Directiontowards);
    }
}
