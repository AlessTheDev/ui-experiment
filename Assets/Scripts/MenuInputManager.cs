using UnityEngine;

public class MenuInputManager : MonoBehaviour
{
    public static bool Up => Input.GetKeyDown(KeyCode.W);
    public static bool Down => Input.GetKeyDown(KeyCode.S);
    public static bool Left => Input.GetKeyDown(KeyCode.A);
    public static bool Right => Input.GetKeyDown(KeyCode.D);
}
