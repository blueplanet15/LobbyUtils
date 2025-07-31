using BepInEx;
using Photon.Pun;

namespace LobbyUtils
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Main
    {
        public static bool RightPrimary = ControllerInputPoller.instance.rightControllerPrimaryButton;
        public static bool RightSecondary = ControllerInputPoller.instance.rightControllerPrimaryButton;

        public static bool LeftPrimary = ControllerInputPoller.instance.rightControllerPrimaryButton;
        public static bool LeftSecondary = ControllerInputPoller.instance.rightControllerPrimaryButton;

        public static bool RightTrigger = ControllerInputPoller.TriggerFloat(UnityEngine.XR.XRNode.RightHand) > 0.5f;
        public static bool RightGrip = ControllerInputPoller.GripFloat(UnityEngine.XR.XRNode.RightHand) > 0.5f;

        public static bool LeftTrigger = ControllerInputPoller.TriggerFloat(UnityEngine.XR.XRNode.LeftHand) > 0.5f;
        public static bool LeftGrip = ControllerInputPoller.GripFloat(UnityEngine.XR.XRNode.LeftHand) > 0.5f;

        public bool FaceButtons = RightPrimary && RightSecondary && LeftPrimary && LeftSecondary;

        public bool OuterButtons = RightTrigger && RightGrip && LeftTrigger && LeftGrip;

        public void Update()
        {
            if (FaceButtons)
                PhotonNetwork.Disconnect();

            if (FaceButtons && OuterButtons)
                PhotonNetwork.Reconnect();
        }
    }

    public class PluginInfo
    {
        public const string GUID = "com.bpgt.lobbyutils";

        public const string Name = "LobbyUtils";

        public const string Version = "1.0.0";
    }
}
