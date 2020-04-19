using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    private void Awake()
    {
        Message.MessageBox = GetComponent<Text>();
    }
}
