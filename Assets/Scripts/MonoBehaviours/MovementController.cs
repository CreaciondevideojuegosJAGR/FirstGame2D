using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Autor: Jose Armando Gutierrez Rodriguez

public class MovementController : MonoBehaviour
{

    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D rd2D;
    Animator animator;
    string animationState = "AnimationState";
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }

    
    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        this.UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rd2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        } else if (movement.x < 0) {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        } else if (movement.y < 0) {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        } else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        } else
        {
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
        }
    }
}
