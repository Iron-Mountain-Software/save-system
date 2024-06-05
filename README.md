# Save System
*Version: 1.0.5*
## Description: 
A library for reading and writing files and data-types.SOME CODING REQUIRED
## Package Mirrors: 
[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODkyLnBuZw==/original/Fq0ORM.png'>](https://www.npmjs.com/package/com.iron-mountain.save-system)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODg3LnBuZw==/original/npRUfq.png'>](https://github.com/Iron-Mountain-Software/save-system)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODk4LnBuZw==/original/Rv4m96.png'>](https://iron-mountain.itch.io/save-system)
---
## Key Scripts & Components: 
1. public enum **FileType** : Enum
1. public static class **FileTypeUtilities**
1. public static class **SaveSystem**
1. public struct **SavedBool**
   * Properties: 
      * public Boolean ***Value***  { get; set; }
      * public Boolean ***Saved***  { get; }
   * Methods: 
      * public SavedBool ***Load***()
      * public SavedBool ***Save***()
      * public void ***Delete***()
1. public struct **SavedFloat**
   * Actions: 
      * public event Action ***OnValueChanged*** 
   * Properties: 
      * public float ***Value***  { get; set; }
      * public Boolean ***Saved***  { get; }
   * Methods: 
      * public SavedFloat ***Load***()
      * public SavedFloat ***Save***()
      * public void ***Delete***()
1. public struct **SavedInt**
   * Actions: 
      * public event Action ***OnValueChanged*** 
   * Properties: 
      * public Int32 ***Value***  { get; set; }
      * public Boolean ***Saved***  { get; }
   * Methods: 
      * public SavedInt ***Load***()
      * public SavedInt ***Save***()
      * public void ***Delete***()
1. public struct **SavedList**
   * Properties: 
      * public List<String> ***Data***  { get; set; }
      * public Boolean ***Saved***  { get; }
   * Methods: 
      * public void ***Add***(String s)
      * public void ***AddRange***(List`1 s)
      * public void ***Remove***(String s)
      * public SavedList ***Load***()
      * public SavedList ***Save***()
      * public void ***Delete***()
1. public struct **SavedString**
   * Actions: 
      * public event Action ***OnValueChanged*** 
   * Properties: 
      * public String ***Value***  { get; set; }
      * public Boolean ***Saved***  { get; }
   * Methods: 
      * public SavedString ***Load***()
      * public SavedString ***Save***()
      * public void ***Delete***()
1. public struct **SavedTexture2D**
   * Actions: 
      * public event Action ***OnTexture2DChanged*** 
   * Properties: 
      * public String ***Directory***  { get; set; }
      * public String ***File***  { get; set; }
      * public Texture2D ***Texture2D***  { get; set; }
      * public Boolean ***Saved***  { get; }
   * Methods: 
      * public SavedTexture2D ***Load***()
      * public SavedTexture2D ***Save***()
      * public void ***Delete***()
      * public Sprite ***CreateSprite***(String name)
1. public class **ScriptedSavedBool** : ScriptedSavedValue`1
   * Properties: 
      * public Boolean ***Value***  { get; set; }
      * public Boolean ***DefaultValue***  { get; set; }
   * Methods: 
      * public void ***Toggle***()
1. public class **ScriptedSavedFloat** : ScriptedSavedValue`1
   * Properties: 
      * public float ***Value***  { get; set; }
      * public float ***DefaultValue***  { get; set; }
   * Methods: 
      * public void ***Increment***()
      * public void ***Decrement***()
      * public void ***Add***(float value)
      * public void ***Subtract***(float value)
      * public void ***MultiplyBy***(float value)
      * public void ***DivideBy***(float value)
1. public class **ScriptedSavedInt** : ScriptedSavedValue`1
   * Properties: 
      * public Int32 ***Value***  { get; set; }
      * public Int32 ***DefaultValue***  { get; set; }
   * Methods: 
      * public void ***Increment***()
      * public void ***Decrement***()
      * public void ***Add***(Int32 value)
      * public void ***Subtract***(Int32 value)
      * public void ***MultiplyBy***(Int32 value)
      * public void ***DivideBy***(Int32 value)
1. public class **ScriptedSavedList** : ScriptedSavedValue`1
   * Properties: 
      * public List<String> ***Value***  { get; set; }
      * public List<String> ***DefaultValue***  { get; set; }
   * Methods: 
      * public void ***Add***(String value)
      * public void ***AddRange***(List`1 values)
      * public void ***Remove***(String value)
      * public void ***Clear***()
      * public Boolean ***Contains***(String value)
      * public override void ***ResetValue***()
1. public class **ScriptedSavedString** : ScriptedSavedValue`1
   * Properties: 
      * public String ***Value***  { get; set; }
      * public String ***DefaultValue***  { get; set; }
1. public abstract class **ScriptedSavedValue`1** : ScriptableObject
   * Actions: 
      * public event Action ***OnValueChanged*** 
   * Properties: 
      * public String ***Directory***  { get; }
      * public String ***File***  { get; }
      * public T ***Value***  { get; set; }
      * public T ***DefaultValue***  { get; set; }
   * Methods: 
      * public virtual void ***ResetValue***()
