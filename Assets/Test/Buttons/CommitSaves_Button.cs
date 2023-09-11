using UnityEngine;
using VG;


public class CommitSaves_Button : ButtonClick
{

    protected override void OnClick()
    {
        Saves.Commit((success) =>
        {
            if (success) button.image.color = Color.green;
            else button.image.color = Color.red;
        });
    }
}
