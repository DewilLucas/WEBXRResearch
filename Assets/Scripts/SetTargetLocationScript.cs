using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTargetLocationScript : MonoBehaviour
{
    public TMP_Dropdown locationDropdown;  // Reference to your UI dropdown
    public GameObject targetObject;    // The object you want to move


    // Called when the dropdown selection changes
    public void OnLocationSelected()
    {
        // Get the selected index from the dropdown
        int selectedIndex = locationDropdown.value;

        // Get the corresponding text of the selected option
        string selectedLocationName = locationDropdown.options[selectedIndex].text;

        // Find the GameObject with the selected name in the scene
        GameObject selectedLocation = GameObject.Find(selectedLocationName);

        // Check if the GameObject is found before attempting to move
        if (selectedLocation != null)
        {
            // Move the target object to the selected location
            MoveToObject(selectedLocation.transform.position);
        }
        else
        {
            Debug.LogError("Selected location not found in the scene.");
        }
    }

    // Move the target object to the specified position
    private void MoveToObject(Vector3 targetPosition)
    {
        // Assuming you want to move the entire object, you can set its position
        targetObject.transform.position = targetPosition;
    }
}
