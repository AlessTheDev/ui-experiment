using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonAction
{
    AlessSelect,
    BluwolfSelect,
    ScstefanSelect,
    MirkoSelect
}

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private ButtonAction action;
    [SerializeField] private GameObject overlay;

    public ButtonAction ButtonAction { get { return action; } }

    private bool highlighted = false;
    public void Highlight()
    {
        overlay.SetActive(true);
    }

    public void RemoveHighlight()
    {
        overlay.SetActive(false);
    }
}
