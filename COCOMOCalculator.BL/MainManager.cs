using System;

namespace COCOMOCalculator.BL
{
    public interface IMainManager
    {
        /* 
         * Нормально что я указал перед необходимым классом его родительский?
         * Values Calculate(int size, string type); - эта строка выдавала ошибку
        */
        MainManager.Values Calculate(int size, string type);

    }
    public class MainManager : IMainManager
    {
        public class Values
        {
            private class Coefs
            {
                private float a, b, c = 2.5f, d;

                public Coefs(string type)
                {
                    switch (type)
                    {
                        case "Common":
                            a = 2.4f;
                            b = 1.05f;
                            d = 0.38f;
                            break;
                        case "Semi-independent":
                            a = 3.0f;
                            b = 1.12f;
                            d = 0.35f;
                            break;
                        case "Built-in":
                            a = 3.6f;
                            b = 1.20f;
                            d = 0.32f;
                            break;
                        default: throw new Exception("Тип проекта должен быть указан.");
                    }
                }

                public float GetA() { return a; }
                public float GetB() { return b; }
                public float GetC() { return c; }
                public float GetD() { return d; }
            }
            private float PM;
            private float TM;

            public Values(int size, string type)
            {
                Coefs coefs = new Coefs(type);
                this.PM = (float)Math.Round((coefs.GetA() * Math.Pow(size, coefs.GetB())), 6);
                this.TM = (float)Math.Round((coefs.GetC() * Math.Pow(PM, coefs.GetD())), 6);
            }

            public float GetPM() { return this.PM; }
            public float GetTM() { return this.TM; }
        }

        public Values Calculate(int size, string type)
        {
            return new Values(size, type);
        }
    }
}
