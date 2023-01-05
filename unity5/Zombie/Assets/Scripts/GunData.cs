using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/Gundata", fileName = "GunData")]
public class GunData : ScriptableObject
{

    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리
    public float damage = 25; // 공격력
    public int magCapacity = 25; // 탄창 용량
    public float fireDistance = 50f; // 사정거리
    public float timeBetFire = 0.12f; // 총알 발사 간격
    public float reloadTime = 1.8f; // 재장전 소요 시간
    public int startAmmo = 100;
}
