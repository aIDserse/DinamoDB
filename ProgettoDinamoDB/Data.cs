using Amazon.DynamoDBv2.DataModel;
using System.Text.Json.Serialization;

namespace ProgettoDinamoDB
{
    [DynamoDBTable("Data")]
    public class Data
    {
        [DynamoDBHashKey]
        [JsonInclude]
        public uint ID;
        [JsonInclude]
        [DynamoDBRangeKey]
        public string Time;
        [JsonInclude]
        [DynamoDBProperty]
        public int Lumin;
        [JsonInclude]
        [DynamoDBProperty]
        public int Deg;
        [JsonInclude]
        [DynamoDBProperty]
        public int WaterLevel;
        [JsonInclude]
        [DynamoDBProperty]
        public int Humidity;
        [JsonInclude]
        [DynamoDBProperty]
        public int CordX;
        [JsonInclude]
        [DynamoDBProperty]
        public int CordY;
        public override string ToString()
        {
            return ID + " - " + Time.ToString() + "\n Lumin:" + Lumin + "\n Deg:" + Deg + "\n Water Level:" + WaterLevel + "\n Humidity:" + Humidity;
        }
    }
}
