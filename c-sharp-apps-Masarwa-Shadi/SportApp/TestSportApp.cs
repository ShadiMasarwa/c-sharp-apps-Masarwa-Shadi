using c_sharp_apps_Masarwa_Shadi.BankApp;
using c_sharp_apps_Masarwa_Shadi.DraftApp;
using c_sharp_apps_Masarwa_Shadi.StockDemo;
using c_sharp_apps_Masarwa_Shadi.TransportationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.SportApp
{
    class TestSportApp
    {
        public static void PrintGroupsDetails(Season[] groups)
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].DisplayTable();
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\x1b[3J");


        }
        public static Season[] CreateChampionsLeagueMock()
        {
            Season[] groups = new Season[8];

            Team bayern = new Team("Bayern", "Bayern");
            Team copenhagen = new Team("Copenhagen", "Copenhagen");
            Team galastray = new Team("Galastray", "Galastray");
            Team manUnited = new Team("Man United", "Manchester");
            Team[] teams1 = { bayern, copenhagen, galastray, manUnited };
            Season groupA = new Season(2024, "soccer", "Champions - Group A", teams1);
            groups[0] = groupA;

            Team arsenal = new Team("Arsenal", "London");
            Team psv = new Team("psv", "eindhoven");
            Team lens = new Team("Lens", "Lens");
            Team sevilla = new Team("Sevilla", "Sevilla");
            Team[] teams2 = { arsenal, psv, lens, sevilla };
            Season groupB = new Season(2024, "soccer", "Champions - Group B", teams2);
            groups[1] = groupB;

            Team realMadrid = new Team("Real Madrid", "madrid");
            Team napoli = new Team("Napoli", "Napoli");
            Team braja = new Team("Braja", "Braja");
            Team unionBerlin = new Team("Union Berlin", "Berlin");
            Team[] teams3 = { realMadrid, napoli, braja, unionBerlin };
            Season groupC = new Season(2024, "soccer", "Champions - Group C", teams3);
            groups[2] = groupC;

            Team realSociedad = new Team("Real Sociedad", "Sebastián");
            Team inter = new Team("Inter", "Milan");
            Team benfica = new Team("benfica", "lisbon");
            Team sazlburg = new Team("salzburg", "salzburg");
            Team[] teams4 = { realSociedad, inter, benfica, sazlburg };
            Season groupD = new Season(2024, "soccer", "Champions - Group D", teams4);
            groups[3] = groupD;

            Team atleteco = new Team("Atletico Madrid", "Madrid");
            Team lazio = new Team("Lazio", "Roma");
            Team feyenoord = new Team("Feyenoord", "Rotterdam");
            Team celtic = new Team("Celtic", "Glasgow");
            Team[] teams5 = { atleteco, lazio, feyenoord, celtic };
            Season groupE = new Season(2024, "soccer", "Champions - Group E", teams5);
            groups[4] = groupE;

            Team dortmund = new Team("Dortmund ", "Dortmund");
            Team psg = new Team("PSG ", "Paris");
            Team aCMilan = new Team("AC Milan", "Milan");
            Team newCastle = new Team("NewCastle ", "United Kingdom");
            Team[] teams6 = { dortmund, psg, aCMilan, newCastle };
            Season groupF = new Season(2024, "soccer", "Champions - Group F", teams6);
            groups[5] = groupF;

            Team manchesterCity = new Team("Manchester City ", "Manchester");
            Team rbLeipzig = new Team("RB Leipzig", "leipzig");
            Team youngBoys = new Team("Young Boys", "Bern");
            Team crvana = new Team("Crvena zvezda", "Belgrad");
            Team[] teams7 = { manchesterCity, rbLeipzig, youngBoys, crvana };
            Season groupG = new Season(2024, "soccer", "Champions - Group G", teams7);
            groups[6] = groupG;

            Team barcelona = new Team("Barcelona", "Barcelona");
            Team porto = new Team("Porto", "Porto");
            Team shakhtarDonetsk = new Team("Shakhtar Donetsk", "Donetsk");
            Team antwerpFc = new Team("AntwerpFc", "Antwerp");
            Team[] teams8 = { barcelona, porto, shakhtarDonetsk, antwerpFc };
            Season groupH = new Season(2024, "soccer", "Champions - Group H", teams8);
            groups[7] = groupH;


            return groups;



        }
    }
}
