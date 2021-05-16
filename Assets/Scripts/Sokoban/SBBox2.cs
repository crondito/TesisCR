using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SBBox2 : MonoBehaviour
{
    public bool m_OnCross;

    public void Update()
    {
        TestForOnCross();
    }

    public bool Move(Vector2 direction)
    {
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            TestForOnCross();
            return true;
        }
    }

    private bool BoxBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x >= (newPos.x) - 0.1 && wall.transform.position.x <= (newPos.x) + 0.1 &&
                wall.transform.position.y >= (newPos.y) - 0.1 && wall.transform.position.y <= (newPos.y) + 0.1)
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
                SBBox bx = box.GetComponent<SBBox>();
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

    void TestForOnCross()
    {
        GameObject[] crosses = GameObject.FindGameObjectsWithTag("Cross");
        foreach (var cross in crosses)
        {
            if (transform.position.x >= cross.transform.position.x - 0.1 && transform.position.x <= cross.transform.position.x + 0.1 &&
                transform.position.y >= cross.transform.position.y - 0.1 && transform.position.y <= cross.transform.position.x + 0.1)
            {
                GetComponent<Image>().color = Color.grey;
                m_OnCross = true;
                return;
            }
        }
        GetComponent<Image>().color = Color.white;
        m_OnCross = false;
    }
}
