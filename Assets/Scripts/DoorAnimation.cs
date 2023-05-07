using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorAnimation : MonoBehaviour
{
    public Animator animator;
    public Animator thehookah;
    public GameObject player;
    public float triggerDistance;

    private CamaraController camara;
    private bool doorOpened = false;
    

    private void Start()
    {
        if(player == null){
            this.player = FindObjectOfType<JugadorControler>().gameObject;
        }
    }

    private void Update()
    {
        if(player != null)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= triggerDistance && JugadorControler.hasTheKey && !doorOpened)
            {
                Debug.Log("EXECUTED");
                doorOpened = true;
                camara = FindObjectOfType<CamaraController>();
                camara.GetComponent<Camera>().depth = -2;
                animator.SetTrigger("move");
                thehookah.SetTrigger("move");
                StartCoroutine(CallFunctionAfterDelay());
                
                

            }
        }

    }

    IEnumerator CallFunctionAfterDelay()
    {
        Debug.Log(" STARTRTING");
        yield return new WaitForSeconds(15); // Wait for 5 seconds
        Debug.Log("DAFUCK i m executed");
        ReactivateCamera();
    }

    void ReactivateCamera()
    {

        camara.GetComponent<Camera>().depth = 0;
    }


}