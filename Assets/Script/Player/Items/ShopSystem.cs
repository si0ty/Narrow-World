using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;
using UnityEngine.EventSystems;

public class ShopSystem : MonoBehaviour
{

	private PlayerResourceManager resourceManager;
	private PlayerItems playerItems;
	public Player player;

	public List<GameObject> tier1Items;
	public List<GameObject> tier2Items;
	public List<GameObject> tier3Items;

	[SerializeField] private Material itemLockedMaterial;
	[SerializeField] private Material itemUnlockableMaterial;

	public List<GameObject> armorSlots;

	public List<Item> itemList;

	private List<Item> unlockedItems;

	private ResourceDisplay resourceDisplay;



    private void Start() {
		player = GameObject.Find("Player").GetComponent<Player>();

		resourceManager = player.GetComponent<PlayerResourceManager>();
		resourceDisplay = GameObject.Find("IngameResourceDisplay").GetComponent<ResourceDisplay>();
		

	}


	public void SetPlayerItems(PlayerItems playerItems) {

		this.playerItems = playerItems;
		itemList = new List<Item>();


	
		itemList.Add(new Item(armorSlots[0].transform, player, playerItems, PlayerItems.ItemType.LightHelmet, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[1].transform, player, playerItems, PlayerItems.ItemType.ShootingCape, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[2].transform, player, playerItems, PlayerItems.ItemType.IronHelmet, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[3].transform, player, playerItems, PlayerItems.ItemType.LeatherHarness, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[4].transform, player, playerItems, PlayerItems.ItemType.LightGambeson, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[5].transform, player, playerItems, PlayerItems.ItemType.ChainHarness, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[6].transform, player, playerItems, PlayerItems.ItemType.LeatherBoots, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[7].transform, player, playerItems, PlayerItems.ItemType.Furboots, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[8].transform, player, playerItems, PlayerItems.ItemType.ChainBoots, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[9].transform, player, playerItems, PlayerItems.ItemType.CopperHelmet, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[10].transform, player, playerItems, PlayerItems.ItemType.ThickShootingCape, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[11].transform, player, playerItems, PlayerItems.ItemType.HeavySteelHelmet, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[12].transform, player, playerItems, PlayerItems.ItemType.BoltedHarness, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[13].transform, player, playerItems, PlayerItems.ItemType.LeatherGambeson, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[14].transform, player, playerItems, PlayerItems.ItemType.SteelHarness, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[15].transform, player, playerItems, PlayerItems.ItemType.HardenedLeatherboots, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[16].transform, player, playerItems, PlayerItems.ItemType.LightLeatherBoots, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[17].transform, player, playerItems, PlayerItems.ItemType.PlatedBoots, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[18].transform, player, playerItems, PlayerItems.ItemType.HolyforgedHelmet, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[19].transform, player, playerItems, PlayerItems.ItemType.CobaltCape, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[20].transform, player, playerItems, PlayerItems.ItemType.SunstoneHelmet, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[21].transform, player, playerItems, PlayerItems.ItemType.HolyforgedHarness, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[22].transform, player, playerItems, PlayerItems.ItemType.CobaltHarness, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[23].transform, player, playerItems, PlayerItems.ItemType.SunstoneHarness, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[24].transform, player, playerItems, PlayerItems.ItemType.SunstoneBoots, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[25].transform, player, playerItems, PlayerItems.ItemType.ForestBoots, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[26].transform, player, playerItems, PlayerItems.ItemType.HolyforgedBoots, itemList, itemUnlockableMaterial, itemLockedMaterial));
		
		
		
		
	    itemList.Add(new Item(armorSlots[27].transform, player, playerItems, PlayerItems.ItemType.FullmetalDagger, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[28].transform, player, playerItems, PlayerItems.ItemType.HardenedLongsword, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[29].transform, player, playerItems, PlayerItems.ItemType.LightShield, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[30].transform, player, playerItems, PlayerItems.ItemType.WalnutBow, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[31].transform, player, playerItems, PlayerItems.ItemType.Waterdagger, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[32].transform, player, playerItems, PlayerItems.ItemType.SwordOfRoyalguard, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[33].transform, player, playerItems, PlayerItems.ItemType.HolyforgedShield, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[34].transform, player, playerItems, PlayerItems.ItemType.HolyForgedBow, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[35].transform, player, playerItems, PlayerItems.ItemType.LightsteelDagger, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[36].transform, player, playerItems, PlayerItems.ItemType.MoltenSword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[37].transform, player, playerItems, PlayerItems.ItemType.LightsteelShield, itemList, itemUnlockableMaterial, itemLockedMaterial));


		itemList.Add(new Item(armorSlots[38].transform, player, playerItems, PlayerItems.ItemType.RecurveBow, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[39].transform, player, playerItems, PlayerItems.ItemType.ForestDagger, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[40].transform, player, playerItems, PlayerItems.ItemType.WaterLongsword, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[41].transform, player, playerItems, PlayerItems.ItemType.WaterShortsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[42].transform, player, playerItems, PlayerItems.ItemType.Windbow, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[43].transform, player, playerItems, PlayerItems.ItemType.Crystalstaff, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[44].transform, player, playerItems, PlayerItems.ItemType.MoltenDagger, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[45].transform, player, playerItems, PlayerItems.ItemType.WindLongsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[46].transform, player, playerItems, PlayerItems.ItemType.MoltenShortsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[47].transform, player, playerItems, PlayerItems.ItemType.ForestBow, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[48].transform, player, playerItems, PlayerItems.ItemType.DarkmatterStaff, itemList, itemUnlockableMaterial, itemLockedMaterial));
		
		itemList.Add(new Item(armorSlots[49].transform, player, playerItems, PlayerItems.ItemType.AncientShortsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[50].transform, player, playerItems, PlayerItems.ItemType.DarkmatterLongsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[51].transform, player, playerItems, PlayerItems.ItemType.ForestShortsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[52].transform, player, playerItems, PlayerItems.ItemType.Icebow, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[53].transform, player, playerItems, PlayerItems.ItemType.ForestStaff, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[54].transform, player, playerItems, PlayerItems.ItemType.BoltShortsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[55].transform, player, playerItems, PlayerItems.ItemType.AncientSword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[56].transform, player, playerItems, PlayerItems.ItemType.AncientShield, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[57].transform, player, playerItems, PlayerItems.ItemType.Corebow, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[58].transform, player, playerItems, PlayerItems.ItemType.Boltstaff, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[59].transform, player, playerItems, PlayerItems.ItemType.DarkMatterShortsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
	
		itemList.Add(new Item(armorSlots[60].transform, player, playerItems, PlayerItems.ItemType.BoltSword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[61].transform, player, playerItems, PlayerItems.ItemType.Oreshield, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[62].transform, player, playerItems, PlayerItems.ItemType.DarkMatterBow, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[63].transform, player, playerItems, PlayerItems.ItemType.CoreStaff, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[64].transform, player, playerItems, PlayerItems.ItemType.DemonicShortsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[65].transform, player, playerItems, PlayerItems.ItemType.DemonicLongsword, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[66].transform, player, playerItems, PlayerItems.ItemType.DemonicShield, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[67].transform, player, playerItems, PlayerItems.ItemType.DemonicBow, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[68].transform, player, playerItems, PlayerItems.ItemType.DemonicStaff, itemList, itemUnlockableMaterial, itemLockedMaterial));

		
		//Jewellery
		
		itemList.Add(new Item(armorSlots[69].transform, player, playerItems, PlayerItems.ItemType.HolyforgedRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[70].transform, player, playerItems, PlayerItems.ItemType.CrystalRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[71].transform, player, playerItems, PlayerItems.ItemType.SunstoneRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[72].transform, player, playerItems, PlayerItems.ItemType.WaterRing, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[73].transform, player, playerItems, PlayerItems.ItemType.AncientRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[74].transform, player, playerItems, PlayerItems.ItemType.VelonstoneRing, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[75].transform, player, playerItems, PlayerItems.ItemType.ForestRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[76].transform, player, playerItems, PlayerItems.ItemType.Windring, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[77].transform, player, playerItems, PlayerItems.ItemType.NotARing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[78].transform, player, playerItems, PlayerItems.ItemType.MoltenRing, itemList, itemUnlockableMaterial, itemLockedMaterial));

		itemList.Add(new Item(armorSlots[79].transform, player, playerItems, PlayerItems.ItemType.GreenstoneRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[80].transform, player, playerItems, PlayerItems.ItemType.DarkMatterRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[81].transform, player, playerItems, PlayerItems.ItemType.BoltRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[82].transform, player, playerItems, PlayerItems.ItemType.IceRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		itemList.Add(new Item(armorSlots[83].transform, player, playerItems, PlayerItems.ItemType.RedOreRing, itemList, itemUnlockableMaterial, itemLockedMaterial));
		


		UpdateVisuals();

		SetItemTooltip();

	}

	private void SetItemTooltip() {
        for (int i = 0; i < itemList.Count; i++) {
			ItemSlot itemSlot = armorSlots[i].gameObject.transform.GetComponent<ItemSlot>();
			Image image = armorSlots[i].transform.GetChild(1).GetComponent<Image>();

			Tooltip_ItemStats.AddTooltip(armorSlots[i].transform, image, itemSlot.itemName, itemSlot.description, itemSlot.classContent, itemSlot.typeContent, itemSlot.effect);

		}
    }

	public void UpdateVisuals() {
		foreach (Item item in itemList) {
			item.UpdateVisuals();
		}

	}


	public class Item {

		private string itemName;

		private int goldCost;
	/*	private int levelRequirement;

		private int tierType;

		private int effectPercent; */

		private Transform transform;
		private Image image;
		private Image frame;
		private PlayerItems playerItems;
		private PlayerItems.ItemType itemType;
		private Material itemLockedMaterial;
		private Material itemUnlockableMaterial;
		private Player player;


		private List<Item> itemList;




		private void Awake() {
			itemList = transform.GetComponent<ShopSystem>().itemList;
			goldCost = transform.GetComponent<ItemSlot>().goldCost;

			

		}


		private void Start() {
		
		}


		public Item(Transform transform, Player player, PlayerItems playerItems, PlayerItems.ItemType itemType, List<Item> itemList, Material itemUnlockableMaterial, Material itemLockedMaterial) {


			this.transform = transform;
			this.playerItems = playerItems;
			this.itemType = itemType;
			this.itemLockedMaterial = itemLockedMaterial;
			this.itemUnlockableMaterial = itemUnlockableMaterial;
			this.itemList = itemList;


			this.player = player;

		



			transform.GetComponent<Button>().onClick.AddListener(() => {
				

				if (!playerItems.IsItemUnlocked(itemType)) {
					

					if (transform.GetComponent<ItemSlot>().goldCost <= Player.ingameResources[ResourceType.Money]) {

						if (playerItems.TryUnlockItem(itemType))

						
							Debug.Log("Item unlocked" + itemType.ToString());
                        if (transform.GetComponent<EffectCenter>().t1) {
							transform.GetComponent<EffectCenter>().UpgradeLevel1(transform.GetComponent<ItemSlot>().level1Percentage);

						}
						if(transform.GetComponent<EffectCenter>().t2) {
							transform.GetComponent<EffectCenter>().UpgradeLevel2(transform.GetComponent<ItemSlot>().level2Percentage);

						}

						if (transform.GetComponent<EffectCenter>().t3) {
							transform.GetComponent<EffectCenter>().UpgradeLevel3(transform.GetComponent<ItemSlot>().level3Percentage);

						}
										
					

							Player.SpendResource(ResourceType.Money, transform.GetComponent<ItemSlot>().goldCost, GameObject.Find("IngameResourceDisplay").GetComponent<ResourceDisplay>());
						Debug.Log(Player.ingameResources[ResourceType.Money]);

						GameObject.Find("IngameResourceDisplay").transform.GetComponent<ResourceDisplay>().UpdateDisplay(transform.GetComponent<ItemSlot>().goldCost, ResourceType.Money, true);
						    
						UpdateVisuals();



					}
					else {
						Debug.Log("Insufficent Resources");
					}
				}
				else {
					Debug.Log("Item already unlocked");
				}
			});



		}



			public void UpdateVisuals() {
				if (playerItems.IsItemUnlocked(itemType)) {

					transform.GetComponent<ItemSlot>().ItemActivated();
					transform.GetChild(1).GetComponent<Image>().material = null;
				Debug.Log("Activated");


				}

				else {
					if (playerItems.CanUnlock(itemType)) {

						transform.GetChild(0).GetComponent<Image>().material = itemUnlockableMaterial;
						transform.GetChild(1).GetComponent<Image>().material = itemUnlockableMaterial;

					

				}
					else {
						transform.GetChild(0).GetComponent<Image>().material = itemLockedMaterial;
						transform.GetChild(1).GetComponent<Image>().material = itemLockedMaterial;

					}
				}
			}

		}


	}


