using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform Player;
    public SwipeControls Controls;
    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;
    private void Start()
    {
        Player = GetComponent<Transform>();
    }
    
    private void Update()
    {

        if (Lane3 == true && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }

        else if (Lane1 == true && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        else if (Lane2 == true && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane2 == true && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
    }

}
