# Wizard's Chess
### **WINNER** of the Best Use of Google Cloud Award at Snakes and Hackers 2021!

[![Demo video](https://github.com/jordansmithsgames/jordansmithsgames/blob/main/readmes/wizardschess/youtubegif.gif)](https://www.youtube.com/embed/guHtKY6lrWA)

(Psst, check out the [Devpost](https://www.devpost.com/software/wizard-s-chess-5qwber)!)

# Inspiration
Chess is a game that is functionally perfect. It is complex to master yet simple to pick up and play, and many, many people know how to play it. Going with the theme of this hackathon, we thought that making the game of chess a VR experience would be a lot of fun and would add a cool spin to this classic game. Inspired by Wizard's Chess from the Harry Potter series, we decided to make a VR Chess game where the player moves the different pieces in the game via a levitation spell.

# What it does
Wizard's Chess is a multiplayer Virtual Reality version of the popular board game chess, where players use voice commands and their hands to move the pieces. In Wizard's Chess, players take the unique perspective of commanding the different pieces they have to move with a spell. It requires the user to touch the piece to cast the enchantment, and then the piece will float through the air to the desired position, like magic!

# How we built it
With just 2 people in our group, we had to divide up the art and programming almost evenly to get by on such a tight schedule. We used Maya to model all the assets used in the game, and Substance Painter to texture and bring the models to life. The game was then brought together in the Unity 3D game engine, using the Oculus Quest VR headset and controllers to experience it in VR. We also used a multiplayer scripting library for Unity called Photon in order to allow players to play over the internet.

# Challenges we ran into
A lot of the challenges were programming related. Each unit has a different way of moving around the map with a lot of limitations that we had to accommodate. We also spent a lot of time kicking around the idea of programming an AI-based chess playing opponent that the user could play against, but we eventually snapped back to reality and realized that was probably too much to do for a 36-hour hackathon project!

# Accomplishments that we're proud of
In past projects done together, Aadithya tended to focus more on the art, while Jordan did the programming. We decided to even it out this time, as about half the assets were made by each member as well as around half of the scripting. We're both very proud of the results we got from this exercise in stepping outside of our comfort zones.

For a relatively simple idea, VR chess, we set out to do a lot of ambitious things, most of which we achieved. We managed to implement VR controls and interfacing with the Oculus Quest, as well as allowing players to join over the internet through the use of Photon's Multiplayer libraries for Unity so they could experience VR chess together. We were also very proud of how all of the assets (except for the wizard's hat) were modeled and textured by us in Maya and Substance Painter, and how well the "magic movement" of the chess pieces turned out. Overall we are very pleased with how smoothly the development process was overall.

# What we learned
We learned how to make VR work in a multiplayer setting, with networked 3D objects and animations, as well as how to use Google's Speech to Text engine for our uses in commanding the pieces to move.

# What's next for Wizard's Chess
There is a lot we still want to do with Wizard's Chess. Chess in itself is a complex game with many rules and puzzles that can still be implemented. We plan on taking this project further and developing it more, specifically in the following ways:
1. Main menu, with options to choose your wizard's skin color, hat color, and wand color.
2. Hands-free magic movement; simply point at a chess piece with your wand and command it to move to a certain board position.
3. Possible moves display; when highlighting a piece with the wand, the possible tiles that the piece can be moved to will be indicated by glowing text above the tile detailing the tile's position on the board, e.g. "A4".
4. Chess puzzles for those who want a single-player VR chess experience.
5. An extra map or two, such as the chess board being in an open meadow or in a large cathedral. Something medieval! That's all the concrete ideas we had, but we're sure to have a bunch more in the days following the deadline.
