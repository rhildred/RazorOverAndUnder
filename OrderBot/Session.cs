using System;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, EXERCISE, MEAL, CALORIE, BMI, CONTINUE, END
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


                case State.EXERCISE:


                    if (stateInitMessage)
                    {
                        aMessages.Add("Great! You'd like to exercise.");
                        aMessages.Add("Which muscle group would you like to train today?");
                        aMessages.Add("1- Chest. \n 2- Back.\n 3- Legs.\n 4- Shoulders. \n 5- Arms.\n 6- Core. ");
                        stateInitMessage = false;
                    }
                    else
                    {
                        aMessages.Add(response);
                    }

                    break;
                
                case State.MEAL:

                    break;
                
                case State.CALORIE:
                    break;

                case State.BMI:
                    break;

                case State.CONTINUE:
                     if (stateInitMessage)
                    {
                        aMessages.Add(response);
                        aMessages.Add("Anything else I can help you with?");
                        aMessages.Add("1- Suggest exercise. \n 2- Suggest meal.\n 3- Track calorie.\n 4- Calculate BMI. \n 5- End Session.");
                        stateInitMessage = false;
                    }
                    else
                    {
                        aMessages.Add(response);
                    }

                    break;
                case State.END:

                        aMessages.Add("Thank you for using Fit All Day! Have a nice day!");
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
                   switch(sInMessage)
                    {
                        case "1": // Chest
                            response = "Chest day today eh?. \nOkay. Do push ups, 3 sets, each with 10-15 repetitions.";
                            this.nCur = State.CONTINUE;
                            stateInitMessage = true;
                            break;
                        case "2": // Back
                            response = "Back day today. \nAlright. Start with some pull-ups or bent-over rows, 3 sets, 8-12 reps each.";
                            this.nCur = State.CONTINUE;
                            stateInitMessage = true;
                            break;
                        case "3": // Legs
                            response = "Leg day today. \nGreat! Begin with squats, 4 sets, 8-12 reps each.";
                            this.nCur = State.CONTINUE;
                            stateInitMessage = true;
                            break;
                        case "4": // Shoulders
                            response = "Shoulder day today. \nExcellent choice. Try overhead presses or lateral raises, 3 sets, 10-12 reps each.";
                            this.nCur = State.CONTINUE;
                            stateInitMessage = true;
                            break;
                        case "5": // Arms
                            response = "Arm day today. \nNice. Incorporate bicep curls and tricep dips, 3 sets, 10-12 reps each.";
                            this.nCur = State.CONTINUE;
                            stateInitMessage = true;
                            break;
                        case "6": // Core
                            response = "Core day today. \nGood decision. Engage in planks or Russian twists, 3 sets, 30-60 seconds for planks, 10-12 reps for twists.";
                            this.nCur = State.CONTINUE;
                            stateInitMessage = true;
                            break;
                        default:
                            response = "Incorrect response. Please try again.";
                            break;
                    }


                   
                    break;

                  case State.CONTINUE:
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
                            case "5":
                                this.nCur = State.END;
                                break;
                            default:
                                response = "Incorrect response. Please try again.";

                                break;

                        }

                   
                    break;


            }

            return response;


        }

    }
}
