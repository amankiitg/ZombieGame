using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Player : MonoBehaviour
{

    public TextMeshProUGUI textMeshProUGUI;
    private int score;

    public Transform vrCamera;
    public float angle=30.0f;
    public float speed=-40.0f;
    public bool moveForward;

    private CharacterController cc;
    //private bool movement = true;
    private GameObject gun;

    public void shoot()
    {
        Debug.Log("shoot");
        score +=1;
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        gun.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textMeshProUGUI.text = "Score: " + score;
        cc = GetComponent<CharacterController>();
        gun = gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
    }

    

    


    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "Score: " + score;
        if(vrCamera.eulerAngles.x>angle && vrCamera.eulerAngles.x < 90.0f){
            moveForward=true;
        } else{
            moveForward=false;
        }

        if(moveForward){
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            //console.log('Forward');
            cc.SimpleMove(speed*forward);
        }
    }

    
}
