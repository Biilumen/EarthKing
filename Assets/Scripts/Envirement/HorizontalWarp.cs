using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWarp : MonoBehaviour
{
    private void OnTriggerExit(Collider colision)
    {
        if (colision.TryGetComponent(out Player player))
        {
            player.transform.position = new Vector3(player.transform.position.x * -1, player.transform.position.y, player.transform.position.z); 
        }
    }
}
