using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed=30;
    private PlaayerController playaercontrollerScript;
    private float leftBoundary = -15;

    // Start is called before the first frame update
    void Start()
    {
        playaercontrollerScript =GameObject.Find("Player").GetComponent<PlaayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playaercontrollerScript.gameOver==false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x<leftBoundary && gameObject.CompareTag("Obstracle"))
        {
            Destroy(gameObject);
        }
       
    }
}
