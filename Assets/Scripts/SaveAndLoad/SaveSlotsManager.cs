using UnityEngine;

public class SaveSlotsManager : MonoBehaviour
{
    public static SaveSlotsManager Instance;

    public SaveSlotUI[] allSlots;   // Assign in Inspector

    private SaveSlotUI selectedSlot;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectSlot(SaveSlotUI slot)
    {
        selectedSlot = slot;

        if (slot.gameObject.GetComponent<SaveSlotUI>().enabled)
        {
            Debug.Log("Slot " + slot.slotIndex + " clicked!");

            GameManager.Instance.Save(slot.slotIndex);
            slot.MarkAsOccupied();
        }
    }

    public void MarkSlotAsUsed(int index)
    {
        allSlots[index].MarkAsOccupied();
    }
}
