using System;
using System.IO.Ports;
using System.Device.Location;
using System.Text.Json;
using System.Windows.Forms;

namespace ProgettoDinamoDB
{
    class JsonConnection
    {
        public Data GetData(SerialPort serialPort)
        {
            Data d = new Data();
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1));
            GeoCoordinate coord = watcher.Position.Location;
            while(serialPort.IsOpen)
            {
                //Reads the serial strings, and if it is a valid JSON document
                //it reads it and applies it to a object that we can return
                string inData = serialPort.ReadLine();
                if(IsJsonValid(inData))
                {
                    d = JsonSerializer.Deserialize<Data>(inData);
                    serialPort.Close();
                }
            }
            d.Time = DateTime.Now.ToString();
            d.ID = (uint)d.Time.GetHashCode();
            try
            {
                //we retrieve the coordinates from our GPS
                //if your pc does not have a GPS it won't retrieve anything
                //and your position will be set to 404 and 404
                d.CordX = Convert.ToInt32(watcher.Position.Location.Latitude);
                d.CordY = Convert.ToInt32(watcher.Position.Location.Longitude);
            }
            catch
            {
                d.CordX = 404;
                d.CordY = 404;
            }
            return d;
        }
        public static bool IsJsonValid(string txt)
        {
            //if parsing returns an error it's not valid
            try { return JsonDocument.Parse(txt) != null; } catch { return false; }
        }
    }
}