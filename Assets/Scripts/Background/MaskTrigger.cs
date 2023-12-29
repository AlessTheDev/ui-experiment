using UnityEngine;

[System.Obsolete]
public class EffectsTester : MonoBehaviour
{
    [SerializeField] private float maxRadius = 5;
    [SerializeField] private float interval = 5;
    [SerializeField] private float speed = 2;

    private float radius;

    private float timer;
    private void Start()
    {
        timer = interval;
    }
    private void Update()
    {
        if(timer <= 0)
        {
            timer = interval;

            transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            radius = 0;
        }

        radius = Mathf.Lerp(radius, maxRadius, speed * Time.deltaTime);
        transform.localScale = Vector2.one * radius;

        timer -= Time.deltaTime;
    }
}
