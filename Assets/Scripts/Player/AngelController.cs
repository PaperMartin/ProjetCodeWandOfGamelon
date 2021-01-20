using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour
{

    private AngelActions _angelActions;

    private void Awake()
    {
        _angelActions = new AngelActions();
    }

    private void OnDisable()
    {
        _angelActions.Disable();
    }

    private void OnEnable()
    {
        _angelActions.Enable();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        _angelActions.Base.Walk.ReadValue<Vector2>();
    }
}
