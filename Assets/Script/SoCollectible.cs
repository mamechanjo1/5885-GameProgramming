using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectibles", fileName = "New Collectible")]

public class SoCollectible : ScriptableObject
{
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlinedSprite;
    [SerializeField] private bool respawnable;
}
