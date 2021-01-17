using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{

    [HideInInspector]
    public IngamePlayer player;

    public int requiredTier1;
    public int requiredTier2;
    public int requiredTier3;


    private void Start() {
        player = gameObject.GetComponent<IngamePlayer>();
    }

    public enum ItemType
	{
        None,
		//Armor

        
		//Tier1Armor
		LightHelmet,
		IronHelmet,
		ShootingCape,
		LeatherHarness,

        LightGambeson, 
        ChainHarness,
        LeatherBoots,
        Furboots,
        ChainBoots,

        CopperHelmet,
        ThickShootingCape,
        HeavySteelHelmet,
        BoltedHarness,

		//Tier2Armor
		LeatherGambeson, 
        SteelHarness,
        HardenedLeatherboots,

        LightLeatherBoots, 
        PlatedBoots, 
        HolyforgedHelmet, 
        CobaltCape,

        SunstoneHelmet,
        HolyforgedHarness,
        CobaltHarness,
        SunstoneHarness,

	    //Tier3Armor
		SunstoneBoots,
		ForestBoots,
		HolyforgedBoots,
	


        //Weapons
        
        FullmetalDagger,
        HardenedLongsword,
        LightShield,
        WalnutBow,

        Waterdagger,
        SwordOfRoyalguard,
        HolyforgedShield,
        HolyForgedBow,

        LightsteelDagger,
        MoltenSword,
        LightsteelShield,
        RecurveBow,

        ForestDagger,
        WaterLongsword,
        WaterShortsword,
        Windbow,
        Crystalstaff,

        MoltenDagger,
        WindLongsword,
        MoltenShortsword,
        ForestBow,
        DarkmatterStaff,

        AncientShortsword,
        DarkmatterLongsword,
        ForestShortsword,
        Icebow,
        ForestStaff,


        BoltShortsword,
        AncientSword,
        AncientShield,
        Corebow,
        Boltstaff,

        DarkMatterShortsword,
        BoltSword,
        Oreshield,
        DarkMatterBow,
        CoreStaff,

        DemonicShortsword,
        DemonicLongsword,
        DemonicShield,
        DemonicBow,
        DemonicStaff,

       HolyforgedRing,
       CrystalRing,
       SunstoneRing,
       WaterRing,
       AncientRing,
       VelonstoneRing,
       ForestRing,
       Windring,
       NotARing,
       MoltenRing,
       GreenstoneRing,
       DarkMatterRing,
       BoltRing,
       IceRing,
       RedOreRing





		//Trinkets

		//Tier1Trinkets
	


	}


    public static List<ItemType> unlockedItemTypeList;

    public List<ItemType> returnUnlockedItems() {
        return unlockedItemTypeList;
    }

    public void SetUnlockedList(List<ItemType> unlockedList) {
        unlockedItemTypeList = unlockedList;
    }

    public PlayerItems() {
        unlockedItemTypeList = new List<ItemType>();
    }

    private void UnlockItem(ItemType itemType) {
        if (!IsItemUnlocked(itemType))
            unlockedItemTypeList.Add(itemType);
       
    }

    public bool IsItemUnlocked(ItemType itemtype) {
        if (unlockedItemTypeList.Contains(itemtype)) {
            return true;
        }
        else {
            return false;
        }
    }


    public bool CanUnlock(ItemType itemType) {

               return true;
      

    }


    public bool TryUnlockItem(ItemType itemType) {
        if (CanUnlock(itemType)) {
            UnlockItem(itemType);

            return true;

        }
        else {
            return false;
        }


    }

    public void ClearUnlocks() {
        unlockedItemTypeList.Clear();

    }
}
