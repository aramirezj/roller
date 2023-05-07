using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    public GameObject player;
    public float triggerDistance;
    private CamaraController camara;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= triggerDistance && JugadorControler.hasTheKey)
        {
            SceneManager.LoadScene("Level_3");

        }
    }

   

 
}
