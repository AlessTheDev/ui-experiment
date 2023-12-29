using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class ChainButtons : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private CharacterButton[] buttons;

    private int currentButton = 0;

    [Header("Settings")]
    [SerializeField] private float distance = 0.1f;
    [SerializeField] private float startOffset = 0.4f;
    [SerializeField] private float additionalButtonRotation = -80;
    [SerializeField] private float moveSpeed = 2;

    [Header("MaskBackgrounds")]
    [SerializeField] private Animator scstefanMask;
    [SerializeField] private Animator alessMask;
    [SerializeField] private Animator mirkoMask;
    [SerializeField] private Animator bluwolfMask;

    [Header("MaskTriggers")]
    [SerializeField] private GameObject scstefanTrigger;
    [SerializeField] private GameObject alessTrigger;
    [SerializeField] private GameObject mirkoTrigger;
    [SerializeField] private GameObject bluwolfTrigger;

    private float offset;

    private float3 position;
    private float3 forward;
    private float3 upVector;

    private float buttonWidth;

    private void Start()
    {
        buttonWidth = buttons[0].GetComponent<RectTransform>().localScale.x;

        ButtonsState();
    }

    private void Update()
    {
        GetInput();
        UpdateOffset();
        UpdateButtons();
    }

    private void GetInput()
    {
        if (MenuInputManager.Up && currentButton > 0)
        {
            currentButton--;
            ButtonsState();
        }
        if (MenuInputManager.Down && currentButton < buttons.Length - 1)
        {
            currentButton++;
            ButtonsState();    
        }
    }

    private void UpdateOffset()
    {
        float newOffset = startOffset - (startOffset / (buttons.Length) * 2) * currentButton;
        offset = Mathf.Lerp(offset, newOffset, Time.deltaTime * moveSpeed);
    }

    private void UpdateButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            splineContainer.Evaluate(0, i * distance + offset, out position, out forward, out upVector);

            // Set the position
            buttons[i].transform.position = (Vector3)position + new Vector3(buttonWidth + 0.5f, 0, 0);

            Vector3 direction = Vector3.Cross(forward, upVector).normalized;
            // Calculate the angle (in degrees) from the forward vector
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + additionalButtonRotation;

            // Create the rotation quaternion from the Euler angle, rotating only around the Z-axis
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            buttons[i].transform.rotation = rotation;
        }
    }

    private void ButtonsState()
    {
        alessMask.SetBool("active", false);
        bluwolfMask.SetBool("active", false);
        scstefanMask.SetBool("active", false);
        mirkoMask.SetBool("active", false);

        alessTrigger.SetActive(false);
        bluwolfTrigger.SetActive(false);
        scstefanTrigger.SetActive(false);
        mirkoTrigger.SetActive(false);

        foreach(CharacterButton button in buttons)
        {
            button.RemoveHighlight();
        }

        buttons[currentButton].Highlight();

        switch (buttons[currentButton].ButtonAction)
        {
            case ButtonAction.AlessSelect:
                alessMask.SetBool("active", true);
                alessTrigger.SetActive(true);
                break;
            case ButtonAction.BluwolfSelect:
                bluwolfMask.SetBool("active", true);
                bluwolfTrigger.SetActive(true);
                break;
            case ButtonAction.MirkoSelect:
                mirkoMask.SetBool("active", true);
                mirkoTrigger.SetActive(true);
                break;
            case ButtonAction.ScstefanSelect:
                scstefanMask.SetBool("active", true);
                scstefanTrigger.SetActive(true);
                break;
        }
    }
}
