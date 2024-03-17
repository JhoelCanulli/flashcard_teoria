using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcard_colloquio.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Menu
    {
        private List<Domanda> domande;
        private double punteggio;
        private Risposte risposte;

        public Menu()
        {
            domande = new List<Domanda>
        {
            new Domanda(1, "\nCos'è l'OOP e quali sono i suoi principi fondamentali?", "OOP"),
            new Domanda(2, "\nQuali sono le differenze tra l'OOP e la programmazione procedurale?", "OOP"),
            new Domanda(3, "\nCos'è una classe in OOP e quali sono i suoi componenti?", "OOP"),
            new Domanda(4, "\nQual è la differenza tra una classe ed un oggetto?", "OOP"),
            new Domanda(5, "\nQual è il concetto di incapsulamento in OOP?", "OOP"),
            new Domanda(6, "\nCos'è l'ereditarietà in OOP e qual è il suo scopo?", "OOP"),
            new Domanda(7, "\nCos'è il polimorfismo in OOP e qual è il suo vantaggio?", "OOP"),
            new Domanda(8, "\nCos'è un metodo statico in OOP e qual è la sua differenza rispetto a un metodo non statico?", "OOP"),
            new Domanda(9, "\nQual è la differenza tra composizione ed ereditarietà in OOP?", "OOP"),
            new Domanda(10, "\nCos'è il binding statico e il binding dinamico in OOP?", "OOP"),
            new Domanda(11, "\nCos'è il garbage collection e qual è il suo ruolo nella gestione della memoria?", "OOP"),
            new Domanda(12, "\nQuali sono i principali vantaggi e svantaggi dell'OOP?", "OOP"),
            new Domanda(13, "\nQual è la differenza tra un linguaggio di programmazione orientato agli oggetti e uno che non lo è?", "OOP"),
            new Domanda(14, "\nQuali sono alcuni esempi di linguaggi di programmazione orientati agli oggetti?", "OOP"),
            new Domanda(15, "\nQual è il ruolo delle interfacce in OOP e quando vengono utilizzate?", "OOP"),
            new Domanda(16, "\nQual è il concetto di astrazione in OOP e perché è importante?", "OOP"),
            new Domanda(17, "\nCome gestisce l'OOP il concetto di ereditarietà multipla?", "OOP"),
            new Domanda(18, "\nQual è la differenza tra una classe astratta e un'interfaccia?", "OOP"),
            new Domanda(19, "\nCos'è il principio di sostituzione di Liskov e perché è importante in OOP?", "OOP"),
            new Domanda(20, "\nCos'è un'eccezione in programmazione e come gestisce l'OOP le eccezioni?", "OOP"),
            new Domanda(21, "\nDifferenza tra un'istanza di una classe ed una variabile locale", "OOP"),
            new Domanda(22, "\nConcetto di eccezione in OOP e come gestirla", "OOP"),
            new Domanda(23, "\nUtilizzo e potenziali problematiche dell'ereditarietà multipla in OOP", "OOP"),
            new Domanda(24, "\nUtilizzo della parola chiave \"base\" in OOP", "OOP"),
            new Domanda(25, "\nUtilizzo della parola chiave \"this\" in OOP", "OOP"),
            new Domanda(26, "\nConcetto di binding in OOP e i suoi tipi", "OOP"),
            new Domanda(27, "\nConcetto di garbage collection in OOP e il suo funzionamento", "OOP"),

        };
            punteggio = 0;
            risposte = new Risposte();

        }

        public void MostraMenu()
        {
            bool q = false;
            do
            {
                Console.WriteLine("Scegli il genere delle domande:");
                Console.WriteLine("1. Database [ work in progress ]");
                Console.WriteLine("2. OOP");
                Console.WriteLine("r. Tutte Random");
                Console.WriteLine("q. Esci dal programma");
                Console.Write("> ");
                string? scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        AvviaQuiz("Database [ work in progress ]");
                        break;
                    case "2":
                        AvviaQuiz("OOP");
                        break;
                    case "r":
                        AvviaQuiz(null); // null per indicare tutte le domande in modo random
                        break;
                    case "R":
                        AvviaQuiz(null); // null per indicare tutte le domande in modo random
                        break;
                    case "q":
                        q = true;
                        break;
                    case "Q":
                        q = true;
                        break;
                    default:
                        Console.WriteLine("\nScelta non valida.");
                        break;
                }
            } while (!q);
            
            Console.WriteLine($"\npunteggio finale : {punteggio}");
        }

        private void AvviaQuiz(string? genere)
        {
            List<Domanda> domandeFiltrate;
            bool carattereCorretto;

            if (string.IsNullOrEmpty(genere))
            {
                // genere non scelto -> tutte le domande di tutti i generi in modo randomico
                domandeFiltrate = domande.OrderBy(x => Guid.NewGuid()).ToList();
            }
            else
            {
                // genere scelto
                domandeFiltrate = domande.Where(d => d.Genere == genere).ToList();
            }

            foreach (Domanda domanda in domandeFiltrate)
            {
                Console.WriteLine(domanda.Testo);
                Console.WriteLine("\n[ Digita qualsiasi tasto per visualizzare la risposta ]\n");
                Console.ReadKey();

                carattereCorretto = false;
                Console.WriteLine($"Risposta : {risposte.OttieniRisposta(domanda.Id)}");
                
            while (!carattereCorretto)
                {
                    Console.Write("\nHai risposto correttamente? (s/n):\n> ");
                    string? risposta = Console.ReadLine().Trim().ToLower();
                    Console.WriteLine("");

                    if (risposta == "s") {
                        punteggio += 1;
                        carattereCorretto = true;
                    }
                    else if (risposta == "n") {
                        punteggio -= 0.5;
                        carattereCorretto = true;
                    }
                    else
                    {
                        Console.WriteLine("\nerrore : carattere non definito!");
                    }
                }
                
            }
        }
    }

}
