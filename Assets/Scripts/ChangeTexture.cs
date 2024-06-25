using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
   public List<Texture> allTextures;
   public GameObject ChangeTextureObject { get; set; }
   
   // Я не знаю чи можна передавати GameObject з javascript сюди в метод. Тому якщо не можна то просто визивайте метод ChnageTextureWithOutObject() 
 
   public void ChangeTextureInObject(string textureName, GameObject changeTextureObject)    // Передаємо обєкт на якому будемо заміняти текстуру і саму назву текстури
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

   public void ChnageTextureWithOutObject(string textureName)
   {
      Texture currentTexture = allTextures.Find(x => x.name == textureName);  
      Renderer renderer = ChangeTextureObject.GetComponent<Renderer>();
      
      if (currentTexture && renderer)   
      {
         renderer.material.color = Color.white;
         renderer.material.mainTexture = currentTexture;
      }
      else                                    
      {
         renderer.material.color = Color.red;
      }
   }

}
