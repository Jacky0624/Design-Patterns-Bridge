
INortifer nortifer = new MailNotifier();
IWeatherDescriptor descriptor = new ParisWeatherDescriptor();
IWeatherStation station = new WeatherStation(nortifer, descriptor);
station.Notify();



interface INortifer
{
    void Notify(string msg);
}

class MailNotifier : INortifer
{
    public void Notify(string msg)
    {
        Console.WriteLine($"send mail, msg : {msg}");
    }
}

class SMSNotifier : INortifer
{
    public void Notify(string msg)
    {
        Console.WriteLine($"send SMS, msg : {msg}");
    }
}


interface IWeatherDescriptor
{
    string GetDescribe();
}

class TaipeiWeatherDescriptor : IWeatherDescriptor
{
    public string GetDescribe()
    {
        return "Taipei So hot";
    }
}
class ParisWeatherDescriptor : IWeatherDescriptor
{
    public string GetDescribe()
    {
        return "Paris So Cold";
    }
}

interface IWeatherStation
{
    void Notify();
}
class WeatherStation : IWeatherStation
{
    private readonly INortifer _nortifer;
    private readonly IWeatherDescriptor _descriptor;

    public WeatherStation(INortifer nortifer, IWeatherDescriptor descriptor)
    {
        _nortifer = nortifer;
        _descriptor = descriptor;
    }

    public void Notify()
    {
        var des = _descriptor.GetDescribe();
        Console.WriteLine("Save DB");
        _nortifer.Notify(des);
    }
}





