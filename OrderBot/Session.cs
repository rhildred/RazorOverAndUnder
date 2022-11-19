using System;
using System.Text;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, SIZE, DESSERT
        }

        private State nCur = State.WELCOMING;
        private Order oOrder;

        private StringBuilder orderDetails = new StringBuilder("");

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
                    aMessages.Add("Welcome to Sangeetha Restaurant!");
                    aMessages.Add("What size of meal would you like? (mini, regular, full)");
                    this.nCur = State.SIZE;
                    break;
                case State.SIZE:
                    this.oOrder.Size = sInMessage;
                    orderDetails.Append(this.oOrder.Size + " meal");
                    this.oOrder.Save();
                    aMessages.Add("What veggies would you like on this " + orderDetails.ToString() + "?");
                    this.nCur = State.DESSERT;
                    break;
                case State.DESSERT:
                    string sDessert = sInMessage;
                    orderDetails.Append(", " + sDessert);
                    aMessages.Add("What dessert would you like along with this  " + orderDetails.ToString() + "?");
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
