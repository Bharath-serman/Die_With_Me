using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform player;
    public int dialogueIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void Save(int slot)
    {
        SaveData data = new SaveData();

        data.SceneIndex = SceneManager.GetActiveScene().buildIndex;
        data.DialogueIndex = dialogueIndex;

        data.posx = player.position.x;
        data.posy = player.position.y;
        data.posz = player.position.z;

        data.rotx = player.rotation.x;
        data.roty = player.rotation.y;
        data.rotz = player.rotation.z;
        data.rotw = player.rotation.w;

        SaveSystem.SaveGame(data, slot);
    }

    public void Load(int slot)
    {
        SaveData data = SaveSystem.LoadGame(slot);
        if (data == null) return;

        SceneManager.LoadScene(data.SceneIndex);
        StartCoroutine(SetPlayerPosition(data));
    }

    private System.Collections.IEnumerator SetPlayerPosition(SaveData data)
    {
        yield return new WaitForSeconds(0.2f);

        player = GameObject.FindWithTag("Player").transform;

        Vector3 pos = new Vector3(data.posx, data.posy, data.posz);
        Quaternion rot = new Quaternion(data.rotx, data.roty, data.rotz, data.rotw);

        player.position = pos;
        player.rotation = rot;

        dialogueIndex = data.DialogueIndex;
    }
}
