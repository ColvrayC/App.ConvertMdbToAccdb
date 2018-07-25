Le rôle de l'outil permet de convertir des bases de données mdb en accdb. Access n'es pas necessaire.


[PROCEDURES]

1. Ouvrir BIWEE, allez dans "Paramètres", "Mes Options" et décocher la case "Forcer Biwee en 32 Bits".

2. Fermer Biwee

4. Intégrez à la fin, la commande CMD dans le fichier bat de génération du fichier mdb : call "chemin\ConvertMdbToAccdb.exe" "cheminBaseMDB"

3. Lancez le fichier bat en tant qu'administrateur (seulement pour cette fois). Cela permet d'installer le moteur Access si necessaire et d'effectuer un premier test de conversion.



[LOGS]

En plus des informations affichées dans la console (erreur ou message), ces derniers sont enregistrés dans le fichier Logs.txt.


[COPIER / COLLER]

Pour copier ou coller du texte dans la console il suffit de faire un clic droit sur l'entête de la fenêtre Windows, puis modifier.

[FERMETURE AUTOMATIQUE]

Quand l'éxecution se termine, l'application se ferme au bout de 5 secondes.