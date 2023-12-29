using UnityEngine;

/// <summary>
/// Class to help with the creation of the metal chain
/// </summary>
public class MetalChainGenerator : MonoBehaviour
{
    [SerializeField] private int toSpawn;
    [SerializeField] private TileRow row;

    private void Start()
    {
        row.Spawn(toSpawn);
    }
}
