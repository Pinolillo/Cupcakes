using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
//Velocidad del movimiento
public float movementSpeed = 2f;
//Potencia del salto
public float jumpForce = 7f;
// bool para saber si está tocando el suelo
bool isGrounded;
Rigidbody2D rigid;
       void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
    
    }

    //El movimiento se pone aca para que solo cuando se mande a llamar se use y no cada frame
    private void FixedUpdate() {
    Movimiento();   
    }
    

    //Esto es para detectar si está o no en el suelo y solo salte cuando esté en el suelo
    private void OnCollisionEnter2D(Collision2D other) {
           isGrounded = true;
           Debug.Log("Estoy en el suelo");
    }
    
    private void OnCollisionExit2D(Collision2D other) {
         isGrounded = false;   
         Debug.Log("Ya no estoy en el suelo");
    }
      
    
    // Método donde está movimiento y salto
    void Movimiento(){
    //Movimiento 
    var movement = Input.GetAxis("Horizontal");
    transform.position += new Vector3(movement, 0,0) * Time.deltaTime * movementSpeed;
    //Salto
    if(Input.GetButtonDown("Jump") && isGrounded == true){
    rigid.AddForce(new Vector2 (0, jumpForce), ForceMode2D.Impulse);
     }
    }

}
