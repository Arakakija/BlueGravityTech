using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private float drag = 0.3f;

    private Vector2 _dampingVelocity;
    private Vector2 _impact;
    private float _verticalVelocity;

    public Vector2 Movement => _impact ;
    
    void FixedUpdate()
    {
        _impact = Vector2.SmoothDamp(_impact, Vector2.zero, ref _dampingVelocity, drag);
    }

    public void AddForce(Vector2 force)
    {
        _impact += force;
    }
}
