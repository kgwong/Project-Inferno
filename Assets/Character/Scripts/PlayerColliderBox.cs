using UnityEngine;
using System.Collections.Generic;

public class PlayerColliderBox: MonoBehaviour
{
    private Dictionary<PlayerStateEnum, BoxCollider2D> _colliders;
    private PlayerStateController _controller;
    private BoxCollider2D _current;

    void Start() 
    {
        _controller = GetComponent<PlayerStateController>();
        initColliders();
    }
    
    void FixedUpdate()
    {
        _current.enabled = false;
        _current = _colliders[_controller.GetState()]; 
        _current.enabled = true;
    }

    private void initColliders()
    {
        _colliders = new Dictionary<PlayerStateEnum, BoxCollider2D>();

        foreach (PlayerStateEnum state in System.Enum.GetValues(typeof(PlayerStateEnum)))
        {
            BoxCollider2D bc = PlayerColliderBoxFactory.Get(gameObject, state);
            bc.enabled = false;
            _colliders.Add(state, bc);
        }

        _current = _colliders[PlayerStateEnum.TestIdle];
    }
}
