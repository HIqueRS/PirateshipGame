using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Input", menuName = "Scriptables/Input")]
public class InputSchema : ScriptableObject
{
    [SerializeField]
    private KeyCode[] _leftRot;
    [SerializeField]
    private KeyCode[] _rightRot;
    [SerializeField] 
    private KeyCode[] _foward;
    [SerializeField] 
    private KeyCode[] _fireFoward;
    [SerializeField] 
    private KeyCode[] _fireSideways;

    private bool IsPressed(KeyCode[] key)
    {
        foreach (KeyCode k in key)
        {
            if (Input.GetKey(k))
            {
                return true;
            }
        }
        return false;
    }

    public bool LeftPressed()
    {
        return IsPressed(_leftRot);
    }

    public bool RightPressed()
    {
        return IsPressed(_rightRot);
    }

    public bool FowardPressed()
    {
        return IsPressed(_foward);
    }

    public bool FireFowardPressed()
    {
        return IsPressed(_fireFoward);
    }

    public bool FireSidePressed()
    {
        return IsPressed(_fireSideways);
    }


}
