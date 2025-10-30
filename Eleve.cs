using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    public class Eleve
    {
        public string prenom {  get; set; }
        public string nom { get; set; }
        List<Note> notes { get; set; }

        public int nbreMatieres { get; set; }

        //constructeur d'élève
        public Eleve(string nomEleve, string prenomEleve) 
        { 
           this.prenom = prenomEleve;
           this.nom = nomEleve;
           this.notes = new List<Note>();
           this.nbreMatieres = 0;
        }

        //calcule la moyenne générale en fonction du nbre de matières et de la moyenne par matière, si l'élève a des matières attribuées
        public float moyenneGeneral()
        {
            float moyenneGeneralEleve = 0;


            if (this.nbreMatieres > 0)
            {
                for (int i = 0; i < this.nbreMatieres; i++)
                {
                    moyenneGeneralEleve += this.moyenneMatiere(i);

                }
                moyenneGeneralEleve /= this.nbreMatieres;
            }
            else
            {
                Console.WriteLine("L'élève " + this.prenom + " " + this.nom + " n'a pas de matières attribuées");
            }
            return MathF.Truncate(moyenneGeneralEleve * 100) / 100;
        }

        //calcule la moyenne par matière si le numero de matière correspond à celui des notes et en fonction du nombre de notes concernées
        public float moyenneMatiere(int numMatiere)
        {
            float cumulMatiereEleve = 0;
            int nbreNotes = 0;
            float moyenneMatiereEleve = 0; 

            foreach (Note note in this.notes)
            {
                if (numMatiere == note.matiere)
                {
                    cumulMatiereEleve += note.note;
                    nbreNotes++;
                }
                
                
            }

            if (nbreNotes > 0)
            {
                moyenneMatiereEleve = cumulMatiereEleve / nbreNotes;

            }
            else
            {
                Console.WriteLine("L'élève " + this.prenom + " " + this.nom + " n'a pas de notes pour la matière");
            }

            return MathF.Truncate(moyenneMatiereEleve*100)/100;
        }

        //ajoute la note reçue à la liste des notes de l'élève si celle si n'est pas nulle et que l'élève en a - de 200
        internal void ajouterNote(Note note)
        {
            if (note == null)
            {
                Console.WriteLine("La note transmise a une valeur nulle");
            }

            else if (this.notes.Count < 200)
            {
                this.notes.Add(note);
            }
            else
            {
                Console.WriteLine("Nombre maximum de notes atteint pour " + this.prenom + " " + this.nom);
            }

        }
    }
}
