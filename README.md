<br />
<div align="center">
 <h3 align="center">Desert Combat 2D Game</h3>
</div>

## Instructions
### Installation
1. download files and load up project in Unity
2. Select full HD (1920 x 1080) in unity editor
3. Press play, the game will begin immediately

### Controls
* A/D -- left-right movement
* J -- normal meele attack
* K -- hold for charge attack
* R -- restart game after game over/winning

### Win Conditions and Scoring
* Current score, enemies left, wave, and HP are displayed in the top right corner
* You will lose if HP reaches 0
* You will win if you complete wave 3 
* Each wave will be completed when enemies left reaches 0 and will be accompanied by a clear ding sound
* You have to hit enemies with your normal attacks and charged attacks to eliminate them
* Every hit you land (indicated by a clanging sound) will earn you 1 point
* Every enemy you elimnate will earn you 5 points

### Expected behavior
* player can move only on 1 axis by using the a/d keys at a constant speed
* player can execute the normal attack on a 0.5 second cool down 
* the normal attack will launch 2 attacks consecutively (indicated by two separate sounds)
* player can execute charge attack after holding down 'k' key for more than 0.3 seconds
* the charge attack will launch 4 attacks in quick succession (indicated by four separate sounds)
* enemies will always spawn near the edge of the map and will have speeds uniformly distributed around a small interval
* enemies will spawn every time an enemy is eliminated during a wave
* new enemies will spawn every time a wave is cleared (2 more on wave 2, 3 more on wave 3)
* enemies will have more hit points during the higher waves (3 on wave 1, 4 on wave 2, 5 on wave 3)
* player will be required to eliminate more enemies each succeeding wave to complete them (3 on wave 1, 15 on wave 2, 36 on wave 3)
* game over screen or you win screen will appear depending on if player has lost all HP or has cleared all three waves
* player HP, wave count, score will be reseted every time the game is restarted

## Credits
* background + characters: [https://penusbmic.itch.io/](https://penusbmic.itch.io/)
* sounds: [https://mixkit.co/free-sound-effects/hit/](https://mixkit.co/free-sound-effects/hit/)
