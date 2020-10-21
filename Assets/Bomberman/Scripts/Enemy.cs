using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private Vector2 moveDirection;

    private bool _isInMovement;
    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position, moveDirection, 1f, raycastMask);
        if (hit.collider == null)
        {
            var direction = transform.position + moveDirection;
            transform.DOMove(direction, 0.5f)
        }
        else
        {
            var direction = transform.position - moveDirection;
            transform.DOMove(direction, 0.5f)
        }
    }
    
    private bool Raycast(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir, 1f,raycastMask);
        return hit.collider != null;
    }
}
