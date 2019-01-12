using UnityEngine;

public class ShipHit : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Ship;
    public GameObject Ship
    {
        get
        {
            return m_Ship;
        }

        set
        {
            m_Ship = value;
        }
    }

    [SerializeField]
    private GameObject m_Explosion;
    public GameObject Explosion
    {
        get
        {
            return m_Explosion;
        }

        set
        {
            m_Explosion = value;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
#if UNITY_EDITOR
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
#endif

        if (Ship && Explosion)
        {
            var shipPosition = Ship.transform.position;
            var shipRotation = Ship.transform.rotation;

            var newExplosion = Instantiate(Explosion, shipPosition, shipRotation) as GameObject;
            newExplosion.transform.parent = Ship.transform.parent;
        }

        if (Ship)
        {
            Destroy(Ship);
        }
    }
}
