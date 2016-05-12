# Goal

The goal is to develop the first features of a strange game.

To help you, 

Pour vous aider, des tests issus de sc�narios construits en Behaviour Driven Developement vous sont fournis.
L'exercice a pour but de montrer la relation entre BDD et TDD : pour pouvoir �crite du code de production, il vous faut un test unitaire en �chec pour d�finir le comportement attendu !

# Pr�requis

-	Connaitre TDD
- 	Avoir install� l'extension Specflow pour Visual Studio
- 	Une connaissance de Web API est un plus 

# L'histoire

Votre Product Owner vient vous voir de bon matin : visiblement, la soir�e a �t� brumeuse mais cr�atrice ! Il a plein d'id�es pour le nouveau jeu que vous �tes en train de d�velopper.

Il vous sort le coin de nappe sur lequel il a not� tout �a et s'enfuit prendre un caf�. Vous parvenez � d�chiffrer :


	Le but est de r�aliser un rituel avant son �ch�ance
	Un rituel est compos� d�actions

	Une action met un nombre de jours � �tre r�alis�e

	- Un villageois fait une chose par jour
	- Accomplir une action du rituel
	- Travailler pour gagner de l�argent
	- Acqu�rir une comp�tence
	
	Une fois qu�un villageois travaille sur une action, il doit la terminer avant de passer � autre chose
	
	Une action bien r�alis�e am�ne un point de ferveur
	
	Certaines actions ne peuvent �tre r�alis�es qu�avec la comp�tence n�cessaire
	- Construire un temple -> architecture
	- Invoquer un rongeur d�moniaque -> Magie Noire 
	
	Les villageois peuvent d�penser de l�argent pour acqu�rir une comp�tence ou des objets
	
	A la fin de la journ�e, le Crocto mange le d�veloppeur ayant le moins de point de ferveur
	
	La partie se termine s'il n�y a plus de villageois ou si le rituel est accompli ;o)


Pas tr�s clair tout �a... heureusement, l'�quipe a mis en place la pratique du Behaviour Driven Development. Ca consiste a avoir une discussion concentr&e sur des exemples avec les diff�rents acteurs du projet afin de clarifier les choses.

L'�quipe a trouv� bien des avantages dans cette pratique :

-	on evite les malentendus
- 	les exemples bien concrets permettent de mieux se repr�senter les diff�rents cas... et d'en trouver de nouveaux !
- 	il est plus facile de rep�rer le scope creep, une fonctionnalit� qui s'�tale comme un vieux camembert parce qu'on ne sait pas ce qu'on veut faire au d�part
- 	bonus : on a des donn�es concr�tes... qu'on peut transformer en tests !

Accompagn� de votre coll�gue testeur, vous avez donc captur� votre Product Owner pr�s de la cafeti�re, et vous vous �tes mis d'accord sur les premi�res fonctionnalit�s � impl�menter.

Gr�ce � BDD, vous avez �cart� les malentendus et cadr� les r�gles... il est maintenant temps de coder !


# C'est parti !

Les exemples discut�s avec le Product Owner ont �t� formalis�s avec le langage Gherkin puisque vous avez d�cid� d'utiliser Specflow (Cucumber pour .NET !)
Votre m�thodologie consiste � faire passer les tests Specflow au vert... sachant que tout code de production �crit doit l'�tre en TDD !
Vous avez d�but� l'impl�mentation, il faut maintenant poursuivre.

Clonez la repository et faites passer les diff�rents tests. Ouvrez le fichier feature "Action" dans le projet Specs et regardez on vous en �tes !  

