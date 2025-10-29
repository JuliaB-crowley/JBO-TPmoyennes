using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    public class Classe
    {
        public string nomClasse { get; set; }
        
        //public Dictionary<int, string> matieres = new Dictionary<int, string>();
        public List<Eleve> eleves { get; set; }
        public List<string> matieres { get; set; }
        public Classe(string nom)
        {
            this.nomClasse = nom;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }

        public void ajouterEleve(string prenom, string nom)
        {
            if (this.eleves.Count < 30)
            {
                Eleve eleve = new Eleve(nom, prenom);
                eleves.Add(eleve);
            }
            else
            {
                Console.WriteLine("Impossible de rajouter plus d'élèves dans la classe " + this.nomClasse);
            }
        }

        public void ajouterMatiere(string numMatiere)
        {
            if (this.matieres.Count < 10)
            {
                matieres.Add(numMatiere);
                foreach (Eleve eleve in this.eleves)
                {
                    eleve.nbreMatieres++;
                }
            }
            else
            {
                Console.WriteLine("Impossible de rajouter plus de matières dans la classe " + this.nomClasse);
            }
        }

        public float moyenneMatiere(int numMatiere)
        {
            float moyenneMatiereClasse = 0;
            int nbreEleveClasse = this.eleves.Count;

            for (int i = 0; i < nbreEleveClasse; i++)
            {
                moyenneMatiereClasse += this.eleves[i].moyenneMatiere(numMatiere);
            }
            if (nbreEleveClasse > 0)
            {
                moyenneMatiereClasse /= nbreEleveClasse;
            }
            else
            {
                Console.WriteLine("Il n'y a pas d'élève dans la classe " + this.nomClasse);
            }

            return MathF.Truncate(moyenneMatiereClasse * 100) / 100;
        }

        public float moyenneGeneral()
        {
            float moyenneGeneralClasse = 0;
            int nbreMatiereClasse = this.matieres.Count;

            for (int i = 0;i < nbreMatiereClasse; i++)
            {
                moyenneGeneralClasse += this.moyenneMatiere(i);
            }
            if (nbreMatiereClasse > 0)
            {
                moyenneGeneralClasse /= nbreMatiereClasse;
            }
            else
            {
                Console.WriteLine("Il n'y a pas de matières enseignées dans la classe " + this.nomClasse);
            }
            return MathF.Truncate(moyenneGeneralClasse * 100) / 100;
        }

    }
}
