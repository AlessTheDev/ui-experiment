using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class LinkedTile : MonoBehaviour
{
    [SerializeField] private GameObject mask;

    [SerializeField] private SpriteRenderer fillSr;
    [SerializeField] private SpriteRenderer outlineSr;

    private Color startOutlineColor;

    private void Start()
    {
        startOutlineColor = outlineSr.color;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MaskTrigger"))
        {
            mask.SetActive(true);
            TileTrigger trigger = collision.gameObject.GetComponent<TileTrigger>();
            outlineSr.color = trigger.outlineColor; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MaskTrigger"))
        {
            mask.SetActive(false);
            ResetTile();
        }
    }

    private void ResetTile()
    {
        outlineSr.color = startOutlineColor;
        fillSr.gameObject.SetActive(false);
    }
}
