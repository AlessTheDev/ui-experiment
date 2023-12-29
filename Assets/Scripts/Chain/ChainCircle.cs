using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCircle : MonoBehaviour
{
    [SerializeField] private GameObject blackCircle;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If it collides with a button
        if(collision.gameObject.layer == LayerMask.NameToLayer("UI"))
        {
            blackCircle.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        blackCircle.SetActive(false);
    }
}
