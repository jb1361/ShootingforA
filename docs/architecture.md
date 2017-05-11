We are writing a game and because of that we cannot accurately gauge the number of all the different components/objects 
in the game will interact/behave. This document will be updated as we continue progress.

We do have an very good idea of where and how we want to approach the game.

We will have:
  * A core module that handles all input and inherits all modules that need to recieve data from the input module
  * Our player will have a single module that has all the required methods that will recieve data and update data on our player. 
  These include methods such as updatePosition(), takeDamage(), getPowerUp(), ect
  *Each enemy will have one module that controlls all its AI and store values such as speed, health, damage, score, drops, ect
  *The StageController will handle each level and update enemys values to increase difficulty the further you progress
  *There will be various small modules that will handle performance and bug issues as the project progresses
