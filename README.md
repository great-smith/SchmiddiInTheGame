# Schmiddi In The Game

My first 2D Pixel-Art RPG Game made with Unity on Mac.

In the Unity-Project, I use the PerfectPixel Camera-Script by GG EZ (from the Asset Store, It's free!)

# Requirements
* Graphics: [Rural Farm Tiles](https://pixanna.nl/products/rural-farm-tiles/)
* Game Engine: Unity

# How to use the Rural Farm Tiles

Attention! Add your Rural Farm Tiles Sprites into Assets > SchmiddiInTheGame > Images > Rural Farm Tiles!

**After that, you need to slice the Sprites**

In Unity select Image (for Example TileA1), then set Sprite-Mode in Inspector to *multiple* and set 16 pixels per unit for (TileA1-A5_2_16x16), 32 pixels per unit for the others. Set also Filter Mode to *No Point (no filter)* and Compression to *none*.

I use TileA1, TileA2, TileA3, TileA4, TileA5_2. **You need to rename TileA5_2** in **TileA5_2_16x16**. After that, you can slice TileA1-TileA5_2_16x16 in Sprite Editor to 16x16 px), TileB_exterior_2_summer, TileE (slice both to 32x32 px in Sprite Editor).
