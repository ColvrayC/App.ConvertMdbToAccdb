Le rôle de l'outil permet de convertir des bases de données mdb en accdb. Access n'es pas necessaire.

Il doit toujours être lancé manuellement en tant qu'administrater la première fois !

[PROCEDURES]

Au premier lancement l'outil vérifie que le pilote nécessaire au bon fonctionnement soit installé. Si ce n'est pas le cas, il l'installe en silencieux. 

Pour l'exécution, utiliser la commande cmd suivante :

call "chemin\ConvertMdbToAccdb.exe" "CheminBaseMDB"



[LOGS]

En plus des informations affichées dans la console (erreur ou message), ces derniers sont enregistrés dans le fichier Logs.txt.


[COPIER / COLLER]

Pour copier ou coller du texte dans la console il suffit de faire un clic droit sur l'entête de la fenêtre Windows, puis modifier.

[FERMETURE AUTOMATIQUE]

Quand l'éxecution se termine, l'application se ferme au bout de 5 secondes.