using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Activity : MonoBehaviour
{
    [SerializeField] private Resource productResource;
    [SerializeField] public List<Resource> requiredResources;
    [SerializeField] private GameObject productPrefab;
    [SerializeField] private Transform productSpawnPoint;
    private List<PlayerController> nearbyPlayerControllers = new List<PlayerController>();
    private float progress = 0;
    private List<Resource> availableResources = new List<Resource>();

    private void Update()
    {
        //Handle Production
        if(nearbyPlayerControllers.Count == 0) { return; }
        if (!(requiredResources.Count == 0))
        { 
            foreach (Resource resource in requiredResources) 
            {
                if (!availableResources.Contains(resource)) { return; }
            }
        }
        foreach (var controller in nearbyPlayerControllers)
        {
           if(controller.carryingProduct == null && controller.interactPressed) 
           {
                break;
           }
            return;
        }
        progress += Time.deltaTime;
        Debug.Log("Working...");
        if (progress > productResource.processDuration) 
        {
            progress = 0;
            GameObject product = 
                Instantiate(productPrefab,productSpawnPoint.position,productSpawnPoint.rotation);
            product.GetComponent<Product>().product = productResource;
            availableResources = new List<Resource>();
            Debug.Log("Finished");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            nearbyPlayerControllers.Add(other.GetComponent<PlayerController>());
        }
        else if(other.gameObject.CompareTag("Product"))
        {
            Product product = other.GetComponent<Product>();
            if (requiredResources.Contains(product.product) && !availableResources.Contains(product.product)) 
            {
                availableResources.Add(product.Consume());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearbyPlayerControllers.Remove(other.GetComponent<PlayerController>());
        }
    }
}
