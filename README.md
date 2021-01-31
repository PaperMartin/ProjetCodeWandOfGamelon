# DUNGEON_CRAWLER_PROJECT_(Martin_WETISCHEK,_Pierre_JEANNE)

## Rendu pour le 29/01/2021

___________________________
## Présentation du jeu
Le jeu est un dungeon crawler proche du gameplay du premier Zelda. Le joueur se déplace avec ZQSD, et attaque avec la barre espace ou le clic de souris dans la direction dans laquelle il est tourné. Le but du jeu est d'aller le plus loin possible dans le Domaine Céleste, en évitant ou combattant les ennemis sur le chemin.

## Direction artistique
Le code couleur se veut proche des couleurs de la Game Boy, tandis que l'univers et le pixel art sont volontairement similaires à celui de Kid Icarus.

## Description du fun
Le fun du projet est d'explorer les niveaux et de tuer les ennemis, en tâchant de survivre le plus longtemps possible ; le joueur n'a que trois vies.

## Description technique et Problèmes rencontrés
Le joueur utilise pour ses animations et son contrôle le nouvel input system d'Unity, ainsi que des comportements à base de states dans un Animator dédié. Les ennemis utilisent également un système de states, dont certains comportements sont partagés avec le joueur (comme le système de Stun, par exemple).

Le générateur de map est composée de plusieurs classes :
Un scriptableObject MapRoom qui contient le prefab d'une salle
Un scriptableObject RoomList qui contient toutes les MapRoom ayant la même configuration de portes
Un struct DoorConfig qui contient 4 booléennes correspondantes à quelle portes sont ouvertes ou fermé dans une salle (en haut, en bas, a gauche et a droite)
Un ScriptableObject GeneratorData  qui contient toutes les données nécéssaires pour la génération de map (les roomlists pour chaque configuration de salle possible, la longueur du donjon en nombre de salle, la largeur et longueur de la map en nombre de salle, la taille physique des salles, et toutes les salles de départ et de fin)
Un MonoBehaviour MapGenerator qui contient toute la logique pour la génération de map

La génération de map se fait en plusieurs étape : 
La génération de chemin, qui génère une liste de Vector2Int qui représente le chemin de la map, de la première à la dernière salle, et est généré en prennant en compte la taille de la map et la longueur de chemin demandée
La génération de doorconfig, qui calcule les configurations de portes de chaque salle du chemin selon la salle précédente et la salle suivante
Le choix de salle, qui choisit une salle au hasard dans la roomlist correspondante à la doorconfig de la salle actuelle
L'instantiation de la map, qui instantie les préfabs de chaque salle de la map dans les bonnes positions

# Vidéo
Lien de la vidéo : 

https://youtu.be/mpI0YI9Q4QI

# Licences des sons

Son de Stun et Son d'Attaque : 
https://sfbgames.itch.io/chiptone

Game Over : 
8 bit Game Over, 80s arcade, simple alert notification for game 1
https://www.zapsplat.com/

Land of 8 Bits (By Stephen Bennett) :
https://www.fesliyanstudios.com/

Stage 3, by Sawsquarenoise : 
https://creativecommons.org/licenses/by/4.0/ 







