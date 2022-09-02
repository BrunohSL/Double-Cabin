using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public double totalGoldValue;
    public int totalGoldScale;
    public double totalWisdomValue;
    public int totalWisdomScale;

    public string lastTimeOnline;
    public string wishingWellLastCollectedTime;

    public double multiplier;

    public int[] buildingLevel = new int[8];

    public double[] buildingInitialProduction = new double[8];
    public double[] buildingInitialCost = new double[8];
    public double[] buildingGrowthRate = new double[8];

    public double[] buildingActualProductionValue = new double[8];
    public int[] buildingActualProductionScale = new int[8];

    public double[] buildingNextProductionValue = new double[8];
    public int[] buildingNextProductionScale = new int[8];

    public double[] buildingNextCostValue = new double[8];
    public int[] buildingNextCostScale = new int[8];

    public int[] buildingTierlistRank = new int[8];
    public double[] buildingMultiplier = new double[8];

    public float[] buildingOriginalColor_r = new float[8];
    public float[] buildingOriginalColor_g = new float[8];
    public float[] buildingOriginalColor_b = new float[8];
    public float[] buildingOriginalColor_a = new float[8];

    public float[] buildingActualColor_r = new float[8];
    public float[] buildingActualColor_g = new float[8];
    public float[] buildingActualColor_b = new float[8];
    public float[] buildingActualColor_a = new float[8];

    public PlayerData() {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        List<BuildingScriptableObject> goldGeneratorBuildingsScriptableObject = gameController.GetComponent<GoldBuildingsController>().getGoldGeneratorBuildings();

        CurrencyController currencyController = gameController.GetComponent<CurrencyController>();
        ModifierController modifierController = gameController.GetComponent<ModifierController>();
        WishingWellController wishingWellController = gameController.GetComponent<WishingWellController>();

        totalGoldValue = currencyController.getGold().value;
        totalGoldScale = currencyController.getGold().scale;
        totalWisdomValue = currencyController.getWisdom().value;
        totalWisdomScale = currencyController.getWisdom().scale;

        lastTimeOnline = System.DateTime.Now.ToString();
        wishingWellLastCollectedTime = wishingWellController.getLastCollectedTime();

        multiplier = modifierController.getGlobalMultiplier();

        int counter = 0;

        foreach (BuildingScriptableObject building in goldGeneratorBuildingsScriptableObject) {
            buildingLevel[counter] = building.level;

            buildingInitialProduction[counter] = building.initialProduction;
            buildingInitialCost[counter] = building.initialCost;
            buildingGrowthRate[counter] = building.growthRate;

            buildingActualProductionValue[counter] = building.actualProduction.value;
            buildingActualProductionScale[counter] = building.actualProduction.scale;

            buildingNextProductionValue[counter] = building.nextProduction.value;
            buildingNextProductionScale[counter] = building.nextProduction.scale;

            buildingNextCostValue[counter] = building.nextCost.value;
            buildingNextCostScale[counter] = building.nextCost.scale;

            buildingTierlistRank[counter] = building.tierlistRank;
            buildingMultiplier[counter] = building.buildingMultiplier;

            buildingOriginalColor_r[counter] = building.originalColor.r;
            buildingOriginalColor_g[counter] = building.originalColor.g;
            buildingOriginalColor_b[counter] = building.originalColor.b;
            buildingOriginalColor_a[counter] = building.originalColor.a;

            buildingActualColor_r[counter] = building.actualColor.r;
            buildingActualColor_g[counter] = building.actualColor.g;
            buildingActualColor_b[counter] = building.actualColor.b;
            buildingActualColor_a[counter] = building.actualColor.a;
            counter++;
        }
    }
}
