using System;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, SIZE, PROTEIN, EXERCISE, MEAL, CALORIE, BMI
        }

        private State nCur = State.WELCOMING;
        private Order oOrder;

        private bool stateInitMessage = true;

        public Session(string sPhone)
        {
            this.oOrder = new Order();
            this.oOrder.Phone = sPhone;
        }

        public List<String> OnMessage(String sInMessage)
        {
            List<String> aMessages = new List<string>();
            string response = ResponseManager(sInMessage);
            
            switch (this.nCur)
            {
                case State.WELCOMING:

                    if (stateInitMessage) 
                    {
                        aMessages.Add("Hey there! This is Fit All Day - your all day round fitness assistant.");
                        aMessages.Add("How can I help you today?");
                        aMessages.Add("1- Suggest exercise. \n 2- Suggest meal.\n 3- Track calorie.\n 4- Calculate BMI.");
                        stateInitMessage = false;
                    }
                    else
                    {
                        aMessages.Add(response);
                    }
                    break;

                case State.SIZE:
                    this.oOrder.Size = sInMessage;
                    this.oOrder.Save();
                    aMessages.Add("What protein would you like on this  " + this.oOrder.Size + " Shawarama?");
                    this.nCur = State.PROTEIN;
                    break;
                case State.PROTEIN:
                    string sProtein = sInMessage;
                    aMessages.Add("What toppings would you like on this (1. pickles 2. Tzaki) " + this.oOrder.Size + " " + sProtein + " Shawarama?");
                    break;

                case State.EXERCISE:


                    if (stateInitMessage)
                    {
                        aMessages.Add("Great! You'd like to exercise.");
                        aMessages.Add("Which muscle group would you like to train today?");
                    }
                    else
                    {

                    }

                    break;
                
                case State.MEAL:

                    break;
                
                case State.CALORIE:
                    break;

                case State.BMI:
                    break;


            }
            aMessages.ForEach(delegate (String sMessage)
            {
                System.Diagnostics.Debug.WriteLine(sMessage);
            });
            return aMessages;
        }

        public string ResponseManager(string sInMessage)
        {
            string response = "";

            switch (nCur)
            {
                case State.WELCOMING:
                    if (stateInitMessage)
                    {
                        return response;
                    }

                    switch(sInMessage)
                    {
                        case "1":
                            this.nCur = State.EXERCISE;
                            stateInitMessage = true;
                            break;
                        case "2":
                            this.nCur = State.MEAL;
                            stateInitMessage = true;
                            break;
                        case "3":
                            this.nCur = State.CALORIE;
                            stateInitMessage = true;
                            break;
                        case "4":
                            this.nCur = State.BMI;
                            stateInitMessage = true;
                            break;
                        default:
                            response = "Incorrect response. Please try again.";

                            break;

                    }

                   
                    break;


                case State.EXERCISE:


                   
                    break;


            }

            return response;


        }

    }
}
