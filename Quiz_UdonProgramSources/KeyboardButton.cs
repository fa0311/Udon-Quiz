using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class KeyboardButton : UdonSharpBehaviour
{
    void Interact()
    {
        Vector3 LocalPos = transform.localPosition;
        LocalPos.y = -100.0f;
        transform.localPosition = LocalPos;
    }
}
