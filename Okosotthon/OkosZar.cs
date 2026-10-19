using System;

namespace Okosotthon
{
    public class OkosZar : OkosEszkoz
    {
        private string pinKod;

        public bool ZartE { get; private set; }

        public OkosZar(string azonosito, string nev, string pinKod)
            : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.ZartE = true;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == null)
            {
                return;
            }

            if (parancs.StartsWith("NYITAS:"))
            {
                string megadottPin = parancs.Substring("NYITAS:".Length);

                if (megadottPin == this.pinKod)
                {
                    this.ZartE = false;
                    this.UtolsoFrissites = DateTime.Now;
                }
            }
            else if (parancs == "ZARAS")
            {
                this.ZartE = true;
                this.UtolsoFrissites = DateTime.Now;
            }
        }

        public override string AllapotJelentes()
        {
            if (this.ZartE)
            {
                return $"{this.Nev}: ZÁRVA";
            }
            return $"{this.Nev}: NYITVA";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.pinKod = "0000";
            this.ZartE = true;
        }
    }
}