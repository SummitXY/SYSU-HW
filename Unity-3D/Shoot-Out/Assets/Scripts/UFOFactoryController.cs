using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFactoryController : MonoBehaviour
{
    public GameObject disk;

    void Awake()
    {
        UFOFactory.getInstance().disk = disk;
    }
}