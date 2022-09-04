using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Vector2 moveInputVector = Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;
    bool isJumpButtonPressed = false;

    LocalCameraHandler localCameraHandler;
    // Start is called before the first frame update
    void Awake()
    {
        localCameraHandler = GetComponentInChildren<LocalCameraHandler>();

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        // view input 
        viewInputVector.x = Input.GetAxis("Mouse X");
        viewInputVector.y = Input.GetAxis("Mouse Y") * -1f;


        //movement input
        moveInputVector.x = Input.GetAxis("Horizontal");
        moveInputVector.y = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump"))
        isJumpButtonPressed =true;

        localCameraHandler.SetViewInputVector(viewInputVector);

    }

    public NetworkInputData GetNetworkInput()
    {

        NetworkInputData networkInputData = new NetworkInputData();

        // view data 
        networkInputData.AimForwardVector = localCameraHandler.transform.forward;

        //move
        networkInputData.MovementInput = moveInputVector;

        // jump
        networkInputData.IsJumpPressed = isJumpButtonPressed;

        // reset jump variable
        isJumpButtonPressed = false;


        return networkInputData;
    }
}
