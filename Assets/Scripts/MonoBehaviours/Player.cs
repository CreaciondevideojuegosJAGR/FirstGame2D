using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    public HealthBar healthBarPrefab;
    private HealthBar healthBar;
    void Start()
    {
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                print("Nombre: "+ hitObject.objectName);
                bool shouldDisappear = false;

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        shouldDisappear = true;
                        break;
                    case Item.ItemType.HEALTH:
                        Debug.Log("Cantidad a Incrementar: " + hitObject.quantity);
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }

                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    private bool AdjustHitPoints(int amount) {
        if (hitPoints.value < maxHitPoints)
        {
            hitPoints.value = hitPoints.value + amount;
            print("Ajustando Puntos: " + amount + ". Nuevo Valor: " + hitPoints.value);
            return true;
        }
        return false;
    }
}
