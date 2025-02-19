using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TriggerLampu : MonoBehaviour
{

    public bool isPlayerOnArea;

    public GameObject canvasText;
    public GameObject canvasParent;

    public UnityEvent triggerEvent;
    public UnityEvent triggerEventOnExit;
    public UnityEvent triggerEventOnEnter;

    // Start is called before the first frame update
    void Start()
    {
        canvasText.SetActive(false);
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvasText.SetActive(true);
            isPlayerOnArea = true;
            //Debug.Log("Player Msuk");
            triggerEventOnEnter.Invoke();

            SetCanvas(other.transform); 
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canvasText.SetActive(false);
            isPlayerOnArea = false;
            triggerEventOnExit.Invoke();
            Debug.Log("Player Keluar");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnOffButton();
        }
    }

    public void OnOffButton()
    {
        if (isPlayerOnArea)
        {
            triggerEvent.Invoke();
        }

    }
    public void SetCanvas(Transform player)
    {
        canvasParent.transform.LookAt(player);
    }
    
}
