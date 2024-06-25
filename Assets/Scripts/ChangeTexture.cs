using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
   public List<Texture> allTextures;
   
   public void ChangeTextureInObject(GameObject changeTextureObject, string textureName)    // Передаємо обєкт на якому будемо заміняти текстуру і саму назву текстури
   {
      Texture currentTexture = allTextures.Find(x => x.name == textureName);  // Для простого тесту текстуру будемо брати з ліста по імені.
      Renderer renderer = changeTextureObject.GetComponent<Renderer>();
      
      if (currentTexture && renderer)    // Якщо все працює, текстура заміниться. 
      {
         renderer.material.color = Color.white;
         renderer.material.mainTexture = currentTexture;
      }
      else                                      // Якщо не працює, обєкт на якому хотіли міняти текстуру стане червоний.
      {
         renderer.material.color = Color.red;
      }
   }
   
}
