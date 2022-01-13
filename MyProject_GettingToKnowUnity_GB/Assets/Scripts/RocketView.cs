using UnityEngine;
using System.Collections;

public class RocketView : MonoBehaviour
{

    RocketController _rocketControlle = new RocketController();

    private void Start()
    {
            
    }

    private void NextLevel() => _rocketControlle.NextLevel();

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "FinishPad":
                Invoke("NextLevel", 2f);
                break;
            default:
                break;
        }
    }
}
