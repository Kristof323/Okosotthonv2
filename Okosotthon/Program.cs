using System;

namespace Okosotthon
{
    public class Program
    {
        static void Main(string[] args)
        {
            OkosotthonKozpont kozpont = new OkosotthonKozpont();

            Termosztat termosztat = new Termosztat("TH-01", "Nappali Termosztát", 22.0);
            OkosZar zar = new OkosZar("LK-01", "Bejárati Zár", "1234");

            kozpont.EszkozHozzaadasa(termosztat);
            kozpont.EszkozHozzaadasa(zar);

            Console.WriteLine("Sikeres diagnosztika csatlakozás előtt: " + kozpont.RendszerDiagnosztikaFuttatasa());

            kozpont.OsszesCsatlakoztatasa();
            Console.WriteLine("Sikeres diagnosztika csatlakozás után: " + kozpont.RendszerDiagnosztikaFuttatasa());

            termosztat.ParancsVegrehajtasa("BEALLIT_HOMERSEKLET:24.5");
            Console.WriteLine(termosztat.AllapotJelentes());

            zar.ParancsVegrehajtasa("NYITAS:1234");
            Console.WriteLine(zar.AllapotJelentes());

            zar.ParancsVegrehajtasa("ZARAS");
            Console.WriteLine(zar.AllapotJelentes());
        }
    }
}