using System;
using Oculus.Interaction;
using UnityEngine;

public class RaycastButton : MonoBehaviour, ISelector
{
    public event Action WhenSelected;
    public event Action WhenUnselected;


    private void Start()
    {
    }
}
