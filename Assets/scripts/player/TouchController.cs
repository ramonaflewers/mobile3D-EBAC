using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pastPosition;
    public float velocity = 1f;

private void Start() {
    
}
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - pastPosition.x;
            Move(deltaX);
        }
        pastPosition = Input.mousePosition;
    }
    
    public void Move(float speed)
    {
        Vector3 move = Vector3.right * speed * velocity * Time.deltaTime;
        transform.position += move;
    }
}
