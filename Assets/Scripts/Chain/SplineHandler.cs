using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SplineHandler : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField][Range(0f, 1f)] private float time;

    private float3 position;
    private float3 forward;
    private float3 upVector;

    private void Update()
    {
        splineContainer.Evaluate(0, time, out position, out forward, out upVector);

        transform.position = position;
    }
}
