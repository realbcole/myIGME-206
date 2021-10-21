using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            UsePhone(tardis);
            UsePhone(phoneBooth);
        }

        static void UsePhone(object obj)
        {
            if (obj.GetType() is Tardis)
            {
                Tardis tardis = new Tardis();
                tardis = (Tardis)obj;
                tardis.TimeTravel();
            }
            else if (obj.GetType() is PhoneBooth)
            {
                PhoneBooth phoneBooth = new PhoneBooth();
                phoneBooth = (PhoneBooth)obj;
                phoneBooth.OpenDoor();
            }
        }
    }

    public abstract class Phone
    {
        private string phoneNumber;
        public string address;
        public string PhoneNumber;
        public abstract void Connect();
        public abstract void Disconnect();
    }

    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {
            Console.WriteLine("Answering Phone...");
        }

        public void MakeCall()
        {
            Console.WriteLine("Making Call...");
        }

        public void HangUp()
        {
            Console.WriteLine("Hung up");
        }

        public override void Connect()
        {
            Console.WriteLine("Connecting...");
        }

        public override void Disconnect()
        {
            Console.WriteLine("Disconnected");
        }
    }

    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho { get; }

        public string FemaleSideKick { get; }

        public void TimeTravel()
        {
            Console.WriteLine("Traveling through time...");
        }

        public static bool operator ==(Tardis A, Tardis B)
        {
            if (A.whichDrWho == B.whichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Tardis A, Tardis B)
        {
            if (A.whichDrWho == B.whichDrWho)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator <(Tardis A, Tardis B)
        {
            if (B.whichDrWho == 10)
            {
                return true;
            }
            else if ( A.whichDrWho == 10)
            {
                return false;
            }
            else if (A.whichDrWho < B.whichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(Tardis A, Tardis B)
        {
            if (A.whichDrWho == 10)
            {
                return true;
            }
            else if (B.whichDrWho == 10)
            {
                return false;
            }
            else if (A.whichDrWho > B.whichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(Tardis A, Tardis B)
        {
            if (B.whichDrWho == 10)
            {
                return true;
            }
            else if (A.whichDrWho == 10)
            {
                return false;
            }
            else if (A.whichDrWho <= B.whichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >=(Tardis A, Tardis B)
        {
            if (A.whichDrWho == 10)
            {
                return true;
            }
            else if (B.whichDrWho == 10)
            {
                return false;
            }
            else if (A.whichDrWho >= B.whichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor()
        {
            Console.WriteLine("Opening door...");
        }

        public void CloseDoor()
        {
            Console.WriteLine("Closing door...");
        }
    }

    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {
            Console.WriteLine("Answering Phone...");
        }

        public void MakeCall()
        {
            Console.WriteLine("Making Call...");
        }

        public void HangUp()
        {
            Console.WriteLine("Hung up");
        }

        public override void Connect()
        {
            Console.WriteLine("Connecting...");
        }

        public override void Disconnect()
        {
            Console.WriteLine("Disconnected");
        }
    }

    public interface PhoneInterface
    {
        void Answer();

        void MakeCall();

        void HangUp();

    }
}
