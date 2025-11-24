using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSlotUI : MonoBehaviour
{
    public int slotIndex;               // Set in Inspector (1 to 8)
    public TextMeshProUGUI slotText;    // Reference to text inside button
    public Button slotButton;           // The slot button

    private bool isOccupied = false;    // Checks if slot already has saved data

    void Start()
    {
        slotButton.onClick.AddListener(OnSlotClicked);

        if (SaveSystem.SaveExists(slotIndex))
            isOccupied = true;

        RefreshUI();
    }

    public void RefreshUI()
    {
        if (isOccupied)
            slotText.text = "SLOT " + slotIndex + " : CONTINUE";
        else
            slotText.text = "SLOT " + slotIndex + " : EMPTY";
    }

    public void MarkAsOccupied()
    {
        isOccupied = true;
        RefreshUI();
    }

    private void OnSlotClicked()
    {
        SaveSlotsManager.Instance.SelectSlot(this);
    }
}
