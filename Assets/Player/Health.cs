using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player {
    public class Health : MonoBehaviour {
		public int health;
		public Sprite redSprite;
		public Sprite greenSprite;
		public Sprite blueSprite;
		public Sprite yellowSprite;

		public void damagePlayer(){
			health--;
			if (health == 0) {//die
			    KeepingItems.Instance.FinalScore = Attack.Instance.getPlayerScore();
				SceneManager.LoadScene ("Game Over");
			} else if (health <= 5) {
				Attack player = gameObject.GetComponent<Attack> ();
				player.RedWeaponType.sprite = redSprite;
				player.BlueWeaponType.sprite = blueSprite;
				player.GreenWeaponType.sprite = greenSprite;
				player.YellowWeaponType.sprite = yellowSprite;
				player.SelectedWeaponType = player.SelectedWeaponType;
			}
		}
    }
}
