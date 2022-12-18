using Amazon;
using Amazon.Runtime;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using System;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.DataModel;
using System.Linq;

namespace ProgettoDinamoDB
{
    public class DynamoClientSetup
    {
        //DynamoDB client and context for DynamoDB handling
        public AmazonDynamoDBClient client;
        public DynamoDBContext context;
        //Logs in into the DB with provided credentials
        public DynamoClientSetup(string AccessKeyID, string SecretAccessKey)
        {
            var AWScredentials = new BasicAWSCredentials(AccessKeyID, SecretAccessKey);
            client = new AmazonDynamoDBClient(AWScredentials, RegionEndpoint.EUCentral1);
            context = new DynamoDBContext();
        }
        public void WaitUntilTableReady()
        {
            string tableName = "Data";
            string status = null;
            do
            {
                //checks the table info
                var res = client.DescribeTable(new DescribeTableRequest
                {
                    TableName = tableName
                });
                status = res.Table.TableStatus;
            } while (status != "ACTIVE");
            //While loop that checks a table status until it gets ready
        }
        public void CreateTable(string tableName)
        {
            //Lists the tables inside your account
            List<string> currentTables = client.ListTablesAsync().Result.TableNames;
            if (!currentTables.Contains(tableName))
            {
                //if the table "Data" is not present, it gets created
                //For the DynamoDB way of functioning in the table request creation
                //only the minimal keys are created in a table creation
                //All the others are inserted after and dynamically
                var request = new CreateTableRequest
                {
                    TableName = tableName,
                    AttributeDefinitions = new List<AttributeDefinition>
                      {
                        new AttributeDefinition
                        {
                          AttributeName = "ID",
                          AttributeType = "N"
                        },
                        new AttributeDefinition
                        {
                          AttributeName = "Time",
                          AttributeType = "S"
                        }
                      },
                    KeySchema = new List<KeySchemaElement>
                      {
                        new KeySchemaElement
                        {
                          AttributeName = "ID",
                          KeyType = "HASH"
                        },
                        new KeySchemaElement
                        {
                          AttributeName = "Time",
                          KeyType = "RANGE"
                        }
                      },
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 10,
                        WriteCapacityUnits = 5
                    },
                };
                var response = client.CreateTableAsync(request);
            }
        }
        public void InsertItem(Data d)
        {
            var table = Table.LoadTable(client, "Data");
            //Creates a Document, a data type that defines a key-value
            //pair that defines an item in DynamoDB
            Document Data = new Document();
            Data["ID"] = d.ID;
            Data["Time"] = d.Time.ToString();
            Data["Light"] = d.Lumin;
            Data["Temperature"] = d.Deg;
            Data["X Coordinate"] = d.CordX;
            Data["Y Coordinate"] = d.CordY;
            Data["WaterLevel"] = d.WaterLevel;
            Data["Humidity"] = d.Humidity;
            table.PutItem(Data);
        }
        public List<Data> SearchItem(DateTime TimeCheckStart, DateTime TimeCheckEnd)
        {
            Table DataTable = Table.LoadTable(client, "Data");
            ScanFilter scanFilter = new ScanFilter();
            //Filter conditions for the scan
            scanFilter.AddCondition("ID", ScanOperator.IsNotNull);
            ScanOperationConfig config = new ScanOperationConfig()
            {
                //Declares the values we are going to search
                Filter = scanFilter,
                Select = SelectValues.SpecificAttributes,
                AttributesToGet = new List<string> { "ID", "Time", "Light", "Temperature", "X Coordinate", "Y Coordinate", "Humidity", "WaterLevel" }
            };
            List<Document> documentList = new List<Document>();
            List<Data> ld = new List<Data>();
            Search search = DataTable.Scan(config);
            var dates = new List<string>();
            for (var dt = TimeCheckStart; dt <= TimeCheckEnd; dt = dt.AddDays(1))
            {
                //Converts DateTime values given to the method into strings
                dates.Add(dt.Date.ToString("dd/MM/yyyy"));
            }
            do
            {
                documentList = search.GetNextSet();
                foreach (var document in documentList)
                {
                    Data d = new Data();
                    //Converts Document attributes and puts them into ours result list if
                    //their date matches with the ones provided
                    d.ID = Convert.ToUInt32(document["ID"].AsPrimitive().Value.ToString());
                    d.Time = document["Time"].AsPrimitive().Value.ToString();
                    d.Lumin = Convert.ToInt32(document["Light"].AsPrimitive().Value.ToString());
                    d.Deg = Convert.ToInt32(document["Temperature"].AsPrimitive().Value.ToString());
                    d.CordX = Convert.ToInt32(document["X Coordinate"].AsPrimitive().Value.ToString());
                    d.CordY = Convert.ToInt32(document["Y Coordinate"].AsPrimitive().Value.ToString()); 
                    d.WaterLevel = Convert.ToInt32(document["WaterLevel"].AsPrimitive().Value.ToString());
                    d.Humidity = Convert.ToInt32(document["Humidity"].AsPrimitive().Value.ToString());
                    if (dates.Any(s => d.Time.Contains(s)))
                    {
                        ld.Add(d);
                    }
                }
            } while (!search.IsDone);
            return ld;
        }
        public void DeleteTable(string tableName)
        {
            var request = new DeleteTableRequest
            {
                TableName = tableName
            };
        }
    }
}
