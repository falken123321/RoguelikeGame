using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletController : MonoBehaviour
{

    private PlayerData pd;

    public PlayerData Pd
    {
        get => pd;
        set => pd = value;
    }
}
