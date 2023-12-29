using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalChainGenerator : MonoBehaviour
{
    [SerializeField] private int toSpawn;
    [SerializeField] private TileRow row;

    private void Start()
    {
        row.Spawn(toSpawn);
    }
}
