namespace _4M_21_pojazd
{
    class Powiat
    {
        private string nazwa, siedziba, wojewodztwo;
        private double powierzchnia, gestosc, przyrost;
        private int ludnosc;
        private List<string> tablice = new List<string>();
        public Powiat(string nazwa, string siedziba, string wojewodztwo, double powierzchnia, double gestosc, double przyrost, int ludnosc, List<string> tablice)
        {
            this.nazwa = nazwa;
            this.siedziba = siedziba;
            this.wojewodztwo = wojewodztwo;
            this.powierzchnia = powierzchnia;
            this.gestosc = gestosc;
            this.przyrost = przyrost;
            this.ludnosc = ludnosc;
            this.tablice = tablice;
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in tablice)
            {
                s += item+ ", ";
            }
            return $"{nazwa} {siedziba} {wojewodztwo} {powierzchnia} " +
                $"{gestosc} {przyrost} {ludnosc} {s}";
        }
    }
    class Pojazd
    {
        private int id, rocznik, przebieg, cena;
        public string marka { get; private set; }
        private string model, kolor;
        public Pojazd(int id, string marka, string model, string kolor,
            int rocznik, int przebieg, int cena)
        {
            this.id = id;
            this.rocznik = rocznik;
            this.przebieg = przebieg;
            this.cena = cena;
            this.marka = marka;
            this.model = model;
            this.kolor = kolor;
        }
        public override string ToString()
        {
            return $"{id} {marka} {model} {kolor} {przebieg} {rocznik} {cena}";
        }
    }
    internal class Program
    {
        private static List<Pojazd> pojazd = new List<Pojazd>();
        private static List<Powiat> powiaty = new List<Powiat>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (TextReader plik = File.OpenText("pojazd.csv"))
            {
                string s;
                int id = 0, rocznik = 0, przebieg = 0, cena = 0;
                string marka="", model="", kolor="";
                s = plik.ReadLine();
                Console.WriteLine(s);
                while(plik.Peek()>-1)
                {
                    int p;
                    string pom;
                    s = plik.ReadLine();

                    p = s.IndexOf(";");
                    pom = s.Substring(1, p - 2);
                    id = int.Parse(pom);
                    s = s.Substring(p + 1);

                    p = s.IndexOf(";");
                    pom = s.Substring(1, p - 2);
                    marka = pom;
                    s = s.Substring(p + 1);

                    p = s.IndexOf(";");
                    pom = s.Substring(1, p - 2);
                    model = pom;
                    s = s.Substring(p + 1);

                    p = s.IndexOf(";");
                    pom = s.Substring(1, p - 2);
                    kolor = pom;
                    s = s.Substring(p + 1);

                    p = s.IndexOf(";");
                    pom = s.Substring(1, p - 2);
                    przebieg = int.Parse(pom);
                    s = s.Substring(p + 1);

                    p = s.IndexOf(";");
                    pom = s.Substring(1, p - 2);
                    rocznik = int.Parse(pom);
                    s = s.Substring(p + 1);

                    pom = s.Substring(1, s.Length - 2);
                    cena = int.Parse(pom);
                    
                    pojazd.Add(new Pojazd(id, marka, model, kolor, rocznik, przebieg, cena));
                }

            }
            Console.WriteLine("Obiekty z listy");
            foreach(  var p in pojazd )
            {
                Console.WriteLine(p);
            }
            
            Console.WriteLine("powiaty");
            using(TextReader plik = File.OpenText("powiaty.txt"))
            {
                string nazwa="", siedziba="", wojewodztwo = "";
                double powierzchnia=0, gestosc=0, przyrost=0;
                int ludnosc=0;
                
                string s = plik.ReadLine();
                Console.WriteLine(s);
                while(plik.Peek()>-1)
                {
                    string pom;
                    int p;
                    List<string> tablice = new List<string>();
                    s = plik.ReadLine();
                    p = s.IndexOf(";");
                    nazwa = s.Substring(0, p-1);
                    s =s.Substring(p+1);

                    p = s.IndexOf(";");
                    siedziba = s.Substring(0, p - 1);
                    s = s.Substring(p + 1);

                    //tablice
                    p = s.IndexOf(";");
                    pom = s.Substring(0, p - 1);
                    s = s.Substring(p + 1);
                    p=pom.IndexOf(",");
                    while (p > 0)
                    {
                        string pom1 = pom.Substring(0, p );
                        tablice.Add(pom1);
                        pom = pom.Substring(p+2);
                        p=pom.IndexOf(",");
                    }
                    pom = pom.Substring(0,pom.Length);
                    tablice.Add(pom);

                    p = s.IndexOf(";");
                    wojewodztwo = s.Substring(0, p - 1);
                    s = s.Substring(p + 1);

                    p = s.IndexOf(";");
                    powierzchnia = double.Parse(s.Substring(0, p));
                    s = s.Substring(p + 1);

                    p = s.IndexOf(";");
                    ludnosc = int.Parse(s.Substring(0, p));
                    s = s.Substring(p + 1);

                    p = s.IndexOf(";");
                    gestosc = double.Parse(s.Substring(0, p));
                    s = s.Substring(p + 1);

                    //p = s.IndexOf(";");
                    przyrost = double.Parse(s);
                    //s = s.Substring(p + 1);

                    Console.WriteLine(s);
                    powiaty.Add(new Powiat(nazwa, siedziba, wojewodztwo, powierzchnia,
                        gestosc, przyrost, ludnosc, tablice));
                }

                
            }
            Console.WriteLine("Powiaty z listy");
            foreach (var p in powiaty)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("wszystkie pojazdy z listy");
            foreach (var p in pojazd)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("tylko Fordy");
            IEnumerable<Pojazd> fordy =
                from p in pojazd
                where p.marka == "Ford"
                select p;
            foreach (var p in fordy)
            {
                Console.WriteLine(p);
            }

        }
    }
}