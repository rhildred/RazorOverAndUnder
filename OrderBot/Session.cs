using System;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, MEDICINE,PRESCRIPTION, 
        }

        private State nCur = State.WELCOMING;
        private Order oOrder;

        public Session(string sPhone)
        {
            this.oOrder = new Order();
            this.oOrder.Phone = sPhone;
        }

        public List<String> OnMessage(String sInMessage)
        {
            List<String> aMessages = new List<string>();
            switch (this.nCur)
            {
                case State.WELCOMING:
                    aMessages.Add("Welcome to Nanak Medical Store!");
                    aMessages.Add("What medicine would you like?");
                    this.nCur = State.MEDICINE;
                    break;
                case State.MEDICINE:
                    this.oOrder.Size = sInMessage;
                    this.oOrder.Save();
                    aMessages.Add("What is medicine prescribed (1.Narcotic 2. Non-narcotic)  " + this.oOrder.Size + " by Doctor?");
                    this.nCur = State.PRESCRIPTION;
                    break;
                case State.PRESCRIPTION:
                    string sPrescription= sInMessage;
                    aMessages.Add("What toppings would you like on this  " + this.oOrder.Size + " " + sPrescription + " Shawarama?");
                    break;


            }
            aMessages.ForEach(delegate (String sMessage)
            {
                System.Diagnostics.Debug.WriteLine(sMessage);
            });
            return aMessages;
        }

    }
}
