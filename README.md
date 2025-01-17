# ECF2

# MLAgency

Application ASP.NET Core MVC pour gérer des événements et leurs participants, avec des statistiques globales enregistrées dans une base NoSQL (MongoDB).

# Table des matières
1. Aperçu du projet
2. Technologies utilisées
3. Prérequis
4. Installation et configuration
5. Fonctionnalités
6. Structure du projet

................................................................................................
# Aperçu du projet
MLAgency est une application web basée sur ASP.NET Core MVC qui permet :

- La gestion des événements (création, modification, suppression, liste).
- La gestion des participants (ajout, modification, liste par événement).
- L’affichage des statistiques globales, avec des données sauvegardées dans MongoDB.

Cette application est conçue pour être extensible et suit une architecture basée sur les principes de séparation des responsabilités.

..................................................................................................
# Technologies utilisées
- Framework principal : ASP.NET Core MVC (C#).
- Base de données relationnelle : SQL Server via Entity Framework Core.
- Base de données NoSQL : MongoDB pour les statistiques.
- Client-side : HTML, CSS, Bootstrap, et Chart.js pour les graphiques.
- Outils de développement : Visual Studio 2022, .NET CLI, et Postman (pour tester l'API).

...................................................................................................
# Prérequis
1. SDK .NET : Version 6.0 ou plus récente. 
Téléchargez et installez depuis dotnet.microsoft.com.

2. Base de données SQL : Installez SQL Server ou utilisez SQL Server LocalDB.

3. Base de données NoSQL : Installez MongoDB Community Edition (mongodb.com).

4. Outil de gestion des dépendances : NuGet intégré dans Visual Studio.

....................................................................................................
# Installation et configuration
- Étape 1 : Cloner le dépôt

    Clonez ce projet depuis le dépôt Git :
    
            bash :
            git clone https://github.com/Carelle2i/ECF2  
            cd MLAgency  

  - Étape 2 : Configuration de la base de données

    1. Mettez à jour la chaîne de connexion SQL Server dans appsettings.json :
    json 
  
           bash : "ConnectionStrings": {  
           "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EventManagerDb;Trusted_Connection=True;"  
           }  

    b. Configurez MongoDB dans appsettings.json :

           bash :
           "MongoDb": {  
           "ConnectionString": "mongodb://localhost:27017",  
           "DatabaseName": "EventManagerStats"  
           }  
    - Étape 3 : Appliquer les migrations et créer la base de données
    
    Générez les tables dans la base de données SQL Server :
    
            bash :
            dotnet ef migrations add InitialCreate  
            dotnet ef database update  
    - Étape 4 : Lancer l’application
Exécutez l’application en mode développement :
    

            bash :
            Copier le code
            dotnet run  
            L’application sera disponible sur http://localhost:5000 (ou un autre port configuré).

.....................................................................................................
# Fonctionnalités

- Événements
  1. Liste des événements (vue principale).
  
  2. Ajouter un événement.
  
  3. Modifier et supprimer un événement.
  

- Participants
  1. Ajouter un participant à un événement.
  2. Voir tous les participants d’un événement spécifique.
  

  - Statistiques
  1. Nombre total d’inscriptions par événement, affiché sous forme de graphique.
  Structure du projet
  

              bash :
              MLAgency/  
              │  
              ├── Controllers/       # Contrôleurs MVC (EventController, ParticipantController)  
              ├── Models/            # Modèles de données (Event, Participant, Statistic)  
              ├── Data/              # Classes de contexte (AppDbContext pour SQL, MongoDbContext)  
              ├── Services/          # Services métiers (EventService, ParticipantService)  
              ├── Views/             # Fichiers Razor pour les interfaces utilisateur  
              │   ├── Event/         # Vues pour les événements  
              │   ├── Participant/   # Vues pour les participants  
              ├── wwwroot/           # Contenus statiques (CSS, JS, images)  
              ├── appsettings.json   # Configuration (SQL Server, MongoDB)  
              └── Program.cs         # Configuration principale de l'application  
