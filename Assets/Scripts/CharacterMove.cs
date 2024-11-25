using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 3f;
    private bool isFacingRight = true;
    
    void Update()
    {
        //Get the inputs of the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Convert inputs to vectors
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        //Limit the character's movement to the XZ plane
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);

        UpdateFacingDirection(horizontal);
    }

    void UpdateFacingDirection(float horizontalInput)
    {
        
        if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
        
        else if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        
        isFacingRight = !isFacingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
