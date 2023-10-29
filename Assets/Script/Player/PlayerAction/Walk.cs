using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour, IPlayerMove
{
    // Start is called before the first frame update
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void walk(Vector2 walkVector)
    {
        Debug.Log("•à‚­•ûŒüF" + walkVector);
        float angle = -1 * Mathf.Atan2(walkVector.x, walkVector.y) * Mathf.Rad2Deg;
        Debug.Log("Œü‚­•ûŒüF" + angle);
        transform.rotation = Quaternion.Euler(0, angle, 0);
        //characterController.Move(this.gameObject.transform.forward * MoveSpeed * Time.deltaTime);
        if (walkVector.magnitude > 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }


    }

    public void run() { }


}
