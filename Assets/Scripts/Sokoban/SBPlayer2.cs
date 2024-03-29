using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBPlayer2 : MonoBehaviour
{
    public bool Move(Vector2 direction)
    {
        // Debug.Log("Player is moving");
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
        if (Blocked(transform.position, direction))
        {
            FindObjectOfType<SoundManagerScript>().Play("Blocked");
            return false;
        }
        else
        {
            transform.Translate(direction);
            FindObjectOfType<SoundManagerScript>().Play("Step");
            return true;
        }
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x >= (newPos.x)-0.1 && wall.transform.position.x <= (newPos.x)+0.1 &&
                wall.transform.position.y >= (newPos.y)-0.1 && wall.transform.position.y <= (newPos.y)+0.1)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x >= (newPos.x) - 0.1 && box.transform.position.x <= (newPos.x) + 0.1 &&
                box.transform.position.y >= (newPos.y) - 0.1 && box.transform.position.y <= (newPos.y) + 0.1)
            {
                SBBox2 bx = box.GetComponent<SBBox2>();
                if (bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
}
