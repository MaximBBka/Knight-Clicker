using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStrongTrigger : MonoBehaviour
{
    [SerializeField] private CheckPlayer checkPlayer;
    private void OnDrawGizmos()
    {
        Gizmos.color = checkPlayer.color;
        Gizmos.DrawWireSphere(transform.position, checkPlayer.radius);
    }

    private void Update()
    {
        if (checkPlayer.Check(transform) && Input.GetMouseButtonDown(0))
        {
            MainUI.Instance.AddTotalStrong();
            MainUI.Instance.FeildDown();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MainUI.Instance.WindowUpStrong.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MainUI.Instance.WindowUpStrong.gameObject.SetActive(false);
        }
    }
}
