using System;
using System.Globalization;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        public double JelenlegiHomerseklet { get; private set; }
        public double CelHomerseklet { get; private set; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
            : base(azonosito, nev)
        {
            this.JelenlegiHomerseklet = 21.0;
            this.CelHomerseklet = celHomerseklet;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            string elotag = "BEALLIT_HOMERSEKLET:";

            if (parancs != null && parancs.StartsWith(elotag))
            {
                string ertek = parancs.Substring(elotag.Length).Replace(',', '.');

                if (double.TryParse(ertek, NumberStyles.Float, CultureInfo.InvariantCulture, out double ujHomerseklet))
                {
                    this.CelHomerseklet = ujHomerseklet;
                    this.UtolsoFrissites = DateTime.Now;
                }
            }
        }

        public override string AllapotJelentes()
        {
            return $"{this.Nev}: jelenlegi hőmérséklet {this.JelenlegiHomerseklet} °C, célhőmérséklet {this.CelHomerseklet} °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 && this.CelHomerseklet <= 35.0;
        }
    }
}