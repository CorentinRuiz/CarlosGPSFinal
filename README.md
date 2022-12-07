# Projet Lets'go Biking (SI4 FISA)

## Cyril Vrousos et Corentin Ruiz

Pour lancer le serveur :

- Tout d'abord ajouter msbuild* dans la variable PATH de Windows
- Ensuite ajouter activemq dans le PATH de Windows
- Pour finir lancer en Administrateur le fichier a la racine runServer.bat
- En cas de non fonctionnement du msbuild il est toujours possible de lancer le Server.sln puis générer la solution depuis l'IDE.

Pour lancer le client :

- Suite à l'utilisation de JavaFx nous somme pas arriver a lancer le client depuis un .bat
- Il faut utiliser un IDE de préférence IntelliJ.
- Avoir un JDK 17 (Open-jdk-17 ou Amazon-Coretto-17-0-5).
- Puis lancer le Main dans org.carlosgps 

Help :
- MSBuild se retrouve dans "C:\Program Files\Microsoft Visual Studio\2022\Community\Msbuild\Current\Bin"
- L'affichage de la map sur le client peut parfois buguer car nous avons utliser un moyen détourner pour la faire fonctionner sous javaFx
- Il suffit de relancer le client pour quelle fonctionne à nouveaux
