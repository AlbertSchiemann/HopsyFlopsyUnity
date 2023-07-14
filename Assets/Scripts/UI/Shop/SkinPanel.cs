using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPanel : MonoBehaviour
{
    public GameObject skinToEquip;
    private SkinLoader player;
    private void Awake()
    {
        player = GameObject.Find("Player3D Grid").GetComponent<SkinLoader>();
    }
    public void EquipSkin()
    {
        player.ChangeSkin(skinToEquip);
    }
}
