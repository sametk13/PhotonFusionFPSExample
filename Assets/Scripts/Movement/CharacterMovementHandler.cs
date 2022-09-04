using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{


    NetworkCharacterControllerPrototypeCustom characterControllerPrototypeCustom;
    Camera localCamera;

    private void Awake()
    {
        characterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        localCamera = GetComponentInChildren<Camera>();
    }




    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            transform.forward = networkInputData.AimForwardVector;

            Quaternion rotation = transform.rotation;
            rotation.eulerAngles = new Vector3(0, rotation.eulerAngles.y, rotation.eulerAngles.z);
            transform.rotation = rotation;

            // move
            Vector3 moveDirection = transform.forward * networkInputData.MovementInput.y + transform.right * networkInputData.MovementInput.x;
            moveDirection.Normalize();
            characterControllerPrototypeCustom.Move(moveDirection);

            // jmup
            if (networkInputData.IsJumpPressed)
            {
                characterControllerPrototypeCustom.Jump();
            }
        }
    }

    void CheckFallRespawn()
    {
        if (transform.position.y < -12)
            transform.position = Utils.GetRandomSpawnPoint();
    }

}
