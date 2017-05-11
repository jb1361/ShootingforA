
using UnityStandardAssets.CrossPlatformInput;
public class MyCrossPlatformInputManager : IplayerInputController
{
    public float GetAxisRaw(string axisName)
    {
        return CrossPlatformInputManager.GetAxisRaw(axisName);
    }
}
