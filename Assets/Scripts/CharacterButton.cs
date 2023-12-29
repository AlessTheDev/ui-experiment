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

    public void Highlight()
    {
        overlay.SetActive(true);
    }

    public void RemoveHighlight()
    {
        overlay.SetActive(false);
    }
}
