using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class ChainCircles : MonoBehaviour
{
    [SerializeField] private Color32[] colorVariants = new Color32[2];

    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private GameObject chainObject;

    private void Start()
    {
        GenerateCircles();
    }

    private void GenerateCircles()
    {
        SpriteRenderer chainObjectRenderer = chainObject.GetComponent<SpriteRenderer>();
        float splineLength = splineContainer.CalculateLength();

        float STEP = chainObjectRenderer.bounds.size.x / splineLength;

        int count = 0;

        for (float currentStep = 0; currentStep < splineLength; currentStep += STEP)
        {
            splineContainer.Evaluate(0, currentStep, out float3 position, out float3 forward, out float3 upVector);

            // Calculate the angle from the forward vector
            float angle = Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg;

            // Create the rotation quaternion from the Euler angle, rotating only around the Z-axis
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject newObject = Instantiate(chainObject, position, rotation, transform);

            newObject.GetComponent<SpriteRenderer>().color = colorVariants[count % 2];

            count++;
        }
    }
}
