scripts
    player
    enemy
    
    inventory
    weapons

    
    scene management
    misc    
        env script
            pickup

------------------------------------
- game starts with user tappping on game icon.
- game shows the ui menu.
- player can either change settings, but mainly load a game scene.
- user uses (input system api + character controller api) -> to control the player with input btns.
- player character interacts with the game env in the scene. and finishes the scene and comes back to ui menu.
- loops again.

-------------------------------------
we have 3 layers in unity game egnine
1. unity engine: the layer we can't change.
2. unity editor: - the layer that we can change with unity editor `settings/configurator menu` options.
                 - it it built over `unity_engine`'s apis. a layer of abstraction.
3. customization layer: this is the layer that we build with custom scripts and custom objects. 
                        to control different knobs and livers of the unity_editor
                        by caling unity_editor apis.
                        by utilizing the unity editor apis in the scripts like update, fixedupdate etc.
                        [-] in this layer i need to learn diff imp apis like update(), fixedUpdate() that we use very frequently in the unity scripts.

-----------------------------------------------
project deatils:
- in this project for `input_system` we are using a prebuilt package to easily create and manage mapping b/w btns and their effect in the game.
- importing 2d sprits
- adding animation layer to the game.   
    - importing animation_strips and splitting into frames.
    - setting up animator_controller, animation states and their connections.
    - writing script to trigger animation based on input (like jump) or event (like death).


--------------------------------------------------
- having control over with physics
- having control with ui in main_menu or in game_scene
- having control over visuals like sprites and animations
- knowing about scenes loading, changinig etc.
- knowing input system and how to use it with scripts.
- there are some higher level abstraction pkgs that i need to learn to use:
    - like tile palette - https://www.youtube.com/watch?v=G7e_fzG_0Bk
    - input system mappper - 



--------------------------------------------------
the strategy that i can follow to learn these one by one is:
- first JUST watch a bunch of videos, solely on these tools/pkgs indivisually from udemint or youtube,
    and try using recalling every feature of that tool next morning w/o help of the course.

----------------------------------------------
- goal: - to be able to build this one game w/o watching the course.
        - do same with a bunch of game courses.
        - then try recreating a playstore game on my own with any help.

`to be able to build this one game w/o watching the course.`: this is my loss_fun for now, and this loss func i 
have to use to train my brain over that udemint unity rpg game course.
---------------------------------------------
what is awake, start, update and fixedupdate?



-----------------------------------------------

keep the startegy of learning very simple, starting with just watching and memorizing scripts only then the videos only.