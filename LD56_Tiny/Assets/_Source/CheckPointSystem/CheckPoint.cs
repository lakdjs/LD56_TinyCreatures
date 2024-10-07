using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    static Vector3 lastCheckpointPosition = Vector3.zero;
    [SerializeField] Transform playerTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name);
            Teleport();
        }
    }
    private void Start()
    {
        //GetComponent<CharacterController>().enabled = true;
        Teleport();
    }
    public void Teleport()
    {
        if (lastCheckpointPosition != Vector3.zero)
        {
            GetComponent<CharacterController>().enabled = false;
            Debug.Log("Teleport");
            playerTransform.position = new Vector3( lastCheckpointPosition.x, lastCheckpointPosition.y + 1, lastCheckpointPosition.z) ;
            GetComponent<CharacterController>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint");
            lastCheckpointPosition = other.transform.position;
            Debug.Log(lastCheckpointPosition);
        }
    }
}
