using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    private List<PlayerController> nearbyPlayerControllers = new List<PlayerController>();
    public Resource product;
    private void Update()
    {
        if (nearbyPlayerControllers.Count == 0) { return; }
        foreach (var controller in nearbyPlayerControllers)
        {
            if (controller.carryingProduct == null && controller.interactPressed)
            {
                controller.carryingProduct = this.gameObject;
                transform.position = controller.carryingPoint.position;
                transform.SetParent(controller.carryingPoint);
                break;
            }
            else if(controller.carryingProduct != null && !controller.interactPressed) 
            {
                controller.carryingProduct = null;
                transform.SetParent(null);
                nearbyPlayerControllers.Clear();
            }
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        nearbyPlayerControllers.Add(other.GetComponent<PlayerController>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        nearbyPlayerControllers.Remove(other.GetComponent<PlayerController>());
    }

    public Resource Consume()
    {
        Destroy(gameObject);
        return product;
    }
}
