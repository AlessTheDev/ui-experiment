using UnityEngine;

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
