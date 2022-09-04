using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    public Vector2 MovementInput;
    public Vector3 AimForwardVector;
    public NetworkBool IsJumpPressed;

}
