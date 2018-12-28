# Unity Generic Pooling Singleton

A small generic pooling singleton to help you make pools for your prefabs

# How to setup
 - Make a prefab
 - Make an empty class that inherits from the UnityPool<T> with T being your prefab controller script , for example :
  ```     
public class RockPool : UnityPool<RockController> { }
  ```
 - Drag your prefab in the "Prefab" field
 - That's about it
  
# How to use
 - To get a pooled instance use 
  ```
  GameObject PooledRock = RockPool.getInstance().Get() //this will give a Rock instance
  ````

 - To return a pooled instance to the pool 
  ```
RockPool.getInstance().Return(PooledRock); //returns the object back to the pool
  ````
  
- If you already know how many instances you're going to use (or approximatly) , Check the "Prewarm variable" and set the amount
