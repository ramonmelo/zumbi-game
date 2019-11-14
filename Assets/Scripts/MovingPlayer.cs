using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MovingCharacter
{
    public void Rotate(LayerMask groundMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundMask))
        {
            Vector3 origin = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Vector3 direction = origin - transform.position;

            Rotate(direction);
        }
    }
}
