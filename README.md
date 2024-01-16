# Guide d'utilisation

Pour exécuter le code et tester l'application, suivez ces étapes :

## Étape 1 : Configuration de l'environnement de développement

1. Assurez-vous d'avoir Visual Studio installé sur votre machine. Si ce n'est pas le cas, téléchargez et installez la dernière version depuis le [site officiel de Microsoft](https://visualstudio.microsoft.com/).

2. Ouvrez Visual Studio et créez un nouveau projet Windows Forms Application. Choisissez le langage C#.

3. Télécharger et copier le code.

## Étape 2 : Test de l'application

1. Assurez-vous d'avoir remplacé "URL_DE_L_ARCHIVE" par l'URL réelle de votre archive à télécharger.

2. Exécutez l'application en appuyant sur F5 ou en cliquant sur le bouton de démarrage dans Visual Studio.

3. L'interface utilisateur de l'application devrait s'ouvrir. Testez le bouton de téléchargement en spécifiant un chemin de destination.

## Étape 3 : Build en format .exe

1. Une fois que vous avez testé que l'application fonctionne correctement, il est temps de créer un exécutable (.exe).

2. Dans Visual Studio, allez dans le menu "Build" et sélectionnez "Build Solution" ou "Rebuild Solution" pour vous assurer que le projet est compilé avec succès.

3. Le fichier exécutable sera généralement situé dans le dossier `bin\Debug` ou `bin\Release`, en fonction de la configuration de build que vous avez choisie.

4. Vous pouvez distribuer le fichier .exe généré à d'autres utilisateurs.

Veuillez noter que si votre application nécessite des privilèges élevés (par exemple, pour écrire dans certains dossiers système), vous devrez peut-être exécuter l'application en tant qu'administrateur sur certains systèmes d'exploitation.

N'oubliez pas de gérer les exceptions et les erreurs de manière appropriée dans un environnement de production, et assurez-vous de respecter les bonnes pratiques de sécurité lors du téléchargement et de l'extraction de fichiers depuis Internet.