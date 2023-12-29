using UnityEngine;

/// <summary>
/// Simple shake script
/// </summary>
public class Shake : MonoBehaviour
{
    [SerializeField] private float intensity;

    private Vector2 startPos;

    private float timer;

    private void Start()
    {
        startPos  = transform.localPosition;
    }

    private void Update()
    {
        if (timer > 0.1f)
        {
            transform.localPosition = startPos;
        }
        if (timer > 0.2f)
        {
            transform.localPosition = startPos + new Vector2(Random.Range(-1f, 1f) * intensity, Random.Range(-1f, 1f) * intensity);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
