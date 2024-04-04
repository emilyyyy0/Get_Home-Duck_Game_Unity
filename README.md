# Project 2 Report

Read our GDD [here](GDD.md).

## Table of Contents

* [Evaluation Plan and Report](#evaluation-plan-and-report)
	* [Timeline](###TimeLine)
 	* [Responsibilities](###Responsibilities)
  * [Observational Methods](###Observational-Methods)
  * [Querying Techniques](###Querying-techniques)
  * [Feedback and Changes](###Improvements-based-on-Evaluation/Feedback) 
* [Shaders and Special Effects](#shaders-and-special-effects)
	* [Particle System](###Particle-Systems)
* [Summary of Contributions](#summary-of-contributions)
* [References and External Resources](#references-and-external-resources)


## Evaluation Plan and Report

Testing our game with real players is necessary to gather qualitative and quantitative data on user experience, gameplay mechanics, and potential areas of improvement for the game. 
Therefore, we will invite 10 participants to test our game. 5 participants for observational evaluation and 5 participants for query evaluation. 

These participants will be close friends of ours also in University, but we will have people of different degree backgrounds and varying experience with video games.
We will randomly select participants from the library to test our game for the querying evaluation since we will be doing a questionnaire, making it quick and efficient. For the interview portion, we will be conducting it in a study room with close friends that have more experience with video games. 

The results will be written in an excel spreadsheet, then analyzed and written into an evaluation report. After every evaluation round, changes will be made on time and documented. 

Testing should be done regularly and improvements made simultaneously. 
Bug fixes should also be done regularly to prevent having too many problems near the end. Since we will have a Numeric Rating Scale for the questionnaire, if any score is below what we expected e.g. below 2.5 or above depending on the question, it will mean that we have to make changes to the game. 

### TimeLine:

| Date                                   | Event                                                                                                                  |
|----------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| Sunday 8th October                     | Evaluation demo complete<br>Evaluation plan also complete                                                               |
| Tuesday 10th October                   | Gather 5 people for Observational Evaluation                                                                            |
| Wednesday 11th October                 | Gather 5 people for Query Evaluation<br>First round of evaluation done.<br>At least 3 participants.                     |
| Saturday 14th October                  | Keep implementing changes from evaluations and making the gameplay video                                                |
| Sunday 15th October                    | Gameplay Video submission                                                                                              |
| From Monday 16th to Sunday 31st October| Keep getting participants to test games and improve the game.<br>Observational and Query Evaluation should be done at least once a week.<br>Analysis and report writing will be continuously done alongside any changes made in the game.<br>Changes such as bug fixes and new features or improvements to the game will be updated regularly on github.<br>Second and third rounds of evaluations should also be done during this time.<br>3-4 Participants per round of evaluation.<br>Total participants should be 10 at the end of evaluation period. |
| Sunday 31st October                    | Final Submission                                                                                                       |


### Responsibilities:

Depending on the bugs and fixes we need to do to improve our game, each task will be delegated equally among team members.

We will also find around 3-4 people per teammate to participate in the evaluation.

To ensure everyone contributes equally, clear communication is required. We will communicate regularly through the group chat, and use resources such as Trello to delegate tasks equally.

- **1 team member** will be in charge of the mechanics of the games. Such as features and abilities of the main character.
  - E.g. Enemy spawning, damage and abilities, controllers for moving entities in the game and camera movements.

- **1 team member** will work on shaders, the map and particle systems.
  - E.g. Shaders for the environment, particle systems for in game visual effects, making sure the map is generated correctly and there are no missing objects.

- **1 team member** will work on the menu scene, ending scene, cutscenes, instructions, and anything else to do with UI.
  - E.g. Polishing the menu scene with our own art, making the game more visually appealing, and making sure the instructions and objectives are clear so the player will be able to understand the narrative that we are trying to tell.


### Observational Methods

We will employ three observational methods in the evaluation process of the game. This is because the level of experience of each participant will be different, therefore to maximize feedback potential, we will be using the Think Aloud, Cooperative Evaluation and Post-task walkthrough methods. 
Depending on the type of player and the stage of development in our game, the observational method will differ.
We will give the player a choice, by asking them if they would like to think aloud while playing the game and if they would like assistance.
Given the answers, the appropriate method will be chosen to balance extracting information and avoiding interruptions. 

E.g If the player does not mind thinking aloud and having assistance, then the observer may choose either Think aloud or Cooperative Evaluation. 
On the other hand, if the player does not really want to think aloud or have assistance, then the Post-task walkthrough method is chosen. 
However, in the final stages of the game development, Post-task walkthrough will be used more often as we want to be able to have the players experience the game on their own without any external help as that will help indicate whether our game is on its way to being complete. 


#### 1. Think Aloud
While the player is playing the game, we will ask them to describe what they are doing, what they will do next, what they expect to happen, what they think about the map. If they are confused about anything, we would like them to voice it. Any thought they have about our game we want voiced.
This is a subjective way to gain information. It is a good way for us to get the player’s first-hand impressions of our game, we will be taking notes on what the player has to say. After they have finished playing the game, we will ask them questions to further clarify any remarks and feelings they had about our game.
Players using this method will likely be close friends, this will reduce the awkwardness and the opinions will be more honest.


#### 2. Cooperative Evaluation
This is like thinking aloud, but the player can actually ask us about the game. We can also give input and ask them to test features out. If the player would like to receive assistance during the game. This method is a good option. 
It is more collaborative and because experimenters can ask questions, a wider range of features and mechanics can be tested. 
In the early stages of game development, there will be bugs and unintentional situations that may occur. If the player encounters any of these obstacles, it is much more time efficient for the experimenter to help resolve those issues and in turn record the bug in the results. 
However we must be careful to not reveal too much as the results could become biased if we help too much. 


#### 3. Post-Task Walkthrough
Here, we will allow the player to go through the game without any interruptions. Afterwards, we will ask them about specific things they remembered about the game. To avoid the user forgetting things, we will record them while playing the game.
This method is useful towards the end of the project when we want to make sure that the game will be playable on its own. 
Here, the player can spend more time in the game environment and really test out the mechanics and game behavior. 


#### Results Table:
| Player Name | Date | Background | Querying Technique | Results | Evaluation |
|-------------|------|------------|--------------------|---------|------------|
|     Yolanda        |  Wednesday, 11th October 2023    |   Very little experience with games. Mostly mobile games.          |  Think aloud    |  Players initial reaction to the map was positive. She was very happy with the animations and graphics of the ducks and wolves. When playing the game, there were times where she felt the pace of the game was slow, especially when crossing the river and mud as there is nothing to do but wait until the main character passes through. Controls and objective was easy to understand.       |   At certain times, the game can feel boring and laborious, especially because certain areas of the map are long, with very little enemies at times.         |
|   Chaeyoung          |  Wednesday, 11th October 2023    |    Lots of experience with games, especially with role-playing PC games.        |   Cooperative Evaluation                 |  The players initial reaction to the game was positive. She understood the objective and controls of the game immediately. When she was exploring the map, we asked her to interact with objects such as wolves, water, mud and trees to test for any abnormalities in game physics. We asked her to explore as much of the map as possible to see her reaction and if it was interesting and captivating enough.        |    We found that the game needed more excitement. Having one standard enemy i.e. wolves, means that overtime, there is a lot of repetition. We could also remake the map to be more interesting.         |
|      Peter       |    Wednesday, 11th October 2023  | Lots of experience with mobile shooter games such as Valorant and MOBA games such as League of Legends |  Think aloud   |  Player knew what to do throughout most of the game. He followed the path on the map and killed wolves using the abilities of the mother duck. The game also challenged him, this surprised him. Due to the games low poly style and cute animations, players usually expect the game to be relatively slow paced and not as difficult and challenging. However, the game lasted around 4 minutes, which means we needed to either add new features or extend the map.        |  By adding new features, such as a boss fight and different types of enemies. The ending of the game can be more exciting, like a climax at the end of the story.           |
|         Ben    | Wednesday, 25th October 2023     |    Lots of experience with RPG and sandbox games such as Minecraft and terraria.        |   Post-Task Walkthrough                 |  Around this time, we had implemented new features, such as a boss fight with a bear at the end of the game, alligators in the river and changes to the map. By letting the player go through the whole game first, we were able to see how new players would approach the game. Seeing our game through a fresh pair of eyes allowed us to see the progress and potential areas of improvements. One particular area would be the swimming and mud. When abilities were used while in the river, sometimes the duck would go off into different directions making it hard to control. Additionally, the player was able to defeat the boss and make it home. The game also lasted more than 5 minutes which was what we hoped for.        |     The gameplay and mechanics of the game are not perfect yet. More testing of the duck in different areas of the map needed to be able to polish the player controls off. |
|     Grace        |   Wednesday, 25th October 2023   |  Beginner experience-level. Has played games such as Valorant and League with friends. |  Post-Task Walkthrough                  | Having someone who does not often play games was actually really useful. We were able to test if our controls and objective for the game was clear. We were also able to see if the difficulty of our game was too high for an average player. Watching our player go through the game, we were able to see their reactions to certain features in the game. Overall, it was a positive gameplay experience for our player. However, there were still some minor bugs and details that had to be fixed and polished.        |   Fix bugs on movement, polish the main menu and ending scene. Continue testing on others to find more bugs and improve gameplay experience.         |



### Querying Techniques

#### 1. Questionnaire
Questionnaires are easy to administer and analyze. They allow for easy comparison across different users and can involve as many participants as possible. 
That is why we choose to use a Questionnaire on our players that are less experienced with video games. 

- We will use closed questions in our questionnaires and a Numeric Rating Scale from 1 to 5. We will then take the average response across all players.

| Questions                                                     | Stephanie    | Tony             | Jack   | Sofia  | Evita | Average Response |
|---------------------------------------------------------------|--------------|------------------|--------|--------|-------|------------------|
| I found the game fun                                          |     4        |        3         |    4   |   3.5  |   4.2 |        3.74      |
| The game controls were easy to understand and use             |    5         |      4           |   4.5  |   4.7  |   5   |      4.64        |
| The graphics were visually appealing                          |        3     |        3.5       |   3    |     4  |   3.5 |        3.4       |
| I found the game challenging                                  |         4    |         4        |  3.5   |   4.5  |   3   |            3.8   |
| I found the storyline interesting                             |       4.5    |        4          |    4    |    3.8    |     4.5  |         4.16         |
| I found the game quite buggy                                  |        4.8   |          5        |    4    |    4    |   3.5    |        4.26          |
| The gameplay was smooth and there were no noticable glitches  |  2.5         |           2       |     3   |     2.5   |    2   |          2.4        |
| I felt there was enough features in the game                  |        4     |            4      |      3.5  |    3    |    4   |         3.7         |
| I found the objective clear and easy to navigate              |        5     |             5     |      4.5  |     5   |    5   |        4.9          |
| I would play this game again                                  |       4.5    |              5    |      4.5  |      5  |    5   |        4.8          |


#### 2. Interview 
In our Evaluation Plan, a decision was made to prioritize interviews with players who possess an extensive history of engaging with a wide array of video game genres and timed survival mechanics. This group of players would be uniquely positioned to provide in-depth, critical, and constructive feedback.

Reasons why: 
1. Expertise: Players with a broad gaming background are likely to have encountered diverse game mechanics, narratives, and design philosophies. This allows them to draw comparisons and contrasts more effectively.

2. Critical Evaluation: Their experience equips them to discern subtleties in gameplay, which can lead to more incisive critiques.

3. Identification of Flaws: Players can help pinpoint areas of weakness, potential design oversights, and technical bugs that may be overlooked by in-experienced players.

4. Affirmation of Strengths: While identifying areas of improvement is crucial, recognizing the game's strengths is equally significant. Experienced players can provide validation on elements the game executed well.

By leveraging the insights of more experienced players, we aim to harness their expertise and feedback for a comprehensive evaluation of our game, ensuring that it meets high standards. 

The interview should be structured as a verbal questionnaire. It would be like a conversation with close-ended questions to focus on the qualitative aspects of the game in order to grasp a feel of player experience. The second part of the interview will be open-ended questions that give the players opportunities to expand on their close-ended answers and give any additional feedback. 

- **Close-Ended Questions**

    | Close-Ended Questions                  | Overall Feedback                                                                                                       |
    |----------------------------------------|------------------------------------------------------------------------------------------------------------------------|
    | Did you feel a consistent sense of urgency due to the time-based survival element? | Positive: Players felt the time pressure throughout the game, this kept them engaged. |
    | Were the game’s objectives clear to you from the start? | For the most part, players answered yes. However, due to the map changes, sometimes the players found themselves wandering off into areas that were not part of the playable map. |
    | Is the game beginner-friendly or not? | Game is moderately beginner-friendly. Mechanics and controls were easy to get, but took a bit for players to get used to. |
    | Were the game controls easy to use and understand? | Everyone said yes. The controls were intuitive and well-laid out.  |
    | On a scale of 1 to 5, how would you rate the game’s storyline or narrative? | Average response was 4, story was engaging and had some unexpected twists. Also it is not everyday you see a duck as the main character in a game. |
    | Did you encounter any technical glitches or bugs while playing? | Yes, there were glitches where the character sometimes is unresponsive to mouse clicks in certain areas of the map. However, this is a rare occurrence. |
    | Did you enjoy playing the game? | Overall everyone enjoyed playing the game. It was also visually appealing as a bonus. |
    | Do you think the game is suitable for all experience levels ? | Yes, we tested the game on beginners, intermediate and advanced players and they all enjoyed it. |

- **Open-Ended Questions**
    | Open-Ended Questions                  | Overall Feedback                                                                                                       |
    |----------------------------------------|------------------------------------------------------------------------------------------------------------------------|
    | What aspects of the game stood out to you the most, both positive and negative? | Positive: Interviewees said the graphics, animation, the style of the map were outstanding. Atmosphere, vibe and tension were good. Negative: Some of the enemy AI was a bit repetitive, certain sections of the game is not as smooth. Some parts of the game felt a bit slow or laborious. |
    | How would you improve the game’s time-survival element to enhance player engagement For example any features that could be added or new mechanics that will make the game more enjoyable. | Interviewees suggested implementing features such as power-ups, a boss at the end of the game, more enemy variation. Perhaps introducing more varied challenges and random events to heighten the sense of urgency. |
    | Please provide feedback on the game’s environment, was it easy to navigate, was it visually appealing and was it easy to navigate around? | The game world was visually stunning with diverse landscapes. However, at times, players found it challenging to discern the right path to take, which could be frustrating. A more intuitive map or better signposting would help. |
    | What did you think of the game overall and how can it be improved? | Overall, interviewees loved the game’s overall concept and execution. To improve, they suggested to focus on refining the AI, addressing the technical glitches, and possibly introducing more varied enemies or features |
    | Would you recommend this game to people around you? If so, what type of people would you recommend this to and why? | Yes, every interviewee said they would recommend ti to players of all experience levels. They would especially recommend it to players who enjoy time-based survival games and cute natural graphics. | 


    

### Improvements based on Evaluation/Feedback 

#### 1. Enhancing Game Engagement
- **Diversity in Challenges** : The game lacks variety in enemies, leading to repetitiveness.
  - We introduced new enemy variation to keep the gameplay fresh and challenging:
    - Crocodiles in the river
    - Final boss fight with bear at the end of the game. This creates a heightened sense of achievement for the players.

- **Map Dynamics**:  Players found some areas of the map lengthy and less engaging. We redesigned parts of the map to be more interesting and stimulating, including dead ends and being less predictable.
  
- **New Features in Game**: We added in berries which the player can pick up that lets the duck heal revive a chick. 
     
#### 2. Gameplay & Mechanics
- **Bugs and Glitches** : An average score of 2.4 in the "smooth gameplay" section indicates technical issues. We prioritised identifying and fixing bugs, especially those related to movement near the end of the game development process.

- **Player Controls**: Some players might have found the controls less intuitive or smooth. We refined player controls based on feedback and ensure they are responsive and easy to grasp.

#### 3. Visual & Audio Experience
- **Graphics** : The graphics received an average score of 3.4. To enhance the visual appeal by we improved textures, animations, and environmental details.
  
- **Main Menu and Ending Scene** : These elements serve as the first and last impression of the game. We made sure they are polished, intuitive, and visually appealing.

#### 4. User Experience
- **Regular Testing** : Finally, we will continuously test the game on different players to gather diverse feedback. This will aid in capturing a wide range of pain points and preferences. Until the end of the game development process. 


## Shaders and Special Effects

The current shaders that are implemented in our game, both of which are CG shaders, are: Water and Cel Shading. The two shaders were also created under the guidance and derived knowledge of tutorials to help enhance the visual aspects of our game. More on this below. 

### Shader 1: Water.shader 
Accessible [here](https://github.com/COMP30019/project-2-naurway-studios/blob/main/Assets/Shaders/Water.shader), or at Assets/Shader/Water.shader

This shader was based off of Roystan's ['Toon Water Shader'](https://roystan.net/articles/toon-water/) due to its toon-like approach to fit into the game's style. This tutorial was easy to follow and helped in deepening shader understanding alongside what was learnt alongside this course. There were concepts learnt in workshops that were applied in very creative ways which I will get into. 
<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/waterArt.png" width="400"/>
</p>

This shader functions create visual effects and water colour through calculating the water depth - relative to the camera's view - and then uses this information to creatively render the 'shoreline' foam of water. Noise and distortion textures were then used to create the surface waves. Lastly, actual wave movements were added through the vertex shader using sin through the x and y planes to create a dynamic and animated water surface. 
<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/riverGif.gif" width="400"/>
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/duckswim1.gif" width="400"/>
</p>
<p align="center">
  Here we have the river in game with the waves flowing and the water shader
</p>

<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/riverView2.png" width="400"/>
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/duckSwimming.gif" width="400"/>
</p>

**Properties**: 
The shader defines a set of properties for colours, textures and more appearance control related variables for customization. The vertex shader, besides transforming object vertices into clip space, handles wave movement which as mentioned before was through the manipulation of x and y axis with sin. This was controlled by the _Frequency and _Amplitude properties and helped create the effect of lapping 'waves' on the shores. 

```
Properties
    {	
        _Shallow("Depth Gradient Shallow", Color) = (0.325, 0.807, 0.971, 0.725)
        _Deep ("Depth Gradient Deep", Color) = (0.086, 0.407, 1, 0.749)
        ...
        _Frequency("Frequency", Range(0, 200)) = 100
        _Amplitude("Amplitude", Range(0, 2)) = 1
        
    }   

```
The 'Properties' block defines the shader's editable parameters that can be changed within the Unity editor to customise the appearance of water.

**SubShader**: The SubShader block describes how the shader should be rendered by the graphics pipeline. 
* We set it to render in the transparent queue with forward base light mode, which means it will be drawn after opaque objects and will interact with directional light sources.
* It uses blending to ensure transparency is handled correctly, and it does not write to the Z-buffer (ZWrite Off), which is typical for transparent objects to avoid depth conflicts.
* The 'Pass' block block contains the programmable GPU code that defines exactly how the pixels and vertices will be rendered:
  * alphaBlend: A custom blending function for combining the foam and water colors.
  * Vertex and fragment shader functions (vert and frag) for calculating the vertex positions and the final colour for each pixel.

```
SubShader
    {
        Tags {
            "RenderType"="Transparent" 
            "Queue"="Transparent"
            "LightMode" = "ForwardBase"
	          "PassFlags" = "OnlyDirectional"
        }
        Pass
        {

            #include "UnityCG.cginc"
            float4 alphaBlend(float4 top, float4 bottom) {
               ...
            }

            v2f vert (appdata v)
            {
              ...
            }

            float4 frag (v2f i) : SV_Target
            {
               ...
            }
        }
    }

```
The fragment shader calculates the depth of each pixel relative to the camera and relative to the surface of the water. Colours were then interpolated between the _Shallow colour and _Deep colour to form the water. _CameraDepthTexture was the depth map obtained and used for this. Additional movements were introduced via a distortion texture where the red and green channels were used to pull the noise texture to create dynamics and flow. 

**Shader Functionality**
* When the shader is applied to a mesh, it will render the mesh with a water-like appearance.
* The colors will change from shallow to deep based on the distance from the surface, simulating how water appears in real life.
* The noise texture adds variation to the surface, making it look more like water rather than a flat surface.
* The foam is created based on the depth and the noise texture, giving the impression of waves and froth.
* The distortion texture is scrolled over time to create the illusion of moving water.
  <p align="center">
    <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/waterComponent.png" width="500"/>
  </p>



<br></br>
### Shader 2: CelShading.shader
Accessible [here](https://github.com/COMP30019/project-2-naurway-studios/blob/main/Assets/Shaders/CelShading.shader), or at Assets/Shader/CelShading.shader

This shader was a blend of knowledge learnt from both Roytoon's ['Toon Shader'](https://roystan.net/articles/toon-shader/)  and Daniel Iletts ['Cel Shading Introduction'](https://danielilett.com/2019-05-29-tut2-intro/) to create the desired effect. Outlines were also added through using stencil buffer operation to further enhance the toon effect and to not lose the objects inherent shape to the colours. This was the shader that created the biggest different visually to the game based on toon/cel shading concepts.

<p align="center">
  <img src = "https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/world.png" width= "400"/>
  <img src = "https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/worldLook.png" width="400"/>
</p>

The properties defined handle the customizable properties of the shader, including specular reflections, rim lighting and colours for each. There are also properties for antialiasing, intensities and outlines. This shader also contains two pass's, one for the main rendering and one to render the outlines. The first pass does the transformation of object vertices to clip space, shadow coordinates transfer, calculations of normals and uv coordinates to transfer various parameters to the fragment shader. The lighting model used to calculate diffuse lighting is Lambertian lighting (lighting point on a surface is based on the angle between light source and normal vector, calculated by the dot product). Shadows are included through the use of SHADOW_ATTENUATION(i). 

```
// Lambertian Lighting
  float3 normal = normalize(i.worldNormal);
  float diffuse = dot(_WorldSpaceLightPos0, normal);
```

Specular lighting here is based on the Blinn-Phong model and calculates the specular intensity based on the dot product between the half vector (vector halfway between view and light direction) and the normal vector. It's then modified based on _Glossiness which was multiplied twice to have a larger effect. The rim lighting (light around the edges of an object) was then created from the inverse of the dot product between view direction and normal vector. 

```
// Blinn-Phong Lighting
float3 halfVec = normalize(_WorldSpaceLightPos0 + viewDir);
float lightDotP = dot(normal, halfVec);
float specularIntensity = pow(lightDotP * diffuseSmooth, _Glossiness * _Glossiness);
```
There was an alteration made to transfer shadow coordinates since TRANSFER_SHADOW() wasnt initalizing properly, to which a fix was found from [this forum](https://forum.unity.com/threads/shader-warning-with-no-reason.1103143/) thread. 

Lastly, the second pass focused on rendering the outline which was achieved through stencil testing taught by Daniel Iletts tutorial as linked above. Objects are rendered with a specific stencil ID then rendered again with a different stencil comparison in order to create the outline effect. The different stencil ID ensured lines are able to be seen over different materials.
In the vert function, it inflates the object's vertices along their normals by the _OutlineSize, and the frag function simply outputs the _OutlineColor.
```
 Pass {

    Stencil {
	Ref [_ID]
	Comp notequal
	Fail keep
	Pass replace
    }
    ...
    v2f vert(appdata v) {
	v2f o;
	float3 normal = normalize(v.normal) * _OutlineSize;
	float3 position = v.vertex + normal;

	o.vertex = UnityObjectToClipPos(position);

	return o;
    }     
}

```
<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/celShaderComponent.png" width="400"/>
</p>
<p align="center">
The celShader was added to every object as a material
</p>


Here are some examples of the shader working in gameplay: 
<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/wolfStun.gif" width="400"/>
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/bearMap-wShader.png" width="400"/>
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/newQAbility.gif" width="400"/>
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/main/Images/Screenshot%202023-10-31%20at%2010.41.48%20PM.png" width="400"/>
</p>
  
<br></br>
<br></br>
### Particle Systems

We have used two particle systems to enhance visual effects in our game. 
One is a Firefly Particle System and the other is a Blood VFX Particle System.

#### FireFly Particle System
<p align="center">
  <img src = "https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/fireflies.gif" />
</p>
<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.31.27%20AM.png" width="300"/>
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.31.05%20AM.png" width = "300" />
</p>
The Firefly Particle System is one of the two particle systems employed to elevate the visual effects in our game. It is designed to create a realistic firefly effect, enhancing the immersive and atmospheric elements of the game environment. 
Randomness was utilised in the Firefly Particle System using the Noise attribute. This allowed the particles to move in random directions, contributing to a more realistic effect.
<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.29.07%20AM.png" width = "600"/>
</p>

  **Attributes Varied**
  - Start size set to small to mimic the size of real fireflies.
  - Start speed is 0 becaseu fireflies don't start moving immediately.
  - Emission = 20, to create a significant number of fireflies
  - Shape = Sphere, allows fireflies to disperse in all directions
  - Radius = 10, give the fireflies wide area to move in
  - Colour over lifetime = yellow to mimic the glow of real fireflies.
    <p align="center"> 
      <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.50.33%20AM.png" width = "300"/>
    </p>
  - Size over lifetime attribute was set to give the effect of fireflies twinkling in the distance
  - Noise was applied to have particles move in random directions, imitating the erratic flight pattern of fireflies. The strength was decreased to give the particles a slow, softer effect, again mirroring real fireflies. The frequency was also adjusted to further enhance this effect.
    
      <p align="center">
        <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.42.17%20AM.png" width = "300" />
        <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.47.41%20AM.png" width = "300"/>
        <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.48.50%20AM.png" width = "300"/>
    </p>


#### Blood VFX Particle System Using Shader Graph 
The Blood VFX Particle System is the second particle system used in our game to create visually striking effects. Specifically designed using custom a Shader Graph and Material to simulate the appearance of blood in a realistic and engaging manner.
<p align="center">
  <img src = "https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/blood%20clip.gif" />
</p>

<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.55.49%20AM.png" width="300"/>
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2011.55.57%20AM.png" width = "300" />
</p>


##### Blood VFX Shader Graph 
The Shader Graph was used to create custom shaders for the Blood VFX Particle System. This provided the flexibility to design the visual effects with precise control over how the particles look and behave. Using Shader Graph, we could procedurally generate a realistic-looking blood texture, add movement to the particles, adjust the thickness and contrast of the blood, and create a more volumetric look by adding a normal map.

Randomness was utilized in several ways including the start lifetime, size, and start rotation of the particles to create a more realistic and varied blood effect.
The rationale for these choices was to create a blood effect that is visually striking, realistic, and enhances the overall aesthetic of the game. The blood effect was also designed to perform well and not overload the game as the number of enemies increases.

<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2012.21.12%20PM.png" width="800"/>
</p>
<p align="center">Full Shader Graph - The Nodes on the left before the blue nodes are part of the procedurally generated Blood VFX</p>

<p align="center">
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2012.18.10%20PM.png" width="150" height = "300"/>
  <img src="https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/Screenshot%202023-10-28%20at%2012.31.10%20PM.png" width="150" height = "300"/>
</p>
<p align="center">Shader Graph Attributes</p>

  **Explanation**
  1. In the master node we first added base, emission and specular colouring. 
  2. Added simple noise, scaled to 40, this makes our texture become transparent in places of black spots
  3.  Then we added mask, we added texture2D, using the default unity particle texture, and connected it to Sample texture 2D, added it to a multiply node, so that we can subtract our mask from our noise
  4.  Smoothness 0, so it becomes darker.
  5. Tiling and offset connected to UV of simple noise. To make the particles move at the speed we want, we controlled the speed by adding in a Float called Speed.
  6. We multiply the time by our speed and connect the result of the multiplication to the tiling and Offset nodes Offset.
  7. Next we added a second layer of noise, with scale 100 so it is more granular, multiply that with our original simple noise with the more granular simple noise. And connected that multiplication with the other multiplication that is multiplying our Mask.
  8. Next we added more movement to our particles, we did so by adding a Tiling and Offset node to our more granular noise, connect it to the UV of the granular noise. We want to make it move in the opposite direction, so we multiply it by the result of the multiplication of time by speed by -1 and connect it to the Offset of the second Tiling and Offset node
  9. Next, the blood looks a bit thin, so we want to increase the thickness. To do this, we multiplied our noise pattern by 2, so that it becomes brighter. Then we increased the contrast by 3, and then connect our new multiplication with the Mask.
  10. Next, to make it more volumetric, we add a normal map. We do this by adding a node called Normal from Height. From our procedurally generated Blood texture we connect to the normal from height node, then we add a normal strength node with a value of 4, and connect to Normal of the master node.

<p align= "center">
  <img src = "https://github.com/COMP30019/project-2-naurway-studios/blob/README_Drafts/Images/blood.gif"/>
</p>


**Blood Particle System Varied Attributes**
1. Duration = 1.5, allows the blood effect to persist 
2. Randomise Start Lifetime between two constants 4 and 7 to create variation in the lifetime of the blood particles
3. Size of blood particles randomised with values between 2 and 2.2 to give more textured and realistic appearance.
4. Start rotation randomly set between 0 and 360 degrees for more dynamic and less uniform blood effect
5. Gravity modifier = 2, mimics effect of gravity on blood.
6. Start Speed = 0.5
7. Shape = Sphere, allows blood particles to disperse in all directions for a more dramatic effect.

**Blood Particle Instantiation**
When enemies or ducklings die, the blood particle system game oject will be instantiated. 
```
LivingEntity,cs Script
//For blood on death
public GameObject Blood; // New attribute 


public virtual void Die()
{
    Destroy(gameObject);

    if (Blood is not null)
    {
        Instantiate(Blood, transform.position, Quaternion.identity);
    
    }
 
}
```

The script for destroying blood effects helps maintain optimal game performance by removing instances of the blood particle system, preventing the game from becoming burdened over time. This is particularly important as the quantity of enemies, and therefore blood effects, increases during gameplay.

```

public class BloodDestroyer : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.5f); // after 0.5f the instantiation of the Blood game obejct will be destroyed
    }
}
```


#### Which One to Mark and How to Locate 
Blood Particle System: <br> 
Go to Assests -> Particle Systems Folder -> Blood Particle Systems Folder -> Blood Particle System Built-In Shader Foler -> BloodVFX - InBuilt Shader Graph Prefab

## Summary of Contributions

### Edwin Li
Game mechanics,Boss fight, enemies, GDD, README, map, camera, player abilities, 

**Development Branches on GitHub**
* https://github.com/COMP30019/project-2-naurway-studios/tree/dev/ed
* https://github.com/COMP30019/project-2-naurway-studios/tree/feat/ability-revamp
* https://github.com/COMP30019/project-2-naurway-studios/tree/feat/boss-fight

### Lin Xin Xie
UI, water shader, celshading, game over and victory scenes, GDD, README, power ups, map 

**Development Branches on GitHub**
* https://github.com/COMP30019/project-2-naurway-studios/tree/dev/lin
* https://github.com/COMP30019/project-2-naurway-studios/tree/feat/celshading
* https://github.com/COMP30019/project-2-naurway-studios/tree/feat/game-over-and-victory
* https://github.com/COMP30019/project-2-naurway-studios/tree/feat/interactable-berries

### Emily Gong
Firefly particle system, blood particle system, mud and water phyics, UI, GDD, README, audio 

**Development Branches on GitHub**
* https://github.com/COMP30019/project-2-naurway-studios/tree/feat/blood-particle-system
* https://github.com/COMP30019/project-2-naurway-studios/tree/feat/emily-dev
* https://github.com/COMP30019/project-2-naurway-studios/tree/feat/water-physics



## References and External Resources

**Particle System** 
* https://www.youtube.com/watch?v=zN9NbQRzZ0c
* https://www.youtube.com/watch?v=0PY5oV7yU4Y&t=300s
* https://www.youtube.com/watch?v=9O5XU_jshBU

**Shaders**
* https://roystan.net/articles/toon-shader/
* https://roystan.net/articles/toon-water/
* https://danielilett.com/2019-05-29-tut2-intro/

**Assets**
* Environment:
  * https://assetstore.unity.com/packages/3d/environments/landscapes/free-low-poly-nature-forest-205742
  * https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153
* Ducks:
  * https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-farm-animals-vol-2-182396 https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-animals-mega-pack-vol-1-137259
* Enemies:
  * https://assetstore.unity.com/packages/3d/characters/animals/low-poly-animated-animals-93089

**GamePlay**
* https://youtu.be/t5r0AWkdLB8?list=PLuKMRhgr5rGkgABx8Sezws-ekSWIWRf4Q
* https://youtu.be/pJoCnuzwe68?t=87

**Music**
* Yu-Peng Chen & Genshin Music
* All music used is not for commercial reasons.

