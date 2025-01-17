using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
   void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "red")
        {
            base.gameObject.GetComponent<Collider>().enabled = false;
            target.gameObject.GetComponent<MeshRenderer>().enabled = true;
            target.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            base.GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse);
            
            Destroy(base.gameObject, .5f);
            print("Game Over");
        }
        else
        {
           
            base.gameObject.GetComponent<Collider>().enabled = false;
            GameObject gameObject = Instantiate(Resources.Load("splash1")) as GameObject;
            gameObject.transform.parent = target.gameObject.transform;
            Destroy(gameObject, 0.1f);
            target.gameObject.name = "color";
            target.gameObject.tag = "red";
            StartCoroutine(ChangesColor(target.gameObject));
        }
    }

    IEnumerator ChangesColor(GameObject g)
    {
        yield return new WaitForSeconds(0.1f);
        g.gameObject.GetComponent<MeshRenderer>().enabled = true;
        g.gameObject.GetComponent<MeshRenderer>().material.color = Ball.color;
        Destroy(base.gameObject);
    }




}
