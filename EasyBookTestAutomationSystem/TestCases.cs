using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBookTestAutomationSystem
{
    class TestCases
    {
        public string testCase(string server, string site, string product, string tripType, string paymentType)
        {
            string testCaseID;

            //--------------------------------------BUS----------------------------------------------------------------//
            /*---------------------------------------------------------------------------------------------------------//
                 Bus
                     Test
                            S1
            //---------------------------------------------------------------------------------------------------------*/

            //server 1 - test - bus - one way - paypal myr
            if (server == "s1" && site == "test" && product == "bus" && tripType == "oneway" && paymentType == "myr")
            {
                //Console.WriteLine("2.0.1");
                return testCaseID = "S1-Test-Bus-oneWay-myr";
            }

            //server 1 - test - bus - one way - paypal sgd
            else if (server == "s1" && site == "test" && product == "bus" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Test-Bus-oneWay-sgd";
            }

            //server 1 - test - bus - return - paypal myr
            else if (server == "s1" && site == "test" && product == "bus" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Test-Bus-return-myr";
            }

            //server 1 - test - bus - return - paypal sgd
            else if (server == "s1" && site == "test" && product == "bus" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Test-Bus-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                 Bus
                     Test
                            S2
             //---------------------------------------------------------------------------------------------------------*/

            //server 2 - test - bus - one way - paypal myr
            else if (server == "s2" && site == "test" && product == "bus" && tripType == "oneway" && paymentType == "myr")
            {
                //Console.WriteLine("2.0.2");
                return testCaseID = "S2-Test-Bus-oneWay-myr";
            }

            //server 2 - test - bus - one way - paypal sgd
            else if (server == "s2" && site == "test" && product == "bus" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Test-Bus-oneWay-sgd";
            }

            //server 2 - test - bus - return - paypal myr
            else if (server == "s2" && site == "test" && product == "bus" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Test-Bus-return-myr";
            }

            //server 2 - test - bus - return - paypal sgd
            else if (server == "s2" && site == "test" && product == "bus" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Test-Bus-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                Bus
                    Live
                         S1
           //---------------------------------------------------------------------------------------------------------*/

            //server 1 - live - bus - one way - paypal myr
            else if (server == "s1" && site == "live" && product == "bus" && tripType == "oneway" && paymentType == "myr")
            {
                //Console.WriteLine("2.0.3");
                return testCaseID = "S1-Live-Bus-oneWay-myr";
            }

            //server 1 - live - bus - one way - paypal sgd
            else if (server == "s1" && site == "live" && product == "bus" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Live-Bus-oneWay-sgd";
            }

            //server 1 - live - bus - return - paypal myr
            else if (server == "s1" && site == "live" && product == "bus" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Live-Bus-return-myr";
            }

            //server 1 - live - bus - return - paypal sgd
            else if (server == "s1" && site == "live" && product == "bus" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Live-Bus-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
               Bus
                   Live
                        S2
          //---------------------------------------------------------------------------------------------------------*/

            //server 2 - live - bus - one way - paypal myr
            else if (server == "s2" && site == "live" && product == "bus" && tripType == "oneway" && paymentType == "myr")
            {
                //Console.WriteLine("2.0.4");
                return testCaseID = "S2-Live-Bus-oneWay-myr";
            }

            //server 2 - live - bus - one way - paypal sgd
            else if (server == "s2" && site == "live" && product == "bus" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Live-Bus-oneWay-sgd";
            }

            //server 2 - live - bus - return - paypal myr
            else if (server == "s2" && site == "live" && product == "bus" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Live-Bus-return-myr";
            }

            //server 2 - live - bus - return - paypal sgd
            else if (server == "s2" && site == "live" && product == "bus" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Live-Bus-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
               Bus
                   Backend
                        S1
          //---------------------------------------------------------------------------------------------------------*/

            //server 1 - Backend - bus - one way - paypal myr
            else if (server == "s1" && site == "bq" && product == "bus" && tripType == "oneway" && paymentType == "myr")
            {
                //Console.WriteLine("2.0.3");
                return testCaseID = "S1-Backend-Bus-oneWay-myr";
            }

            //server 1 - Backend - bus - one way - paypal sgd
            else if (server == "s1" && site == "bq" && product == "bus" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Backend-Bus-oneWay-sgd";
            }

            //server 1 - Backend - bus - return - paypal myr
            else if (server == "s1" && site == "bq" && product == "bus" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Backend-Bus-return-myr";
            }

            //server 1 - Backend - bus - return - paypal sgd
            else if (server == "s1" && site == "bq" && product == "bus" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Backend-Bus-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
               Bus
                   Backend
                        S2
          //---------------------------------------------------------------------------------------------------------*/

            //server 2 - backend - bus - one way - paypal myr
            else if (server == "s2" && site == "bq" && product == "bus" && tripType == "oneway" && paymentType == "myr")
            {
                //Console.WriteLine("2.0.4");
                return testCaseID = "S2-Backend-Bus-oneWay-myr";
            }

            //server 2 - backend - bus - one way - paypal sgd
            else if (server == "s2" && site == "bq" && product == "bus" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Backend-Bus-oneWay-sgd";
            }

            //server 2 - backend - bus - return - paypal myr
            else if (server == "s2" && site == "bq" && product == "bus" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Backend-Bus-return-myr";
            }

            //server 2 - backend - bus - return - paypal sgd
            else if (server == "s2" && site == "bq" && product == "bus" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Backend-Bus-return-sgd";
            }



            //--------------------------------------CAR----------------------------------------------------------------//
            /*---------------------------------------------------------------------------------------------------------//
                 Car
                     Test
                            S1
            //---------------------------------------------------------------------------------------------------------*/

            //server 1 - test - car - one way - paypal myr
            if (server == "s1" && site == "test" && product == "car" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Test-Car-oneWay-myr";
            }

            //server 1 - test - car - one way - paypal sgd
            else if (server == "s1" && site == "test" && product == "car" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Test-Car-oneWay-sgd";
            }

          
            /*---------------------------------------------------------------------------------------------------------//
                 Car
                     Test
                            S2
             //---------------------------------------------------------------------------------------------------------*/

            //server 2 - test - car - one way - paypal myr
            else if (server == "s2" && site == "test" && product == "car" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Test-Car-oneWay-myr";
            }

            //server 2 - test - car - one way - paypal sgd
            else if (server == "s2" && site == "test" && product == "car" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Test-Car-oneWay-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                Car
                    Live
                         S1
           //---------------------------------------------------------------------------------------------------------*/

            //server 1 - live - car - one way - paypal myr
            else if (server == "s1" && site == "live" && product == "car" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Live-Car-oneWay-myr";
            }

            //server 1 - live - car - one way - paypal sgd
            else if (server == "s1" && site == "live" && product == "car" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Live-Car-oneWay-sgd";
            }

         

            /*---------------------------------------------------------------------------------------------------------//
               Car
                   Live
                        S2
          //---------------------------------------------------------------------------------------------------------*/

            //server 2 - live - car - one way - paypal myr
            else if (server == "s2" && site == "live" && product == "car" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Live-Car-oneWay-myr";
            }

            //server 2 - live - car - one way - paypal sgd
            else if (server == "s2" && site == "live" && product == "car" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Live-Car-oneWay-sgd";
            }

            //--------------------------------------CAR----------------------------------------------------------------//
            /*---------------------------------------------------------------------------------------------------------//
                 Car
                     Backend
                            S1
            //---------------------------------------------------------------------------------------------------------*/

            //server 1 - Backend - car - one way - paypal myr
            if (server == "s1" && site == "bq" && product == "car" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Backend-Car-oneWay-myr";
            }

            //server 1 - Backend - car - one way - paypal sgd
            else if (server == "s1" && site == "bq" && product == "car" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Backend-Car-oneWay-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                 Car
                     Backend
                            S2
             //---------------------------------------------------------------------------------------------------------*/

            //server 2 - Backend - car - one way - paypal myr
            else if (server == "s2" && site == "bq" && product == "car" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Backend-Car-oneWay-myr";
            }

            //server 2 - testBackend - car - one way - paypal sgd
            else if (server == "s2" && site == "bq" && product == "car" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Backend-Car-oneWay-sgd";
            }





            //--------------------------------------FERRY----------------------------------------------------------------//
            /*---------------------------------------------------------------------------------------------------------//
                 Ferry
                     Test
                            S1
            //---------------------------------------------------------------------------------------------------------*/

            //server 1 - test - ferry - one way - paypal myr
            if (server == "s1" && site == "test" && product == "ferry" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Test-Ferry-oneWay-myr";
            }

            //server 1 - test - ferry - one way - paypal sgd
            else if (server == "s1" && site == "test" && product == "ferry" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Test-Ferry-oneWay-sgd";
            }

            //server 1 - test - ferry - return - paypal myr
            else if (server == "s1" && site == "test" && product == "ferry" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Test-Ferry-return-myr";
            }

            //server 1 - test - ferry - return - paypal sgd
            else if (server == "s1" && site == "test" && product == "ferry" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Test-Ferry-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                 Ferry
                     Test
                            S2
             //---------------------------------------------------------------------------------------------------------*/

            //server 2 - test - ferry - one way - paypal myr
            else if (server == "s2" && site == "test" && product == "ferry" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Test-Ferry-oneWay-myr";
            }

            //server 2 - test - ferry - one way - paypal sgd
            else if (server == "s2" && site == "test" && product == "ferry" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Test-Ferry-oneWay-sgd";
            }

            //server 2 - test - ferry - return - paypal myr
            else if (server == "s2" && site == "test" && product == "ferry" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Test-Ferry-return-myr";
            }

            //server 2 - test - ferry - return - paypal sgd
            else if (server == "s2" && site == "test" && product == "ferry" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Test-Ferry-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                Ferry
                    Live
                         S1
           //---------------------------------------------------------------------------------------------------------*/

            //server 1 - live - ferry - one way - paypal myr
            else if (server == "s1" && site == "live" && product == "ferry" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Live-Ferry-oneWay-myr";
            }

            //server 1 - live - ferry - one way - paypal sgd
            else if (server == "s1" && site == "live" && product == "ferry" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Live-Ferry-oneWay-sgd";
            }

            //server 1 - live - ferry - return - paypal myr
            else if (server == "s1" && site == "live" && product == "ferry" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Live-Ferry-return-myr";
            }

            //server 1 - live - ferry - return - paypal sgd
            else if (server == "s1" && site == "live" && product == "ferry" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Live-Ferry-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
               Ferry
                   Live
                        S2
          //---------------------------------------------------------------------------------------------------------*/

            //server 2 - live - ferry - one way - paypal myr
            else if (server == "s2" && site == "live" && product == "ferry" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Live-Ferry-oneWay-myr";
            }

            //server 2 - live - ferry - one way - paypal sgd
            else if (server == "s2" && site == "live" && product == "ferry" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Live-Ferry-oneWay-sgd";
            }

            //server 2 - live - ferry - return - paypal myr
            else if (server == "s2" && site == "live" && product == "ferry" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Live-Ferry-return-myr";
            }

            //server 2 - live - ferry - return - paypal sgd
            else if (server == "s2" && site == "live" && product == "ferry" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Live-Ferry-return-sgd";
            }


            //--------------------------------------FERRY----------------------------------------------------------------//
            /*---------------------------------------------------------------------------------------------------------//
                 Ferry
                     Backend
                            S1
            //---------------------------------------------------------------------------------------------------------*/

            //server 1 - Backend - ferry - one way - paypal myr
            if (server == "s1" && site == "bq" && product == "ferry" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Backend-Ferry-oneWay-myr";
            }

            //server 1 - Backend - ferry - one way - paypal sgd
            else if (server == "s1" && site == "bq" && product == "ferry" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Backend-Ferry-oneWay-sgd";
            }

            //server 1 - Backend - ferry - return - paypal myr
            else if (server == "s1" && site == "bq" && product == "ferry" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Backend-Ferry-return-myr";
            }

            //server 1 - Backend - ferry - return - paypal sgd
            else if (server == "s1" && site == "bq" && product == "ferry" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Backend-Ferry-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                 Ferry
                     Backend
                            S2
             //---------------------------------------------------------------------------------------------------------*/

            //server 2 - Backend - ferry - one way - paypal myr
            else if (server == "s2" && site == "bq" && product == "ferry" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Backend-Ferry-oneWay-myr";
            }

            //server 2 - Backend - ferry - one way - paypal sgd
            else if (server == "s2" && site == "bq" && product == "ferry" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Backend-Ferry-oneWay-sgd";
            }

            //server 2 - Backend - ferry - return - paypal myr
            else if (server == "s2" && site == "bq" && product == "ferry" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Backend-Ferry-return-myr";
            }

            //server 2 - Backend - ferry - return - paypal sgd
            else if (server == "s2" && site == "bq" && product == "ferry" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Backend-Ferry-return-sgd";
            }



            //--------------------------------------TRAIN----------------------------------------------------------------//
            /*---------------------------------------------------------------------------------------------------------//
                 Train
                     Test
                            S1
            //---------------------------------------------------------------------------------------------------------*/

            //server 1 - test - train - one way - paypal myr
            if (server == "s1" && site == "test" && product == "train" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Test-Train-oneWay-myr";
            }

            //server 1 - test - train - one way - paypal sgd
            else if (server == "s1" && site == "test" && product == "train" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Test-Train-oneWay-sgd";
            }

            //server 1 - test - train - return - paypal myr
            else if (server == "s1" && site == "test" && product == "train" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Test-Train-return-myr";
            }

            //server 1 - test - train - return - paypal sgd
            else if (server == "s1" && site == "test" && product == "train" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Test-Train-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                 Train
                     Test
                            S2
             //---------------------------------------------------------------------------------------------------------*/

            //server 2 - test - train - one way - paypal myr
            else if (server == "s2" && site == "test" && product == "train" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Test-Train-oneWay-myr";
            }

            //server 2 - test - train - one way - paypal sgd
            else if (server == "s2" && site == "test" && product == "train" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Test-Train-oneWay-sgd";
            }

            //server 2 - test - train - return - paypal myr
            else if (server == "s2" && site == "test" && product == "train" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Test-Train-return-myr";
            }

            //server 2 - test - train - return - paypal sgd
            else if (server == "s2" && site == "test" && product == "train" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Test-Train-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                Train
                    Live
                         S1
           //---------------------------------------------------------------------------------------------------------*/

            //server 1 - live - train - one way - paypal myr
            else if (server == "s1" && site == "live" && product == "train" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Live-Train-oneWay-myr";
            }

            //server 1 - live - train - one way - paypal sgd
            else if (server == "s1" && site == "live" && product == "train" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Live-Train-oneWay-sgd";
            }

            //server 1 - live - train - return - paypal myr
            else if (server == "s1" && site == "live" && product == "train" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Live-Train-return-myr";
            }

            //server 1 - live - train - return - paypal sgd
            else if (server == "s1" && site == "live" && product == "train" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Live-Train-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
               Train
                   Live
                        S2
          //---------------------------------------------------------------------------------------------------------*/

            //server 2 - live - train - one way - paypal myr
            else if (server == "s2" && site == "live" && product == "train" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Live-Train-oneWay-myr";
            }

            //server 2 - live - train - one way - paypal sgd
            else if (server == "s2" && site == "live" && product == "train" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Live-Train-oneWay-sgd";
            }

            //server 2 - live - train - return - paypal myr
            else if (server == "s2" && site == "live" && product == "train" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Live-Train-return-myr";
            }

            //server 12 - live - train - return - paypal sgd
            else if (server == "s2" && site == "live" && product == "train" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Live-Train-return-sgd";
            }

            //--------------------------------------TRAIN----------------------------------------------------------------//
            /*---------------------------------------------------------------------------------------------------------//
                 Train
                     Backend
                            S1
            //---------------------------------------------------------------------------------------------------------*/

            //server 1 - Backend - train - one way - paypal myr
            if (server == "s1" && site == "bq" && product == "train" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S1-Backend-Train-oneWay-myr";
            }

            //server 1 - Backend - train - one way - paypal sgd
            else if (server == "s1" && site == "bq" && product == "train" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S1-Backend-Train-oneWay-sgd";
            }

            //server 1 - Backend - train - return - paypal myr
            else if (server == "s1" && site == "bq" && product == "train" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S1-Backend-Train-return-myr";
            }

            //server 1 - Backend - train - return - paypal sgd
            else if (server == "s1" && site == "bq" && product == "train" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S1-Backend-Train-return-sgd";
            }


            /*---------------------------------------------------------------------------------------------------------//
                 Train
                     Backend
                            S2
             //---------------------------------------------------------------------------------------------------------*/

            //server 2 - Backend - train - one way - paypal myr
            else if (server == "s2" && site == "bq" && product == "train" && tripType == "oneway" && paymentType == "myr")
            {
                return testCaseID = "S2-Backend-Train-oneWay-myr";
            }

            //server 2 - Backend - train - one way - paypal sgd
            else if (server == "s2" && site == "bq" && product == "train" && tripType == "oneway" && paymentType == "sgd")
            {
                return testCaseID = "S2-Backend-Train-oneWay-sgd";
            }

            //server 2 - Backend - train - return - paypal myr
            else if (server == "s2" && site == "bq" && product == "train" && tripType == "return" && paymentType == "myr")
            {
                return testCaseID = "S2-Backend-Train-return-myr";
            }

            //server 2 - Backend - train - return - paypal sgd
            else if (server == "s2" && site == "bq" && product == "train" && tripType == "return" && paymentType == "sgd")
            {
                return testCaseID = "S2-Backend-Train-return-sgd";
            }



            Console.WriteLine("Wrong input");
            return null;

        }


    }
}
