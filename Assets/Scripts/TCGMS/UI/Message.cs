using UnityEngine.UI;

public class Message
{
    public static Text MessageBox;

    public void SetText(string message)
    {
        MessageBox.text = message;
    }
}
