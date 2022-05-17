
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class DebugLogButton : UdonSharpBehaviour
{

    [SerializeField] GameObject DebugTextObject;
    [SerializeField] TextMeshPro DebugText;
    bool DebugFlag = false;

    void Interact()
    {
        if (!Networking.LocalPlayer.isMaster) return;
        if (DebugFlag) SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NetworkEventDebugOff");
        else SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NetworkEventDebugOn");
    }
    public void NetworkEventDebugOn(){
        if(!DebugFlag) Print("デバッグログが有効になりました 答えが表示されるので注意");
        DebugFlag = true;
        DebugTextObject.SetActive(true);
    }
    public void NetworkEventDebugOff(){
        DebugFlag = false;
        DebugTextObject.SetActive(false);
    }

    public void OnPlayerJoined(VRCPlayerApi player)
    {
        if (!Networking.LocalPlayer.isMaster) return;
        if (DebugFlag) SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NetworkEventDebugOn");
        else SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "NetworkEventDebugOff");
    }


    private void Print(string Text)
    {
        Debug.Log(Text);
        DebugText.text += Text + "\n";
        if (DebugText.text.Length > 1000) DebugText.text = DebugText.text.Substring(DebugText.text.Length - 1000);
    }

}
