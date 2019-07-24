/*Given code animates sprites from given spritesheet.
In this example name of file sheet is walk.png and contains 4 walking sprites.*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spritescript : MonoBehaviour
{
    private Sprite mySprite;//creating a new sprite
    private List<Sprite> hab = new List<Sprite>();//creating a list of sprites
    int texture_width;//variable to store width of given texture
    int texture_height;//variable to store height of given texture
    int numer_of_animations=4;//number of animations
    float animation_timer = 1f;//timer for animation
    float animation_delay = 1f;//timer for delay
    int index = 0;//array index
    int starting_pos = 0;//starting position of sprite in texture
    Sprite sprite;//Creating an Sprite
    [SerializeField]
    private UnityEngine.UI.Image image = null;//giving reference to the UI.image in the inspector 
    void Start()
    {
        Texture2D tex;//declaring tex as a texture2d type
        tex = (Texture2D)Resources.Load("walk", typeof(Texture2D));//giving the walking texture to tex.."walk" is the file name and its loaded from the resource folder.
        texture_width = tex.width;//assigning value to  texture_width
        texture_height = tex.height;//assigning value to texture_height
        int n = numer_of_animations;
      while (n > 0)
      {

          mySprite = Sprite.Create(tex, new Rect(starting_pos, 0, texture_width / numer_of_animations, texture_height), new Vector2(0f, 0f), 100.0f);//cropping the sprite
          starting_pos = starting_pos + (texture_width / numer_of_animations);//changing the starting position
          n = n - 1;
          hab.Add(mySprite);//adding the sprite to the list
      }
        
    }
    void Update()
    {
        animation_timer -= Time.deltaTime;//for creating delay
        if (animation_timer <= 0)
        {
            if (index == numer_of_animations)//go to the first sprite,if all the sprites are covered
            {
                index = 0;
            }
            image.sprite = hab[index];//assigning texture to the sprite
            index = index + 1;
            animation_timer = animation_delay;//for creating delay
            return;
        }
        
    }
}
