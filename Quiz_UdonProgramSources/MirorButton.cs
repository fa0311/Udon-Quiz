
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MirorButton : UdonSharpBehaviour
{
    [SerializeField] GameObject Object;
    bool Flag = false;

    void Interact()
    {
        Flag = !Flag;
        Object.SetActive(Flag);
    }
}
