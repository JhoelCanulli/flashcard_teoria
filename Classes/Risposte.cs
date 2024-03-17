using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcard_colloquio.Classes
{
    using System;
    using System.IO;

    public class Risposte
    {
        public string? OttieniRisposta(int idDomanda)
        {
            string? nomeFile = $"{idDomanda}.md";
            try
            {
                string? percorsoFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Risposte", nomeFile);
                if (File.Exists(percorsoFile))
                {
                    return File.ReadAllText(percorsoFile);
                }
                else
                {
                    return "\nRisposta non disponibile.";
                }
            }
            catch (Exception ex)
            {
                return $"\nErrore durante la lettura del file: {ex.Message}";
            }
        }
    }

}
