using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
  [SerializeField] PlayerData playerData;
  // [SerializeField]
  // GameObject slot1Full, slot1Half, slot2Full, slot2Half, slot3Full,
  //     slot3Half, slot4Full, slot4Half;

  public GameObject[] hearts;

  public void SetHearts()
  {
    for (int i = 0; i < playerData.healthMax; i++)
    {
      hearts[i].SetActive(false);
    }

    for (int i = 0; i < playerData.health; i++)
    {
      hearts[i].SetActive(true);
    }
  }

  // void Update()
  // {
  //   if (playerData.health >= 8)
  //   {
  //     slot4Full.SetActive(true);
  //     slot4Half.SetActive(true);
  //     slot3Full.SetActive(true);
  //     slot3Half.SetActive(true);
  //     slot2Full.SetActive(true);
  //     slot2Half.SetActive(true);
  //     slot1Full.SetActive(true);
  //     slot1Half.SetActive(true);
  //   }
  //   else if (playerData.health == 7)
  //   {
  //     slot4Full.SetActive(false);
  //     slot4Half.SetActive(true);
  //     slot3Full.SetActive(true);
  //     slot3Half.SetActive(true);
  //     slot2Full.SetActive(true);
  //     slot2Half.SetActive(true);
  //     slot1Full.SetActive(true);
  //     slot1Half.SetActive(true);
  //   }
  //   else if (playerData.health == 6)
  //   {
  //     slot4Full.SetActive(false);
  //     slot4Half.SetActive(false);
  //     slot3Full.SetActive(true);
  //     slot3Half.SetActive(true);
  //     slot2Full.SetActive(true);
  //     slot2Half.SetActive(true);
  //     slot1Full.SetActive(true);
  //     slot1Half.SetActive(true);
  //   }
  //   else if (playerData.health == 5)
  //   {
  //     slot4Full.SetActive(false);
  //     slot4Half.SetActive(false);
  //     slot3Full.SetActive(false);
  //     slot3Half.SetActive(true);
  //     slot2Full.SetActive(true);
  //     slot2Half.SetActive(true);
  //     slot1Full.SetActive(true);
  //     slot1Half.SetActive(true);
  //   }
  //   else if (playerData.health == 4)
  //   {
  //     slot4Full.SetActive(false);
  //     slot4Half.SetActive(false);
  //     slot3Full.SetActive(false);
  //     slot3Half.SetActive(false);
  //     slot2Full.SetActive(true);
  //     slot2Half.SetActive(true);
  //     slot1Full.SetActive(true);
  //     slot1Half.SetActive(true);
  //   }
  //   else if (playerData.health == 3)
  //   {
  //     slot4Full.SetActive(false);
  //     slot4Half.SetActive(false);
  //     slot3Full.SetActive(false);
  //     slot3Half.SetActive(false);
  //     slot2Full.SetActive(false);
  //     slot2Half.SetActive(true);
  //     slot1Full.SetActive(true);
  //     slot1Half.SetActive(true);
  //   }
  //   else if (playerData.health == 2)
  //   {
  //     slot4Full.SetActive(false);
  //     slot4Half.SetActive(false);
  //     slot3Full.SetActive(false);
  //     slot3Half.SetActive(false);
  //     slot2Full.SetActive(false);
  //     slot2Half.SetActive(false);
  //     slot1Full.SetActive(true);
  //     slot1Half.SetActive(true);
  //   }
  //   else if (playerData.health == 1)
  //   {
  //     slot4Full.SetActive(false);
  //     slot4Half.SetActive(false);
  //     slot3Full.SetActive(false);
  //     slot3Half.SetActive(false);
  //     slot2Full.SetActive(false);
  //     slot2Half.SetActive(false);
  //     slot1Full.SetActive(false);
  //     slot1Half.SetActive(true);
  //   }
  //   else if (playerData.health < 1)
  //   {
  //     slot4Full.SetActive(false);
  //     slot4Half.SetActive(false);
  //     slot3Full.SetActive(false);
  //     slot3Half.SetActive(false);
  //     slot2Full.SetActive(false);
  //     slot2Half.SetActive(false);
  //     slot1Full.SetActive(false);
  //     slot1Half.SetActive(false);
  //   }
  // }
}
