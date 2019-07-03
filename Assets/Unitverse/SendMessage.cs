using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessage : MonoBehaviour
{
    public string methodName = "Fire";

    public void Broadcast(Component component)
    {
        component.BroadcastMessage(methodName, SendMessageOptions.DontRequireReceiver);
    }

    public void Send(Component component)
    {
        component.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
    }

    public void SendUpwards(Component component)
    {
        component.SendMessageUpwards(methodName, SendMessageOptions.DontRequireReceiver);
    }
}
