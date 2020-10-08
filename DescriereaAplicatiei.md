# ServerClientApp
Server - .Net 3.1 / Client - Vue.js / DataBase - SqlServer
Descrierea aplicatiei:
  Aplicația urmărește să reducă pierderea de marfă unui depozit de marmură și granit, gestionarea comenziilor primite și automatizarea procesului de distribuire a plăciilor din stoc pentru tăiere. În momentul de față există pe piață aplicații pentru gestionarea mărfuriilor dar aceasta se bazează strict pe nevoile unui astfel de depozit oferind următoarele funcționalități:
  •	Introducerea ușoară a unei comenzi
  •	Un algoritm pentru gestionarea tăierilor
  •	Reducerea tăierilor inutile: programul urmărește să facă cât mai puține tăieri alegând „placa perfectă” din stoc pentru fiecare placă din comandă dar și alegând mereu plăcile care au lungimea și lățimea cea mai mică. 
  
De exemplu:
	Numim pierdere toate plăcile din stoc care au lungimea < 10 cm sau lățimea < 10 cm.
	Presupunem că avem ca și comandă urmatoarele plăci:
    •	Placa nr.1;  Lungimea = 1.20 m; Lățimea = 0.40 m;
    •	Placa nr.2;  Lungimea = 1.20 m; Lățimea = 0.30 m;
    •	Placa nr.3;  Lungimea = 0.60 m; Lățimea = 0.50 m;
    •	Placa nr.4;  Lungimea = 0.60 m; Lățimea = 0.50 m;
  Și pentru stoc următoarele plăci:
    •	Placa nr.1;  Lungimea = 1.20 m; Lățimea = 0.70m;
    •	Placa nr.2;  Lungimea = 1.20 m; Lățimea = 0.50 m;
    •	Placa nr.3;  Lungimea = 1.20 m; Lățimea = 0.40 m;
    •	Placa nr.4;  Lungimea = 1.20 m; Lățimea = 1.30 m;
    •	Placa nr.5;  Lungimea = 1.20 m; Lățimea = 0.43 m;
    •	Placa nr.6;  Lungimea = 0.60 m; Lățimea = 0.51 m;
    •	Placa nr.7;  Lungimea = 0.60 m; Lățimea = 0.51 m;
   Observăm faptul că toate plăcile din comandă se pot obține din placa nr.4 din stoc dar și din plăcile nr. 1 respectiv nr. 2 (fără pierdere). Progamul urmărește să folosească plăcile cele mai mici din stoc astfel va alege a doua variantă. Prin condițiile dezvoltate în algoritm, programul urmărește să folosească plăcile cele mai mici din comandă care se apropie sau sunt egale cu plăcile din comandă, evitând până în ultimul moment folosirea plăciilor din care ar rezulta pierdere (plăciile din stoc cu pierdere: 5,6,7).

Structura aplicației
	Aplicația are la bază structura de client-server. 
  Clientul este un client WEB deoarece este cea mai ușoară modalitate prin care orice client poate ajunge la aplicație. Clientul WEB prezintă o interfață prietenoasă și nu necesită să fie descărcat și instalat. În zilele noastră, aproximativ toată lumea are acces la un calculator conectat la internet.
  Serverul este responsabil cu administrarea accesului la baze de date. Am ales să fie reprezentat în .Net deoarece este un framework în care poți aduce modificări cu ușurință.
Am ales să folosesc o bază de date pentru ușurița gestionării datelor dar și pentru securitatea oferită.

