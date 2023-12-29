using UnityEngine;

/// <summary>
/// Class to help with the creation of the metal chain
/// </summary>
public class TileRow : MonoBehaviour
{
    [SerializeField] private Transform spawner;
    [SerializeField] private TileRow tileGroupPrefab;

    public void Spawn(int n)
    {
        if (n <= 0) return;

        TileRow next = Instantiate(tileGroupPrefab, spawner.position, spawner.rotation, transform.parent);

        next.name = "_" + n;
        next.Spawn(n - 1);
    }
}
