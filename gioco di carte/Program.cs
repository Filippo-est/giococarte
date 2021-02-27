using System;

namespace gioco_di_carte
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto al gioco di carte");
            Console.WriteLine();
            Console.WriteLine("Ecco le regole : tu dovrai 'creare' due carte ma prima dovrai scegliere il seme 'vincente' le regole sono come briscola ");
            Console.WriteLine(" vince il seme vincente o il seme della prima carta buttata , in caso il seme è uguale vince la carta maggiore ");
            Console.WriteLine("I valori delle carte sono quelli normali , fa eccezione l'asso che vale 14");
            Console.WriteLine();
            Console.WriteLine("Partiamo?");
            Console.ReadLine();
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Inserisci il seme vincente , inserisci i seguenti caratteri  'C' (uori) , 'Q' (uadri) , 'F' (iori) , 'P' (icche)");
            string semevince = inserisciseme();
            
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Ok , ora inserisci il seme della prima carta");
            string semet = inserisciseme();
            Console.WriteLine(); 
            Console.WriteLine("Bene , ora inserisci il numero della prima carta ricorda che i numeri sono tra 2 e 14 (estremi compresi)");
            int numerot = Convert.ToInt32(Console.ReadLine());
            Carta prima = new Carta(semet, numerot);
            while(prima.numero==0)
            { Console.WriteLine("Numero inserito errato , reinseriscilo");
              Console.WriteLine("ricorda che i numeri sono tra 2 e 14 (estremi compresi)");
              prima.numero = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(); 
            Console.WriteLine("Ok , prima carta generata correttamente");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Generiamo la seconda");
            Console.WriteLine(); Console.WriteLine();

            Console.WriteLine("Ok , ora inserisci il seme della seconda carta");
            semet = inserisciseme();
            Console.WriteLine();
            Console.WriteLine("Bene , ora inserisci il numero della seconda carta ricorda che i numeri sono tra 2 e 14 (estremi compresi)");
            numerot = Convert.ToInt32(Console.ReadLine());
            Carta seconda = new Carta(semet, numerot);
            while (seconda.numero == 0)
            {
                Console.WriteLine("Numero inserito errato , reinseriscilo");
                Console.WriteLine("ricorda che i numeri sono tra 2 e 14 (estremi compresi)");
                seconda.numero = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine("Ok , seconda carta generata correttamente");
            Console.WriteLine("Visualizzo le informazioni delle due");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("prima : ");
            Console.WriteLine(prima.visualizza());
            Console.WriteLine();
            Console.WriteLine("seconda : ");
            Console.WriteLine(seconda.visualizza());
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Calcolo il vincitore....");
            Console.ReadLine();
            if(prima.vince(seconda, semevince) == true) { Console.WriteLine("vince " + prima.visualizza()); }
            else { Console.WriteLine("vince " + seconda.visualizza()); }Console.WriteLine();
            Console.WriteLine("Pronto per il secondo round?");
            Console.ReadLine();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Ora le cose si fanno interessanti è tempo di usare la forza bruta");
            Console.WriteLine("Inserisci un numero , e che sia grande , sarà il numero di coppie di carte generate con il loro seme vincente, alla fine ti dirò il numero di volte che la prima e la seconda hanno vinto");
            int nripetizioni = Convert.ToInt32(Console.ReadLine());
            while(nripetizioni<1)
            {
                Console.WriteLine("Mi sembrano un pò poche , reinsci il numero di ripetizioni");
                nripetizioni = Convert.ToInt32(Console.ReadLine());
            }
            int i;
            int nvittorie=0;
            Random rnd = new Random();
            string[] semi = new string[]
                {"C","Q","F","P"};
            for (i=0;i<nripetizioni;i++)
            {
                semevince = semi[rnd.Next(0, 4)];
                prima.numero = rnd.Next(2, 15);
                prima.seme = semi[rnd.Next(0, 4)];
                seconda.numero = rnd.Next(2, 15);
                seconda.seme = semi[rnd.Next(0, 4)];
                if(prima.vince(seconda, semevince)==true)
                { nvittorie++;Console.WriteLine("seme vincente :"+semevince+" ----"+prima.visualizza()+" ||| "+seconda.visualizza()+"---- vince: "+ prima.visualizza()); }
                else { Console.WriteLine("seme vincente :" + semevince + " ----" + prima.visualizza() + " ||| " + seconda.visualizza() + "---- vince: " + seconda.visualizza()); }
            }
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("La prima carta ha vinto " + nvittorie + " volte");
            Console.WriteLine("La seconda carta ha vinto " + (nripetizioni - nvittorie) + " volte");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("La seconda carta ha maggiori probabilità di perdere perchè il seme della prima comanda anche se non ha il seme vincente perchè appunto è prima");
            Console.ReadLine();
        }






        static string inserisciseme()
        {
            string semeout = Console.ReadLine(); semeout=semeout.ToUpper();
            while (semeout != "C" && semeout != "Q" && semeout != "F" && semeout != "P")
            {
                Console.WriteLine("Carattere inserito inaccettabile , inserisci i seguenti caratteri  'C' (uori) , 'Q' (uadri) , 'F' (iori) , 'P' (icche)");
                
                    semeout = Console.ReadLine(); semeout.ToUpper();
            }
            return semeout;
        }
    }
    class Carta
    {
        int _numero;
        string _seme;
        public int numero
        {
            get { return _numero; }
            set {
                if (value < 2 || value > 14) { _numero = 0; }
                else { _numero = value; }
                }
        }
        public string seme
        {
            get { return _seme; }
            set { 
                    if(value!="C"&& value != "Q"&&value != "F"&&value != "P") { _seme = "error"; }
                    _seme = value;
                }
        }

        public Carta(string seed,int number)
        {
            seme = seed;
            numero = number;
        }
        public string visualizza()
        {
            string nome = "", nomes = "";
            if (numero == 11) { nome = "Jack"; }
            if (numero == 12) { nome = "Queen"; }
            if (numero == 13) { nome = "King"; }
            if (numero == 14) { nome = "Asso"; }
            if (seme == "C") { nomes = "Cuori"; }
            if (seme == "Q") { nomes = "Quadri"; }
            if (seme == "F") { nomes = "Fiori"; }
            if (seme == "P") { nomes = "Picche"; }
            if (nome == "") { return numero + " di " + nomes; }
            else return nome + " di " + nomes+"( valore : "+numero+")";
        }

        public bool vince(Carta seconda,string semev)
        {
            if(seme==semev)
            {
                if (seconda.seme != semev) { return true; }
                else
                {
                    if (numero > seconda.numero) { return true; }
                    else { return false; }
                }   
            }
            else if (seconda.seme == semev) { return false; }
            else if(seconda.seme == seme)
            {
                if (numero > seconda.numero) { return true; }
                else { return false; }
            }
            else { return true; }
            
        }//vince chi ha il seme vincente o in caso ce l'hanno uguale il maggiore o in caso è diverso e nessuno dei due semi è vincente vince a tavolino il primo
    }
    class Paziente
    {
        string nome, cognome,_colore;
        public string codicefiscale;   


        public Paziente(string nom, string cognom, string cod, string color)//creazione oggetto paziente
        {
            nome = nom; cognome = cognom; codicefiscale = cod; colore = color;
        }
        public Paziente()//creazione oggetto paziente (per comodità)
        {
            nome =""; cognome = ""; codicefiscale = ""; colore = "";
        }
        public string colore//property colore con controllo
        {

            get { return _colore; }
            set { string b = value;
                b.ToLower();
                if (b != "giallo" && b != "rosso"&&b != "bianco") { _colore="error"; }
                else { _colore = value; }
                    }
        } 
        public string visualizzadati()//outputta i dati del paziente  
        {
            return "nome: " + nome + " cognome: " + cognome + " codice fiscale: " + codicefiscale + " colore: " + colore;
        }
            
        
            
    }

    class Lista
    {
        Paziente[] paz;
        int npaz;
        public  Lista(int n)
        {
           paz=new Paziente[n];
            npaz = -1;
        }

        public void aggiungipazienti(string nom, string cognom, string cod, string color)//aggiunge un paziente nella lista e incrementa il contatore (npaz)
        {
            npaz++;
            paz[npaz] = new Paziente( nom,  cognom,  cod,  color);
        }

        public int npazienti(string color)//dato il colore outputta il numero di pazienti con quel colore nella lista
        {
            color = color.ToLower();
            if(color!="bianco"&& color != "giallo"&& color != "rosso") { return -1; }
            int i,numero=0;
            for (i=0;i<npaz+1;i++)
            {
                if (paz[i].colore == color) { numero++; }
            }
            return numero;
        }
        public string recuperapaziente()//recupera il primo paziente con la più grande priorità 
        {
            int i;

            for (i = 0; i < npaz + 1; i++)
            {
                if (paz[i].colore == "rosso") { return paz[i].codicefiscale; }
            }
            for (i = 0; i < npaz + 1; i++)
            {
                if (paz[i].colore == "giallo") { return paz[i].codicefiscale; }
            }
            return paz[1].codicefiscale;

        }
        public void salvaripristina(string option)// data una opzione salva o ripristina da file la lista 
        {
            option.ToLower();
            if(option=="salva")
            {
                Streamwriter uno = new Streamwriter();
                //.......
                uno.endofstream();
            }
            if(option=="ripristina")
            {
                Streamreader uno = new Streamreader();
                //.......
                uno.endofstream();
            }
        }

        public void eliminapaz(string codef)//elimina il paziente dato il suo codice fiscale
        {
            int i,index=-1;
            for (i = 0; i < npaz + 1; i++)
            {
                if (paz[i].codicefiscale == codef) { index=i; }
            }
            if(index!=-1)
            {
                for (i = index; i < npaz; i++)
                {
                    paz[i] = paz[i + 1];
                }
            }
            npaz--;
            

        }
        public void ordinapazienti()//ordina i pazienti in base al colore 
        {
            int i,flag=0;
            Paziente c = new Paziente();
            do
            {
                flag = 0;
                for (i = 0; i < npaz + 1; i++)

                {
                    if (paz[i].colore != "rosso")
                    {
                        if (paz[i + 1].colore == "rosso") { c = paz[i]; paz[i] = paz[i + 1]; paz[i + 1] = c; flag++; }
                        else if (paz[i].colore == "bianco")
                        {
                            if (paz[i] != paz[i + 1]) { c = paz[i]; paz[i] = paz[i + 1]; paz[i + 1] = c; flag++; }
                        }


                    }
                }
            }
            while (flag != 0);
        }



    }
}
