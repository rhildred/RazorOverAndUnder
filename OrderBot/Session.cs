using System;
using System.Text;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, SIZE, CURRY1, CURRY2, VEGGY1, VEGGY2, DESSERT, CONFIRM, YES, NO, NAME, PHONE, PAYMENT, FINAL_CONFIRM, DESISION
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
                    aMessages.Add("What would you like to have for option 1 curry on this " + orderDetails.ToString() + "?");
                    this.nCur = State.CURRY1;
                    break;
                case State.CURRY1:
                    this.oOrder.Curry1 = sInMessage;
                    orderDetails.Append(", " + this.oOrder.Curry1);
                    this.oOrder.Save();
                    aMessages.Add("What would you like to have for option 2 curry on this " + orderDetails.ToString() + "?");
                    this.nCur = State.CURRY2;
                    break;
                case State.CURRY2:
                    this.oOrder.Curry2 = sInMessage;
                    orderDetails.Append(", " + this.oOrder.Curry2);
                    this.oOrder.Save();
                    aMessages.Add("What would you like to have for option 1 veggy on this " + orderDetails.ToString() + "?");
                    this.nCur = State.VEGGY1;
                    break;
                case State.VEGGY1:
                    this.oOrder.Veggies1 = sInMessage;
                    orderDetails.Append(", " + this.oOrder.Veggies1);
                    this.oOrder.Save();
                    aMessages.Add("What would you like to have for option 2 veggy on this " + orderDetails.ToString() + "?");
                    this.nCur = State.VEGGY2;
                    break;
                case State.VEGGY2:
                    this.oOrder.Veggies2 = sInMessage;
                    orderDetails.Append(", " + this.oOrder.Veggies2);
                    this.oOrder.Save();
                    aMessages.Add("What dessert would you like along with this " + orderDetails.ToString() + "?");
                    this.nCur = State.DESSERT;
                    break;
                case State.DESSERT:
                    this.oOrder.Dessert1 = sInMessage;
                    orderDetails.Append(", " + this.oOrder.Dessert1);
                    this.oOrder.Save();
                    aMessages.Add("Would you like to confirm  " + orderDetails.ToString() + " order? Only YES or NO allowed, other inputs will be considered as YES.");
                    this.nCur = State.DESISION;
                    break;
                case State.DESISION:
                    string confirmation = sInMessage;

                    if(confirmation.ToLower() == "no")
                    {
                        this.nCur = State.WELCOMING;
                        aMessages.Add("Your order is canceled.");
                        orderDetails.Clear();
                        this.nCur = State.WELCOMING;
                    }
                    else
                    {
                        this.nCur = State.YES;
                        aMessages.Add("Please enter pickup name for order, " + orderDetails.ToString());
                    }

                    break;
                case State.YES:
                    string name = sInMessage;
                    orderDetails.Append(". Order is in the name of " + name);
                    aMessages.Add("Please enter the phone number for order:  " + orderDetails.ToString() + ".");
                    this.nCur = State.PHONE;
                    break;
                case State.NO:
                    aMessages.Add("Your order is canceled.");
                    orderDetails.Clear();
                    this.nCur = State.WELCOMING;
                    break;
                case State.PHONE:
                    string phone = sInMessage;
                    orderDetails.Append(" with phone number " + phone);
                    aMessages.Add("Please enter the payment method for order:  " + orderDetails.ToString() + ".");
                    this.nCur = State.PAYMENT;
                    break;
                case State.PAYMENT:
                    string payment = sInMessage;
                    orderDetails.Append(" and payment method " + payment);
                    aMessages.Add("Your order is confirmed");
                    this.nCur = State.FINAL_CONFIRM;
                    break;
                case State.FINAL_CONFIRM:
                    aMessages.Add("Your order is confirmed");
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
