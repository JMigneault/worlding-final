using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSequence : MonoBehaviour
{

    private GameObject[] elements = new GameObject[30];
    private int[] elementNums = new int[8];
    public float timeDelay = 10.0f;
    public float darkFlashDelay = .5f;
    public float lightFlashDelay = .5f;
    public int numFlashes = 1;

    private float currTime = 0.0f;
    private int nextEltIndex = 0;
    private int nextEltSizeIndex = 0;

    public GameObject tables;
    public GameObject ivy;
    public GameObject lights;

    public GameObject natureSounds;

    public AudioSource electricity;

    void Start() {
        FillArrays();
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > timeDelay && nextEltIndex < elements.Length) {
            currTime = 0;
            StartCoroutine(DoNextStep());
        }
    }

    IEnumerator DoNextStep() {
        electricity.Play();
        Debug.Log("Starting step: " + nextEltSizeIndex);
        for (int i = 0; i < elementNums[nextEltSizeIndex]; i++) {
            Debug.Log("Enabling object index: " + nextEltIndex);
            elements[nextEltIndex].SetActive(true);
            nextEltIndex++;
        }
        nextEltSizeIndex++;
        if (nextEltSizeIndex == 4) {
            natureSounds.SetActive(true);
        }
        for (int i = 0; i < numFlashes; i++) {
            Color oldColor = RenderSettings.ambientLight;
            RenderSettings.ambientLight = Color.black;
            lights.SetActive(false);
            yield return new WaitForSeconds(darkFlashDelay);
            RenderSettings.ambientLight = oldColor;
            lights.SetActive(true);
            if (i != numFlashes - 1) {
                yield return new WaitForSeconds(lightFlashDelay);
            }
        }
    }

    void FillArrays() {
        int eltIndex = 0;
        int stepIndex = 0;
        for (int i = 0; i < 4; i++) {
            Transform table = tables.transform.GetChild(i);
            Transform nextTable = i < 3 ? tables.transform.GetChild(i + 1) : null;
            Transform wall = ivy.transform.GetChild(i);
            eltIndex = StepOne(eltIndex, stepIndex, table);
            stepIndex++;
            eltIndex = StepTwo(eltIndex, stepIndex, table, nextTable, wall);
            stepIndex++;
        }
        foreach (var x in elements) {
            Debug.Log(x);

        }
    }

    int StepOne(int startingIndex, int stepIndex, Transform table) {
        // left monitor covered
        elements[startingIndex] = table.GetChild(1).GetChild(1).GetChild(1).GetChild(1).gameObject;
        // right monitor video on
        elements[startingIndex+1] = table.GetChild(1).GetChild(0).GetChild(0).GetChild(3).gameObject;
        // right monitor partially covered
        elements[startingIndex+2] = table.GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject;
        // table
        elements[startingIndex+3] = table.GetChild(0).GetChild(1).gameObject;
        elementNums[stepIndex] = 4;
        return startingIndex + 4;
    }

    int  StepTwo(int startingIndex, int stepIndex, Transform table, Transform nextTable, Transform wall) {
        // wall
        elements[startingIndex] = wall.gameObject;
        // right monitor covered
        elements[startingIndex+1] = table.GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject;
        if (nextTable != null) {
            // next table monitor partiall covered
            elements[startingIndex+2] = nextTable.GetChild(1).GetChild(1).GetChild(1).GetChild(0).gameObject;
            // next table monitor video on
            elements[startingIndex+3] = nextTable.GetChild(1).GetChild(1).GetChild(0).GetChild(3).gameObject;
            elementNums[stepIndex] = 4;
            return startingIndex + 4;            
        }
        elementNums[stepIndex] = 2;
        return startingIndex + 2;
    }



}
