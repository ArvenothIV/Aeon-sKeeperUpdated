using UnityEngine;
using System.Collections;

public class FadeInAndOut : MonoBehaviour {

	public SpriteRenderer sprite;
	public float spriteAlpha, fadeSpeed;
	public bool fade, fadingIn, fadingOut, bothFades;
	
	void Start(){
		sprite.color = new Color(0f, 0f, 0f, 0f);
	}
	void Update(){
		if(fade){
			if (fadingOut) { //1f is black
				spriteAlpha -= fadeSpeed * Time.deltaTime;
				if(spriteAlpha <= 0){
					fadingOut = false;
				}
				sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b,spriteAlpha);
			}
			if(fadingIn) {
				spriteAlpha += fadeSpeed * Time.deltaTime;			
				if(spriteAlpha >= 1){
					fadingIn = false;
				}
				sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b,spriteAlpha);
			}
			if (!fadingOut && !fadingIn && !bothFades){
				sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
				fade = false;
			}
		}
	}
}
