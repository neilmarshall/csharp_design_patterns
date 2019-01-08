using System;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Light livingRoomLight = new Light("Living room light");
            Light kitchenLight = new Light("Kitchen light");
            Stereo loungeStereo = new Stereo("Lounge stereo");

            LightOn livingRoomLightOn = new LightOn(livingRoomLight);
            LightOff livingRoomLightOff = new LightOff(livingRoomLight);
            LightOn kitchenLightOn = new LightOn(kitchenLight);
            LightOff kitchenLightOff = new LightOff(kitchenLight);
            StereoOn loungeStereoOn = new StereoOn(loungeStereo);
            StereoOff loungeStereoOff = new StereoOff(loungeStereo);

            RemoteControl remoteControl = new RemoteControl();
            remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
            remoteControl.SetCommand(1, kitchenLightOn, kitchenLightOff);
            remoteControl.SetCommand(2, loungeStereoOn, loungeStereoOff);

            for (int i = 0; i < 7; i++)
                remoteControl.OnButtonWasPushed(i);

            for (int i = 0; i < 7; i++)
                remoteControl.OffButtonWasPushed(i);
        }
    }
}
